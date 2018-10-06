// shiftByValOp2.cs
// This file holds the shiftByValOp2 class which inherits from the op2 class and contains
// information about the op2 that is shifted by an immediate value
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class shiftByValOp2 : Operand2
    {
        int shiftVal;
        int shiftTypeVal;
        int rM;


        public shiftByValOp2(short op2Val) : base(op2Val)
        {
            setShiftVal();
            setShiftTypeVal();
            setrM();
        }

        public void setShiftVal()
        {
            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 11; i > 6; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 7) : 0;
            }
            shiftVal = val;
        }

        public void setShiftTypeVal()
        {
            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 6; i > 4; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 5) : 0;
            }
            shiftTypeVal = val;
        }

        public void setrM()
        {
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
