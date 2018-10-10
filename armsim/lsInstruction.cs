// lsInstruction.cs
// This file holds the lsInstruction class which is used to represent load/store
// instructions. It inherits from the Instruciton class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class lsInstruction : Instruction
    {
        // Status of the P bit
        bool pBit;
        // Status of the U bit
        bool uBit;
        // Status of the B bit
        bool bBit;
        // Status of the W bit
        bool wBit;
        // Status of the L bit
        bool lBit;

        // Number of Rn register
        int rN;

        // Number of Rd register
        int rD;
        // offset object used to hold the informaiton in the offset part of the instruction
        // Offset os;

        /// <summary>
        /// This is the constructor for the lsInstruction class
        /// </summary>
        /// <param name="instVal"></param> is used to instantiate the base instruction class
        public lsInstruction(int instVal) : base(instVal)
        {
            // No psuedo code, but actual code:

            Memory bits = base.getBits();
            pBit = bits.TestFlag(0, 24);
            uBit = bits.TestFlag(0, 23);
            bBit = bits.TestFlag(0, 22);
            wBit = bits.TestFlag(0, 21);
            lBit = bits.TestFlag(0, 20);

            setOps(bits);

        }

        /// <summary>
        /// This is used to set number of registers of the operators (Rn, Rd)
        /// </summary>
        /// <param name="bits"></param> is used to provide an easy way to test individual bits
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
