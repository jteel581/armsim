// CPU.cs 
// This file holds the CPU class which is used to simulate the CPU of the computer that 
// this program is simulating.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace armsim
{

    class CPU
    {
        Memory RAM;
        Memory Registers;
        Memory CPSR;
        int ProgramCounter;
        Computer computer;

        public Memory getRAM() { return RAM; }
        public Memory getRegisters() { return Registers; }
        public Memory getCPSR() { return CPSR; }
        public Computer GetComputer() { return computer; }

        /// <summary>
        /// These are getter and setter methods for the ProgramCounter variable.
        /// </summary>
        /// <returns></returns>
        public int getProgramCounter() { return ProgramCounter; }
        public void setProgramCounter(int newVal)
        {
            ProgramCounter = newVal;
            Registers.WriteWord(60, newVal);
        }
        public void setCPSR(byte cpsrVal)
        {
            cpsrVal *= 16;
            CPSR.WriteByte(3, cpsrVal);
        }
        public CPU(Computer comp)
        {

            RAM = comp.getRAM();
            Registers = comp.getRegisters();
            CPSR = comp.getCPSR();
            computer = comp;
            ProgramCounter = 0;
        }
        /// <summary>
        /// This method is used to read a word from memory at a given location in order to 'fetch'
        /// an instruction from memory. It takes no parameters.
        /// </summary>
        /// <returns>It returns 'value' which holds the value read from memory at the location 
        /// stored in the program counter register.</returns>
        public int fetch()
        {
            int addr = Registers.ReadWord(60);
            int value = RAM.ReadWord(Registers.ReadWord(60));
            if (value == 0)
            {

            }
            return value;
        }
        /// <summary>
        /// This method will be implimented and used in a later phase
        /// </summary>
        public Instruction decode(int instrVal)
        {
            var inst = new Instruction(instrVal);
            Memory instrArray = inst.getBits();
           
            // check for MULinstruction
            bool isMulInstr = checkForMulInstr(instrArray);
            bool isSwiInstr = checkForSwiInstr(instrArray);
            bool isLSMInstr = checkForLSMInstr(instrArray);
            bool isBXInstr = checkForBxInstr(instrArray);

            if (isMulInstr)
            {
                return new MULinstruction(instrVal);
            }
            else if (isSwiInstr)
            {
                return new SWIinstruction(instrVal);
            }
            else if (isLSMInstr)
            {
                return new lsmInstruction(instrVal);
            }
            else if (isBXInstr)
            {
                return new bxInstruction(instrVal);
            }
            else
            {
                if (instrArray.TestFlag(0,27) && instrArray.TestFlag(0,25))
                {

                }
                var b = Memory.ExtractBits(instrArray.ReadWord(0), 25, 27);
                b = b >> 25;
                //var b = instrArray.TestFlag(0, 26) ? 2 : 0;
                switch (b)
                {
                    case 0:
                    case 1:
                        return new dpInstruction(instrVal, false);
                    case 2:
                    case 3:
                        return new lsInstruction(instrVal);
                    case 5:
                        return new bInstruction(instrVal, getProgramCounter());

                }
            }
            
            return null;
            
        }

        public bool checkForLSMInstr(Memory instrArray)
        {
            for (int i = 27; i > 24; i--)
            {
                if (i == 27 && !instrArray.TestFlag(0, i))
                {
                    return false;
                }
                else if (i != 27 && instrArray.TestFlag(0,i))
                {
                    return false;
                }
                else if (i == 25)
                {
                    return true;
                }

            }
            return false;
        }

        public bool checkForBxInstr(Memory instrArray)
        {
            int num = 0;
            for (int i = 27; i > 19; i--)
            {
                num +=  instrArray.TestFlag(0, i) ? (int)Math.Pow(2, i - 20) : 0;

            }
            if (num != 18)
            {
                return false;

            }
            else
            {
                num = 0;
                for (int i = 7; i > 3; i--)
                {
                    num += instrArray.TestFlag(0, i) ? (int)Math.Pow(2, i - 4) : 0;

                }
                if (num == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool checkForSwiInstr(Memory instrArray)
        {
            for (int i = 27; i > 23; i--)
            {
                if (!instrArray.TestFlag(0, i))
                {
                    return false;
                }

            }
            return true;
        }


        public bool checkForMulInstr(Memory instrArray)
        {
            for (int i = 27; i > 20; i--)
            {
                if (instrArray.TestFlag(0, i))
                {
                    return false;
                }

            }
            for (int i = 7; i > 3; i--)
            {
                if (i ==7 && !instrArray.TestFlag(0, i))
                {
                    return false;
                }
                else if (i == 4 && !instrArray.TestFlag(0, i))
                {
                    return false;
                }
                else if (i != 7 && i != 4 && instrArray.TestFlag(0, i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This mehtod is used to execute an instruction, however, for this phase it is merely 
        /// used to pause for 1/4th of a second.
        /// </summary>
        public void execute(Instruction instr)
        {
            if (instr.checkConditions(this))
            {
                if (instr is MULinstruction)
                {
                    MULinstruction mi = (MULinstruction)instr;

                    mi.execute(this);
                }
                else if (instr is SWIinstruction)
                {
                    SWIinstruction swi = (SWIinstruction)instr;
                    swi.execute(this);
                    // do nothing and stop running
                }
                else if (instr is dpInstruction)
                {
                    dpInstruction dpi = (dpInstruction)instr;
                    if (dpi.getSpecificInstr() != null)
                    {
                        dpi.getSpecificInstr().execute(this);

                    }
                    else
                    {
                        // blah blah blah
                    }
                }
                else if (instr is lsInstruction)
                {
                    lsInstruction lsi = (lsInstruction)instr;
                    lsi.execute(this);

                }
                else if (instr is lsmInstruction)
                {
                    lsmInstruction lsmi = (lsmInstruction)instr;
                    lsmi.execute(this);
                    int word1 = RAM.ReadWord(0x7000);
                    int word2 = RAM.ReadWord(0x6ffc);
                    int word3 = RAM.ReadWord(0x6ff8);
                }
                else if (instr is bInstruction)
                {
                    bInstruction bi = (bInstruction)instr;
                    bi.execute(this);
                }
                else if (instr is bxInstruction)
                {
                    bxInstruction bxi = (bxInstruction)instr;
                    bxi.execute(this);
                }
            }
            
        }
        

    }
}
