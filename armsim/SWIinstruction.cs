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
            base.setInstrStr(ToString());

        }

        public override void execute(CPU processor)
        {
            switch (imm24)
            {
                case 0:
                    // putchar
                    char r0Char = Convert.ToChar(processor.getRegisters().getReg(0));
                    processor.GetComputer().getForm1().writeCharToConsole(r0Char);
                    break;
                case 17:
                    // halt
                    processor.GetComputer().getForm1().clickStopButton();
                    break;
                case 106:
                    // readline

                    break;
            }
        }

        public override string ToString()
        {
            return "swi " + imm24;
        }
    }
}
