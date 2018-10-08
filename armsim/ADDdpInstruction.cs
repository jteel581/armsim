using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class ADDdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;

        public ADDdpInstruction(uint instVal) : base (instVal, true)
        {
            base.setSpecific(true);
            specificInstr = null;
        }

        public override void execute(CPU processor)
        {
            // check different op2 types
            if (base.getOp2() is imOp2)
            {
                // rd = rn + immediate rotated right by alignment val*2
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rotVal = operand2.getAlignmentVal();
                operand2.rotateRight(rotVal);
                int immediate = operand2.getImmediateVal();
                Memory regs = processor.getRegisters();
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, immediate + RnVal);


            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // rd = rn + rm shifted by shift num with a shift of type shiftType
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rM = operand2.getRm();
                Memory regs = processor.getRegisters();

                int RnVal = regs.getReg(rN);
                int RmVal = regs.getReg(rM);

                int shiftType = operand2.getShiftTypeVal();
                int shift = operand2.getShiftVal();
                if (shift != 0)
                {
                    switch (shiftType)
                    {
                        case 0: // lsl

                            break;
                        case 1: // lsr

                            break;
                        case 2: // asr

                            break;
                        case 3: // rsr or rrx

                            break; 

                    }
                }
                else
                {
                    
                    regs.setReg(rD, RnVal + RmVal);
                }
                
                
            }
            else if (base.getOp2() is shiftByRegOp2)
            {

            }
            else
            {
                // error
            }
        }
    }
}
