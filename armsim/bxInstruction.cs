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
            rmVal = processor.getRAM().getReg(rM);
            thumbMode = (rmVal % 2 == 0) ? false : true;
            // subtract four to account for incrementing of PC during fetch decode execute 
            processor.getRAM().setReg(15, rmVal - 4);
        }

        public override string ToString()
        {
            string instrStr = "bx r"+ rM;
            return instrStr;

        }
    }
}
