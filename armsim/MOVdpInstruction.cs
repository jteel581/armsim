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
        public MOVdpInstruction(int instVal): base(instVal, true)
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
                // rd = rn + immediate rotated right by alignment val*2
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                //int rN = base.getrN();
                int rotVal = operand2.getAlignmentVal();
                int immediate = operand2.getImmediateVal();
                immediate = operand2.rotateRight(rotVal, immediate);
                Memory regs = processor.getRegisters();
                //int RnVal = regs.getReg(rN);
                regs.setReg(rD, immediate);

                /*
                byte immVal = (byte)base.getOp2().getImmediateVal();
                int rD = base.getrD() * 4;
                Memory regs = processor.getRegisters();
                imOp2 operand2 = (imOp2)base.getOp2();
                int rotVal = operand2.getAlignmentVal();
                operand2.rotateRight(rotVal, operand2.);
                regs.WriteByte(rD, immVal);
                */
            }
            else if (base.getOp2() is shiftByValOp2)
            {
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD();
                //int rN = base.getrN();
                int rM = operand2.getRm();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                //int RnVal = regs.getReg(rN);
                int RmVal = regs.getReg(rM);
                if (rM == 15)
                {
                    RmVal += 8;
                }
                int shiftType = operand2.getShiftTypeVal();
                int shift = operand2.getShiftVal();
                //uint uRmVal;

                RmVal = takeCareOfShift(shift, shiftType, RmVal, operand2);
                
                regs.setReg(rD,  RmVal);

                
            }
            else if (base.getOp2() is shiftByRegOp2)
            {
                shiftByRegOp2 operand2 = (shiftByRegOp2)base.getOp2();
                int rD = base.getrD();
                //int rN = base.getrN();
                int rM = operand2.getRm();
                int rS = operand2.getRs();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                int RmVal = regs.getReg(rM);
                if (rM == 15)
                {
                    RmVal += 8;
                }
                int shiftVal = regs.getReg(rS);
                int shiftType = operand2.getShiftTypeVal();
                RmVal = takeCareOfShift(shiftVal, shiftType, RmVal, operand2);
                //int RnVal = regs.getReg(rN);
                regs.setReg(rD, RmVal);
            }
            else
            {
                // error
            }
            

        }
        /// <summary>
        /// This is used to convert the decoded instruction to a string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string instrStr = "mov ";
            string rD = "r" + base.getrD().ToString();
            instrStr += rD + ", ";
            Operand2 op2 = getOp2();

            instrStr += op2.ToString();
            return instrStr;
        }

    }
}
