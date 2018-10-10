using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class RSBdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;

        public RSBdpInstruction(int instVal) : base(instVal, true)
        {
            base.setSpecific(true);

            specificInstr = null;
        }

        public override void execute(CPU processor)
        {
            // check different op2 types
            if (base.getOp2() is imOp2)
            {
                // rd = immediate rotated right by alignment val*2 - rn
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rotVal = operand2.getAlignmentVal();
                int immediate = operand2.getImmediateVal();
                immediate = operand2.rotateRight(rotVal, immediate);
                Memory regs = processor.getRegisters();
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, immediate - RnVal);


            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // rd = rm shifted by shift num with a shift of type shiftType - rn 
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

                regs.setReg(rD, RmVal - RnVal);

            }
            else if (base.getOp2() is shiftByRegOp2)
            {
                // rd = rm shifted by num within rS with a shift of type shiftType - rn

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
                regs.setReg(rD, RmVal - RnVal);


            }
            else
            {
                // error
            }
        }


        public override string ToString()
        {
            string instrStr = "rsb ";
            string rD = "r" + base.getrD().ToString();
            string rN = "r" + base.getrN().ToString();
            instrStr += rD + ", " + rN;
            Operand2 op2 = getOp2();

            instrStr += op2.ToString();
            return instrStr;
        }
    }
}
