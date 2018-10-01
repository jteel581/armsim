using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class shiftByRegOp2 : Operand2
    {
        int rS;
        int shiftTypeVal;
        int rM;
        
        public shiftByRegOp2(short op2Val) : base(op2Val)
        {
            setrS();
            setShiftTypeVal();
            setrM();
        }

        public void setrS()
        {
            Memory bits = base.getOp2Array();
            int val = 0;
            for (int i = 11; i > 7; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 8) : 0;
            }
            rS = val;
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
