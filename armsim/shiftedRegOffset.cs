using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class shiftedRegOffset : Offset
    {
        int shiftVal;
        int shiftTypeVal;
        int rM;

        public shiftedRegOffset(short offsetVal) : base(offsetVal)
        {
            setShiftVal();
            setShiftTypeVal();
            setrM();
        }

        public void setShiftVal()
        {
            int val = 0;
            Memory bits = base.getOffsetArray();
            for (int i = 11; i > 6; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 7) : 0;
            }
            shiftVal = val;
        }

        public void setShiftTypeVal()
        {
            int val = 0;
            Memory bits = base.getOffsetArray();
            for (int i = 6; i > 4; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 5) : 0;
            }
            shiftTypeVal = val;
        }

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
