using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class lsInstruction : Instruction
    {
        bool pBit;
        bool uBit;
        bool bBit;
        bool wBit;
        bool lBit;
        int rN;
        int rD;
        // Offset os;
        public lsInstruction(uint instVal) : base(instVal)
        {
            Memory bits = base.getBits();
            pBit = bits.TestFlag(0, 24);
            uBit = bits.TestFlag(0, 23);
            bBit = bits.TestFlag(0, 22);
            wBit = bits.TestFlag(0, 21);
            lBit = bits.TestFlag(0, 20);

            setOps(bits);

        }

        public void setOps(Memory bits)
        {
            rN = 0;
            rN += bits.TestFlag(0, 19) ? 8 : 0;
            rN += bits.TestFlag(0, 18) ? 4 : 0;
            rN += bits.TestFlag(0, 17) ? 2 : 0;
            rN += bits.TestFlag(0, 16) ? 1 : 0;

            rD = 0;
            rD += bits.TestFlag(0, 15) ? 8 : 0;
            rD += bits.TestFlag(0, 14) ? 4 : 0;
            rD += bits.TestFlag(0, 13) ? 2 : 0;
            rD += bits.TestFlag(0, 12) ? 1 : 0;
        }
    }
}
