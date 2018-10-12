using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class lsmInstruction : Instruction
    {
        bool pBit;
        bool uBit;
        bool sBit;
        bool wBit;
        bool lBit;

        int rN;

        List<int> regList;

        public lsmInstruction(int instVal) :base(instVal)
        {
            Memory bits = base.getBits();
            pBit = bits.TestFlag(0, 24) ? true : false;
            uBit = bits.TestFlag(0, 23) ? true : false;
            sBit = bits.TestFlag(0, 22) ? true : false;
            wBit = bits.TestFlag(0, 21) ? true : false;
            lBit = bits.TestFlag(0, 20) ? true : false;

            rN = 0;
            rN += bits.TestFlag(0, 19) ? 8 : 0;
            rN += bits.TestFlag(0, 18) ? 4 : 0;
            rN += bits.TestFlag(0, 17) ? 2 : 0;
            rN += bits.TestFlag(0, 16) ? 1 : 0;

            fillRegList();


        }

        public override void execute(CPU processor)
        {
            Memory ram = processor.getRAM();
            Memory regs = processor.getRegisters();
            int RnVal = regs.getReg(rN);
            if (rN == 15)
            {
                RnVal += 8;
            }
            // ldmfd (pop)
            if (lBit && !pBit && uBit)
            {
                foreach (int reg in regList)
                {
                    int word = ram.ReadWord(RnVal);
                    regs.setReg(reg, word);
                    RnVal += 4;
                }
                
            }
            // stmfd (push)
            else if (!lBit && pBit && !uBit)
            {
                List<int> reverseRegs = regList;
                reverseRegs.Reverse();
                foreach (int reg in reverseRegs)
                {
                    RnVal -= 4;

                    int word = regs.getReg(reg);
                    ram.WriteWord(RnVal, word);
                    int newWord = ram.ReadWord(RnVal);
                }
            }
            else
            {
                // error
            }

            if (wBit)
            {
                regs.setReg(rN, RnVal);
            }

        }

        public void fillRegList()
        {
            regList = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                if (getBits().TestFlag(0, i))
                {
                    regList.Add(i);
                }
            }
        }

        public override string ToString()
        {
            string instr = lBit ? "ldmfd r" : "stmfd r";
            if (wBit)
            {
                instr += rN + "! " + regListToString();

            }
            else
            {
                instr += rN + " " + regListToString();

            }
            return instr;
        }

        public string regListToString()
        {
            string regListStr = "{";
            foreach (int reg in regList)
            {
                regListStr += "r" + reg;
                if (reg != regList.Last())
                {
                    regListStr += ", ";
                }
                else
                {
                    regListStr += "}";
                }
            }
            return regListStr;
        }
    }
}
