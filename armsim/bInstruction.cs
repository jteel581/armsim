using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class bInstruction : Instruction
    {
        bool lBit;
        int givenImmediate;
        int effectiveAddress;

        public bInstruction(int instVal, int pcVal) : base(instVal)
        {
            Memory bits = base.getBits();
            lBit = bits.TestFlag(0, 24) ? true : false;
            for (int i = 23; i > -1; i--)
            {
                givenImmediate += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            bool signBit = bits.TestFlag(0, 23);
            if (signBit)
            {
                for (int i = 24; i < 31; i++)
                {
                    givenImmediate += (int)Math.Pow(2, i);
                }
            }
            givenImmediate = givenImmediate << 2;
            effectiveAddress = pcVal + 8 + givenImmediate;
            base.setInstrStr(this.ToString());
        }

        public override void execute(CPU processor)
        {
            int pcVal = processor.getProgramCounter();
            int oldPC = pcVal;
            pcVal += 8;
            effectiveAddress = pcVal + givenImmediate;

            // bl instruction
            if (lBit)
            {
                processor.getRegisters().setReg(14, oldPC + 4);
            }
            // subtract four to account for incrementing of PC during fetch decode execute 
            processor.getRegisters().setReg(15, effectiveAddress - 4);
            Tracer.bPc = (oldPC).ToString("x8").ToUpper();
            Tracer.branchInstr = true;
        }

        public override string ToString()
        {
            string instrStr = "b";
            if (lBit)
            {
                instrStr += "l";

            }
            instrStr += " " + effectiveAddress.ToString("x4");
            return instrStr;

        }


    }
}
