using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class imOp2 : Operand2
    {
        int alignmentVal;
        int immediateVal;

        public override int  getImmediateVal() { return immediateVal; }
        public imOp2(short op2Val) : base( op2Val)
        {
            setAlignmentVal();
            setImVal();
        }

        
        public void setAlignmentVal()
        {
            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 11; i > 7; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 8) : 0;
            }
            alignmentVal = val;
        }

        public void setImVal()
        {
            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 7; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            immediateVal = val;
        }
    }
}
