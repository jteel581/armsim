// shiftByRegOp2.cs
// This file holds the shiftByRegOp2 class which inherits from Operand2 and holds information regarding
// operand 2 objects that are used when decoding shift by register operand 2s
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class shiftByRegOp2 : Operand2
    {
        // number of Rs register
        int rS;
        // numeric value of shift bits
        int shiftTypeVal;
        // number of Rm register
        int rM;
        
        /// <summary>
        /// This is the constructor for the shiftByRegOp2 class
        /// </summary>
        /// <param name="op2Val"></param> is used to instatiate the base object
        public shiftByRegOp2(short op2Val) : base(op2Val)
        {
            // No psuedo code, but actual code:

            setrS();
            setShiftTypeVal();
            setrM();
        }

        /// <summary>
        /// This is used to get the number of the Rs register and assign it to the rS variable.
        /// </summary>
        public void setrS()
        {
            // No psuedo code, but actual code:

            Memory bits = base.getOp2Array();
            int val = 0;
            for (int i = 11; i > 7; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 8) : 0;
            }
            rS = val;
        }

        /// <summary>
        /// This is used to get the numeric value of the shift type and assign it to the shiftType Variable
        /// </summary>
        public void setShiftTypeVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 6; i > 4; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 5) : 0;
            }
            shiftTypeVal = val;
        }

        /// <summary>
        /// This is used to get the number of the Rm register and assign it to rM
        /// </summary>
        public void setrM()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 3; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            rM = val;
        }
    }
}
