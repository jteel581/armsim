using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class MULinstruction : Instruction
    {
        // The condition of the S bit
        bool sBit;
        // The Rd register number
        int rD;
        // The Rs register number
        int rS;
        // The Rm register number
        int rM;


        public MULinstruction(uint instVal) : base(instVal)
        {
            Memory bits = base.getBits();
            sBit = bits.TestFlag(0, 20) ? true : false;
            setOps(bits);

        }

        public override void execute(CPU processor)
        {
            Memory regs = processor.getRegisters();
            int RsVal = regs.getReg(rS);
            int RmVal = regs.getReg(rM);
            int val = (RsVal * RmVal);
            regs.setReg(rD, val);
        }

        public void setOps(Memory bits)
        {
            // No psuedo code, but actual code:

            rD = 0;
            rD += bits.TestFlag(0, 19) ? 8 : 0;
            rD += bits.TestFlag(0, 18) ? 4 : 0;
            rD += bits.TestFlag(0, 17) ? 2 : 0;
            rD += bits.TestFlag(0, 16) ? 1 : 0;

            rS = 0;
            rS += bits.TestFlag(0, 11) ? 8 : 0;
            rS += bits.TestFlag(0, 10) ? 4 : 0;
            rS += bits.TestFlag(0, 9) ? 2 : 0;
            rS += bits.TestFlag(0, 8) ? 1 : 0;

            rM = 0;
            rM += bits.TestFlag(0, 3) ? 8 : 0;
            rM += bits.TestFlag(0, 2) ? 4 : 0;
            rM += bits.TestFlag(0, 1) ? 2 : 0;
            rM += bits.TestFlag(0, 0) ? 1 : 0;
        }

        public override string ToString()
        {
            string instrStr = "mul ";
            instrStr += "r" + rD + ", r" + rM + ", r" + rS;

            return instrStr;
        }
    }
}
