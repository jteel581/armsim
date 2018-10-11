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

        Memory instrArray;
        public int getShift() { return shiftVal; }
        public int getShiftType() { return shiftTypeVal; }
        public int getRm() { return rM; }

        /// <summary>
        /// This is the constructor for the shiftedRegOffset class
        /// </summary>
        /// <param name="offsetVal"></param> is used to instatiate the base class
        public shiftedRegOffset(short offsetVal, Memory instr) : base(offsetVal)
        {
            // No psuedo code, but actual code:
            instrArray = instr;

            setShiftVal();
            setShiftTypeVal();
            setrM();
            offset = shiftVal;
        }

        /// <summary>
        /// This is used to get the value of the shift from the byte array and set it to the shiftVal variable
        /// </summary>
        public void setShiftVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = instrArray;
            for (int i = 11; i > 6; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 7) : 0;
            }
            shiftVal = val;
            // not needed
            if (!bits.TestFlag(0, 23))
            {
                shiftVal = -shiftVal;
            }
        }

        /// <summary>
        /// This is used to get the numeric value of the shift type from the byte array and 
        /// assign it to the shiftTypeVal variable
        /// </summary>
        public void setShiftTypeVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = instrArray;
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
            Memory bits = instrArray;
            for (int i = 3; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }

            rM = val;
        }

        public override string ToString()
        {
            string osStr = "";
            string shiftType = "";
            switch (shiftTypeVal)
            {
                case 0:
                    shiftType = "lsl";
                    break;
                case 1:
                    shiftType = "lsr";
                    break;
                case 2:
                    shiftType = "asr";
                    break;
                case 3:
                    shiftType = "ror";
                    break;
            }
            Memory bits = instrArray;
            if (!bits.TestFlag(0, 23))
            {
                osStr += "-r" + rM + ", " + shiftType;
                
            }
            else
            {
                osStr += "r" + rM + ", " + shiftType;
            }
            if (shiftVal != 0)
            {
                osStr += "#" + shiftVal + "]";
            }
            return osStr;
        }
    }
}
