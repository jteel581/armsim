using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class SUBdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;

        public SUBdpInstruction(uint instVal) : base(instVal, true)
        {
            base.setSpecific(true);
            
            specificInstr = null;
        }

        public override void execute(CPU processor)
        {
            // check different op2 types
            if (base.getOp2() is imOp2)
            {
                // rd = rn - immediate rotated right by alignment val*2
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rotVal = operand2.getAlignmentVal();
                int immediate = operand2.getImmediateVal();
                immediate = operand2.rotateRight(rotVal, immediate);
                Memory regs = processor.getRegisters();
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, RnVal - immediate);


            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // rd = rn - rm shifted by shift num with a shift of type shiftType
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rM = operand2.getRm();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                int RnVal = regs.getReg(rN);
                int RmVal = regs.getReg(rM);

                int shiftType = operand2.getShiftTypeVal();
                int shift = operand2.getShiftVal();

                takeCareOfShift(shift, shiftType, RmVal, operand2);
                
                regs.setReg(rD, RnVal - RmVal);

            }
            else if (base.getOp2() is shiftByRegOp2)
            {
                // rd = rn - rm shifted by num within rS with a shift of type shiftType

                shiftByRegOp2 operand2 = (shiftByRegOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rM = operand2.getRm();
                int rS = operand2.getRs();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                int RmVal = regs.getReg(rM);
                int shiftVal = regs.getReg(rS);
                int shiftType = operand2.getShiftTypeVal();
                takeCareOfShift(shiftVal, shiftType, rM, operand2);
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, RnVal - RmVal);


            }
            else
            {
                // error
            }
        }


        public override string ToString()
        {
            string instrStr = "sub ";
            string rD = base.getrD().ToString();
            string rN = base.getrN().ToString();
            instrStr += rD + ", " + rN;
            Operand2 op2 = getOp2();

            instrStr += op2.ToString();
            return instrStr;
        }
    }
}
