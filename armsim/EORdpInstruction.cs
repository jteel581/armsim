﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class EORdpInstruction : dpInstruction
    {
        public dpInstruction specificInstr;

        public EORdpInstruction(int instVal) : base(instVal, true)
        {
            base.setSpecific(true);
            specificInstr = null;
        }

        public override void execute(CPU processor)
        {
            //byte cpsrVal = 0;
            // check different op2 types
            if (base.getOp2() is imOp2)
            {
                // rd = rn AND immediate rotated right by alignment val*2
                imOp2 operand2 = (imOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rotVal = operand2.getAlignmentVal();
                int immediate = operand2.getImmediateVal();
                immediate = operand2.rotateRight(rotVal, immediate);
                Memory regs = processor.getRegisters();
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, RnVal ^ immediate);

                //cpsrVal = calcCPSRVal(RnVal, immediate);
            }
            else if (base.getOp2() is shiftByValOp2)
            {
                // rd = rn AND rm shifted by shift num with a shift of type shiftType
                shiftByValOp2 operand2 = (shiftByValOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
                int rM = operand2.getRm();
                Memory regs = processor.getRegisters();
                Memory bits = processor.getRAM();
                int RnVal = regs.getReg(rN);
                int RmVal = regs.getReg(rM);
                if (rM == 15)
                {
                    RmVal += 8;
                }
                int shiftType = operand2.getShiftTypeVal();
                int shift = operand2.getShiftVal();
                //uint uRmVal;

                RmVal = takeCareOfShift(shift, shiftType, RmVal, operand2);

                regs.setReg(rD, RnVal ^ RmVal);
                //cpsrVal = calcCPSRVal(RnVal, RmVal);

            }
            else if (base.getOp2() is shiftByRegOp2)
            {
                // rd = rN AND rM shifted by rS with a shift of shiftType
                shiftByRegOp2 operand2 = (shiftByRegOp2)base.getOp2();
                int rD = base.getrD();
                int rN = base.getrN();
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
                int RnVal = regs.getReg(rN);
                regs.setReg(rD, RnVal ^ RmVal);
                //cpsrVal = calcCPSRVal(RnVal, RmVal);


            }
            else
            {
                // error
            }
            //processor.setCPSR(cpsrVal);
        }


        public override byte calcCPSRVal(int op1, int op2)
        {
            byte cpsrVal = 0;
            // sets N flag
            if ((op1 ^ op2) < 0)
            {
                cpsrVal += 8;
            }
            // sets Z flag
            if ((op1 ^ op2) == 0)
            {
                cpsrVal += 4;
            }
            // sets C flag
            if ((op1 ^ op2) > 0xFFFF)
            {
                cpsrVal += 2;
            }
            // sets V flag
            if ((op1 ^ op2) > 0x7FFF)
            {
                cpsrVal += 1;
            }
            return cpsrVal;
        }

        public override string ToString()
        {
            string instrStr = "eor ";
            string rD = "r" + base.getrD().ToString();
            string rN = "r" + base.getrN().ToString();
            instrStr += rD + ", " + rN;
            Operand2 op2 = getOp2();

            instrStr += op2.ToString();
            return instrStr;
        }
    }
}
