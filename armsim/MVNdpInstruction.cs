using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class MVNdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;

        public MVNdpInstruction(int instVal) : base(instVal, true)
        {
            base.setSpecific(true);
            specificInstr = null;
        }

        public override void execute(CPU processor)
        {
            if (base.getOp2() is imOp2)
            {
                // rd = (not) immediate rotated right by alignment val*2
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                int rotVal = operand2.getAlignmentVal();
                int immediate = operand2.getImmediateVal();
                immediate = operand2.rotateRight(rotVal, immediate);
                immediate = ~immediate;
                Memory regs = processor.getRegisters();
                regs.setReg(rD, immediate);

                
            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // rd = (not) rM shifted by shiftVal with a shift of shiftType
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD();
                int rM = operand2.getRm();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                int RmVal = regs.getReg(rM);
                if (rM == 15)
                {
                    RmVal += 8;
                }
                int shiftType = operand2.getShiftTypeVal();
                int shift = operand2.getShiftVal();
                RmVal = takeCareOfShift(shift, shiftType, RmVal, operand2);
                RmVal = ~RmVal;
                regs.setReg(rD, RmVal);


            }
            else if (base.getOp2() is shiftByRegOp2)
            {
                // rD = (not) rM shifted by rS with a shift of shiftType applied to it
                shiftByRegOp2 operand2 = (shiftByRegOp2)base.getOp2();
                int rD = base.getrD();
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
                RmVal = ~RmVal;
                regs.setReg(rD, RmVal);
            }
            else
            {
                // error
            }
        }
        public override string ToString()
        {
            string instrStr = "mvn ";
            string rD = "r" + base.getrD().ToString();
            instrStr += rD;
            Operand2 op2 = getOp2();

            instrStr += op2.ToString();
            return instrStr;
        }
    }
}
