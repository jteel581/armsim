using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class bxInstruction : Instruction
    {
        int rM;
        int rmVal;
        bool thumbMode;
        public bxInstruction(int instVal) : base(instVal)
        {
            Memory bits = base.getBits();
            rM = Memory.ExtractBits(instVal, 0, 3);
            rmVal = 0;
            thumbMode = false;
        }

        public override void execute(CPU processor)
        {
            int oldPC = processor.getRegisters().getReg(15);
            rmVal = processor.getRegisters().getReg(rM);
            thumbMode = (rmVal % 2 == 0) ? false : true;
            // subtract four to account for incrementing of PC during fetch decode execute 
            processor.getRegisters().setReg(15, rmVal - 4);
            Tracer.bPc = (oldPC).ToString("x8").ToUpper();
            Tracer.branchInstr = true;
        }

        public override string ToString()
        {
            string instrStr = "bx r"+ rM;
            return instrStr;

        }
    }
}
