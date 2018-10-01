using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Operand2
    {
        Memory op2Array;
        public virtual int getImmediateVal()
        {
            return 0;
        }
        public Operand2(short op2Val)
        {
            op2Array = new Memory(4);
            op2Array.WriteHalfWord(0, op2Val);
        }
        public Memory getOp2Array() { return op2Array; }

    }
}
