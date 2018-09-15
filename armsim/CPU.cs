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
        int ProgramCounter;

        public Memory getRAM() { return RAM; }
        public Memory getRegisters() { return Registers; }


        /// <summary>
        /// These are getter and setter methods for the ProgramCounter variable.
        /// </summary>
        /// <returns></returns>
        public int getProgramCounter() { return ProgramCounter; }
        public void setProgramCounter(int newVal)
        {
            ProgramCounter = newVal;
            Registers.WriteWord(60, (uint)newVal);
        }
        public CPU(Memory ram, Memory regs)
        {
            RAM = ram;
            Registers = regs;
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
            int value = RAM.ReadWord(ProgramCounter);
            return value;
        }
        /// <summary>
        /// This method will be implimented and used in a later phase
        /// </summary>
        public void decode()
        {
            // Do nothing for now
        }
        /// <summary>
        /// This mehtod is used to execute an instruction, however, for this phase it is merely 
        /// used to pause for 1/4th of a second.
        /// </summary>
        public void execute()
        {
            Thread.Sleep(250);
        }

    }
}
