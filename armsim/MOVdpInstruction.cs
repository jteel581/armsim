using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class MOVdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;
        public MOVdpInstruction(uint instVal): base(instVal, true)
        {
            base.setSpecific(true);
            specificInstr = null;
        }
        public override void execute(CPU processor)
        {
            byte immVal = (byte)base.getOp2().getImmediateVal();
            int rD = base.getrD() * 4;
            Memory regs = processor.getRegisters();
            regs.WriteByte(rD, immVal);

        }
        public string toString()
        {
            return "mov r" + base.getrD() + ", #" + base.getOp2().getImmediateVal();
        }

    }
}
