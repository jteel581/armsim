// shiftedRegOffset.cs
// This file holds the shiftedRegOffset class which inherits from the Offset class and holds information
// regarding the specific type of offset that is shifted by a register
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class shiftedRegOffset : Offset
    {
        // The numeric value of the shift bits
        int shiftVal;
        // The numeric value of the shift type bits
        int shiftTypeVal;
        // The number of the Rm register
        int rM;


        public int getShift() { return shiftVal; }
        public int getShiftType() { return shiftTypeVal; }
        public int getRm() { return rM; }

        /// <summary>
        /// This is the constructor for the shiftedRegOffset class
        /// </summary>
        /// <param name="offsetVal"></param> is used to instatiate the base class
        public shiftedRegOffset(short offsetVal) : base(offsetVal)
        {
            // No psuedo code, but actual code:

            setShiftVal();
            setShiftTypeVal();
            setrM();
        }

        /// <summary>
        /// This is used to get the value of the shift from the byte array and set it to the shiftVal variable
        /// </summary>
        public void setShiftVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOffsetArray();
            for (int i = 11; i > 6; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 7) : 0;
            }
            shiftVal = val;
        }

        /// <summary>
        /// This is used to get the numeric value of the shift type from the byte array and 
        /// assign it to the shiftTypeVal variable
        /// </summary>
        public void setShiftTypeVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOffsetArray();
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
            int val = 0;
            Memory bits = base.getOffsetArray();
            for (int i = 3; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            rM = val;
        }
    }
}
