// MOVdpInstruction.cs
// This file holds the MOVdpInstruction class which inherits from the dpInstruction class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class MOVdpInstruction : dpInstruction
    {

        // Since MOVdpInstruction doesnt need a specific instruction I declare it here again and set it to null later
        public dpInstruction specificInstr;

        /// <summary>
        /// This is the constructor for the MOVdpInstruction class
        /// </summary>
        /// <param name="instVal"></param> is used to instantiate the base Instruction object
        public MOVdpInstruction(uint instVal): base(instVal, true)
        {
            // No psuedo code, but actual code:

            base.setSpecific(true);
            specificInstr = null;
        }

        /// <summary>
        /// This is ues to execute the specific decoded instruction
        /// </summary>
        /// <param name="processor"></param> is used to provide easy access to RAM and Registers
        public override void execute(CPU processor)
        {
            // No psuedo code, but actual code:
            // I need 3 different branches here, one for each type of operand2
            if (base.getOp2() is imOp2)
            {
                byte immVal = (byte)base.getOp2().getImmediateVal();
                int rD = base.getrD() * 4;
                Memory regs = processor.getRegisters();
                imOp2 operand2 = (imOp2)base.getOp2();
                int rotVal = operand2.getAlignmentVal();
                operand2.rotateRight(rotVal);
                regs.WriteByte(rD, immVal);
            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // ask dr schaub about differences in MOV instructions
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD() * 4;
                int rM = operand2.getRm() * 4;
                int shiftVal = operand2.getShiftValForMOV();

            }
            

        }
        /// <summary>
        /// This is used to convert the decoded instruction to a string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // No psuedo code, but actual code:
            // add different branches for the different types of op2s
            return "mov r" + base.getrD() + ", #" + base.getOp2().getImmediateVal();
        }

    }
}
