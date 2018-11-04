// dpInstruction.cs
// This file contains the dpInstruction class which inherits from the Instruction class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class dpInstruction : Instruction
    {
        // The numeric opcode value
        int opCodeVal;
        // The condition of the S bit
        bool sBit;
        // The Rn register number
        int rN;
        // The Rd register number
        int rD;
        // The value of the operand 2 bits
        short op2Val;
        // A boolean used to stop infinite recursion since this instrction also includes an instance of
        // another dpInstrucion that is the specific instruction which inherits from dpInstruction
        bool isSpecific = false;
        // A setter method for the specific variable
        public void setSpecific(bool b) { isSpecific = b; }
        // The specific instruction (MOV, ADD, LDR, ect...)
        dpInstruction specificInstr;
        
        // An operand 2 object used to hold the different values operand 2 can hold
        Operand2 op2;


        // Getter methods
        public dpInstruction getSpecificInstr() { return specificInstr; }
        public bool getSBit() { return sBit; }
        public int getrN() { return rN; }
        public int getrD() { return rD; }
        public short getOp2Val() { return op2Val; }
        public Operand2 getOp2() { return op2; }

        /// <summary>
        /// This is the constructor for the dpInstruction class.
        /// </summary>
        /// <param name="instVal"></param> is used by the base instruction class to instantiate the instruction 
        /// object.
        /// <param name="specific"></param> is used to determine whether or not this is a specific or general
        /// instance of the dpInstruction class
        public dpInstruction(int instVal, bool specific): base(instVal)
        {
            // No psuedo code, but actual code:
            setSpecific(specific);
            Memory bits = base.getBits();
            opCodeVal = 0;
            opCodeVal += bits.TestFlag(0, 24) ? 8 : 0;
            opCodeVal += bits.TestFlag(0, 23) ? 4 : 0;
            opCodeVal += bits.TestFlag(0, 22) ? 2 : 0;
            opCodeVal += bits.TestFlag(0, 21) ? 1 : 0;
            sBit = bits.TestFlag(0, 20) ? true : false;
                     

            setOps(bits);
            setOp2Val();

            if ( bits.TestFlag(0, 25))
            {
                op2 = new imOp2(op2Val);
            }
            else
            {
                if (!bits.TestFlag(0, 4))
                {
                    op2 = new shiftByValOp2(op2Val);
                }
                else if (bits.TestFlag(0,4))
                {
                    op2 = new shiftByRegOp2(op2Val);
                }
            }
            if (!isSpecific)
            {
                switch (opCodeVal)
                {
                    case 0:
                        specificInstr = new ANDdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 1:
                        specificInstr = new EORdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 2:
                        specificInstr = new SUBdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 3:
                        specificInstr = new RSBdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 4:
                        specificInstr = new ADDdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 10:
                        specificInstr = new CMPdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 12:
                        specificInstr = new ORRdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 13:
                        specificInstr = new MOVdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 14:
                        specificInstr = new BICdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    case 15:
                        specificInstr = new MVNdpInstruction(instVal);
                        specificInstr.setSpecific(true);
                        base.setInstrStr(specificInstr.ToString());
                        break;
                    default:
                        specificInstr = null;
                        break;

                }
            }
            else
            {
                specificInstr = null;
            }
            


        }


        /// <summary>
        /// This method is used to set the values of the operators (Rn and Rd) in the instruction
        /// </summary>
        /// <param name="bits"></param> is used to provide an easy way to test each individual bit.
        public void setOps(Memory bits)
        {
            // No psuedo code, but actual code:

            rN = 0;
            rN += bits.TestFlag(0, 19) ? 8 : 0;
            rN += bits.TestFlag(0, 18) ? 4 : 0;
            rN += bits.TestFlag(0, 17) ? 2 : 0;
            rN += bits.TestFlag(0, 16) ? 1 : 0;

            rD = 0;
            rD += bits.TestFlag(0, 15) ? 8 : 0;
            rD += bits.TestFlag(0, 14) ? 4 : 0;
            rD += bits.TestFlag(0, 13) ? 2 : 0;
            rD += bits.TestFlag(0, 12) ? 1 : 0;
        }

        /// <summary>
        /// This is used to get the numeric value of the operand 2 bits and set it to the op2Val instance variable
        /// </summary>
        public void setOp2Val()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getBits();
            for (int i = 11; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            op2Val = (short)val;
        }

        public int takeCareOfShift(int shift, int shiftType, int RmVal, Operand2 op2)
        {
            Operand2 operand2;
            if (op2 is imOp2)
            {
                operand2 = (imOp2)op2;
            }
            else if (op2 is shiftByValOp2)
            {
                operand2 = (shiftByValOp2)op2;
            }
            else
            {
                operand2 = (shiftByRegOp2)op2;
            }

            uint uRmVal = (uint)RmVal;
            if (shift != 0)
            {
                switch (shiftType)
                {
                    case 0: // lsl
                        RmVal = (int)(uRmVal << shift);
                        break;
                    case 1: // lsr
                        RmVal = (int)(uRmVal >> shift);
                        break;
                    case 2: // asr
                        RmVal = RmVal >> shift;
                        break;
                    case 3: // ror 

                        RmVal = operand2.rotateRmRight(shift, RmVal);

                        break;

                }
            }
            return RmVal;
        }

        public virtual byte calcCPSRVal(int op1, int op2)
        {
            // this method only exists to be overridden 
            byte cpsrVal = 0;

            return cpsrVal;
        }

        public override string ToString()
        {
            dpInstruction dpi = getSpecificInstr();
            if (dpi == null)
            {
                return "<instruction not supported>";
            }
            return dpi.ToString();
        }
    }
}
