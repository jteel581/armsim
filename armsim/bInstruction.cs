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

        public bInstruction(int instVal) : base(instVal)
        {
            Memory bits = base.getBits();
            lBit = bits.TestFlag(0, 24) ? true : false;
            for (int i = 23; i > -1; i--)
            {
                givenImmediate += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            bool signBit = bits.TestFlag(0, 31);
            if (signBit)
            {
                for (int i = 24; i < 31; i++)
                {
                    givenImmediate += (int)Math.Pow(2, i);
                }
            }
            givenImmediate = givenImmediate << 2;
            effectiveAddress = 0;
        }

        public override void execute(CPU processor)
        {
            int pcVal = processor.getProgramCounter();
            effectiveAddress = pcVal + givenImmediate;

            // bl instruction
            if (lBit)
            {
                processor.getRAM().setReg(14, pcVal - 4);
            }
            // subtract four to account for incrementing of PC during fetch decode execute 
            processor.getRAM().setReg(15, effectiveAddress - 4);
        }

        public override string ToString()
        {
            string instrStr = "b";
            if (lBit)
            {
                instrStr += "l";

            }
            instrStr += " " + effectiveAddress;
            return instrStr;

        }


    }
}
