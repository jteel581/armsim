using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class SWIinstruction : Instruction
    {
        int imm24;

        public SWIinstruction(int instVal) :base(instVal)
        {
            Memory bits = base.getBits();
            imm24 = 0;
            imm24 = bits.ReadByte(2);
            imm24 <<= 8;
            imm24 |= bits.ReadByte(1);
            imm24 <<= 8;
            imm24 |= bits.ReadByte(0);

        }

        public override string ToString()
        {
            return "swi " + imm24;
        }
    }
}
