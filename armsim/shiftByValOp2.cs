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
        int shiftValForMOV;

        public int getShiftVal() { return shiftVal; }
        public void setShiftVal(int newShft)
        {
            shiftVal = newShft;
        }
        public int getShiftTypeVal() { return shiftTypeVal; }
        public void setShiftTypeVal(int newShiftTypeVal)
        {
            shiftTypeVal = newShiftTypeVal;
        }
        public int getRm()
        {
            return rM;
        }

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

        public int getShiftValForMOV() { return shiftValForMOV; }
        public void setShiftValForMOV()
        {
            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 11; i > 3; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 4) : 0;
            }
            shiftValForMOV = val;
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
        /*
        public int  rotateRmRight(int rotVal)
        {
            int num = 0;
            num  = (rM >> rotVal * 2) | (rM >> (32 - rotVal * 2));
            return num;
        }
        */
        public override string ToString()
        {
            string op2Str = ", r";
            op2Str += getRm();
            if (shiftVal != 0)
            {
                op2Str += ", ";
                switch (shiftTypeVal)
                {
                    case 0: // lsl
                        op2Str += "lsl ";
                        break;
                    case 1: // lsr
                        op2Str += "lsr ";
                        break;
                    case 2: // asr
                        op2Str += "asr ";
                        break;
                    case 3: // ror 
                        op2Str += "ror ";
                        break;
                }
                op2Str += "#" + shiftVal + "]";
            }

            


            return op2Str;
        }
    }
}
