// lsInstruction.cs
// This file holds the lsInstruction class which is used to represent load/store
// instructions. It inherits from the Instruciton class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class lsInstruction : Instruction
    {
        // Status of the P bit
        bool pBit;
        // Status of the U bit
        bool uBit;
        // Status of the B bit
        bool bBit;
        // Status of the W bit
        bool wBit;
        // Status of the L bit
        bool lBit;

        // Number of Rn register
        int rN;

        // Number of Rd register
        int rD;
        // offset object used to hold the informaiton in the offset part of the instruction
        Offset os;

        short offsetVal;


        public bool getPbit() { return pBit; }
        public bool getUbit() { return uBit; }
        public bool getBbit() { return bBit; }
        public bool getWbit() { return wBit; }
        public bool getLbit() { return lBit; }
        public int getRn() { return rN; }
        public int getRd() { return rD; }
        public Offset getOs() { return os; }
        public short getOffsetVal() { return offsetVal; }


        /// <summary>
        /// This is the constructor for the lsInstruction class
        /// </summary>
        /// <param name="instVal"></param> is used to instantiate the base instruction class
        public lsInstruction(int instVal) : base(instVal)
        {
            // No psuedo code, but actual code:
            Memory bits = base.getBits();
            pBit = bits.TestFlag(0, 24);
            uBit = bits.TestFlag(0, 23);
            bBit = bits.TestFlag(0, 22);
            wBit = bits.TestFlag(0, 21);
            lBit = bits.TestFlag(0, 20);

            setOps(bits);
            setOffsetVal();

            if (bits.TestFlag(0, 25))
            {
                os = new shiftedRegOffset(offsetVal, bits);
            }
            else
            {
                os = new Offset(offsetVal);
            }

            setInstrStr(ToString());


        }

        /// <summary>
        /// This is used to set number of registers of the operators (Rn, Rd)
        /// </summary>
        /// <param name="bits"></param> is used to provide an easy way to test individual bits
        public void setOps(Memory bits)
        {
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

        public void setOffsetVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getBits();
            for (int i = 11; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            offsetVal = (short)val;
            if (!uBit)
            {
                offsetVal = (short)-offsetVal;
            }
        }

        public override void execute(CPU processor)
        {
            Memory ram = processor.getRAM();
            Memory regs = processor.getRegisters();
            int effectiveAddress = 0;
            int RnVal = regs.getReg(rN);
            int RdVal = regs.getReg(rD);
            if (rN == 15)
            {
                RnVal += 8;
            }
            if (rD == 15)
            {
                RdVal += 8;
            }
            
            // ldr
            if (lBit)
            {
                // ldr (word)
                if (!bBit)
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        int RmVal = regs.getReg(offset.getRm());
                        if (offset.getRm() == 15)
                        {
                            RmVal += 8;
                        }
                        RmVal = takeCareOfShift(offset.getShift(), offset.getShiftType(), RmVal, offset);
                        RnVal = regs.getReg(rN);
                        if (!uBit)
                        {
                            RmVal = -RmVal;
                        }
                        effectiveAddress = RmVal + RnVal;
                        int val = ram.ReadWord(effectiveAddress);
                        regs.setReg(rD, val);
                        string instrStr = "ldr r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                    else
                    {
                        effectiveAddress = RnVal + offsetVal;

                        RnVal = ram.ReadWord(RnVal + offsetVal);
                        regs.setReg(rD, RnVal);
                        string instrStr = "ldr r" + rD + ", [r" + rN + ", " + os.ToString();

                    }
                }
                // ldr (unsigned byte)
                else
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        int RmVal = regs.getReg(offset.getRm());
                        if (offset.getRm() == 15)
                        {
                            RmVal += 8;
                        }
                        RmVal = takeCareOfShift(offset.getShift(), offset.getShiftType(), RmVal, offset);
                        RnVal = regs.getReg(rN);
                        if (!uBit)
                        {
                            RmVal = -RmVal;
                        }
                        effectiveAddress = RmVal + RnVal;
                        int val = ram.ReadByte(effectiveAddress);
                        regs.setReg(rD, val);
                        
                        string instrStr = "ldrb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);

                    }
                    else
                    {
                        RnVal = ram.ReadByte(RnVal + offsetVal);
                        regs.setReg(rD, RnVal);
                        effectiveAddress = RnVal + offsetVal;
                        string instrStr = "ldrb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
            }
            // str
            else
            {
                // str (word)
                if (!bBit)
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        int RmVal = regs.getReg(offset.getRm());
                        if (offset.getRm() == 15)
                        {
                            RmVal += 8;
                        }
                        RmVal = takeCareOfShift(offset.getShift(), offset.getShiftType(), RmVal, offset);
                        RnVal = regs.getReg(rN);
                        if (!uBit)
                        {
                            RmVal = -RmVal;
                        }
                        ram.WriteWord(RmVal + RnVal, RdVal);
                        effectiveAddress = RmVal + RnVal;
                        string instrStr = "str r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                    else
                    {
                        ram.WriteWord(RnVal + offsetVal, RdVal);
                        effectiveAddress = RnVal + offsetVal;
                        string instrStr = "str r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
                // str (unsigned byte)
                else
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        int RmVal = regs.getReg(offset.getRm());
                        if (offset.getRm() == 15)
                        {
                            RmVal += 8;
                        }
                        RmVal = takeCareOfShift(offset.getShift(), offset.getShiftType(), RmVal, offset);
                        RnVal = regs.getReg(rN);
                        if (!uBit)
                        {
                            RmVal = -RmVal;
                        }
                        effectiveAddress = RmVal + RnVal;
                        byte bRdVal = regs.ReadByte(rD * 4);
                        if (rD == 15)
                        {
                            bRdVal += 8;
                        }
                        ram.WriteByte(effectiveAddress, bRdVal);
                        string instrStr = "strb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);

                    }
                    else
                    {
                        byte bRdVal = regs.ReadByte(rD * 4);
                        if (rD == 15)
                        {
                            bRdVal += 8;
                        }
                        ram.WriteByte(RnVal + offsetVal, bRdVal);
                        effectiveAddress = RnVal + offsetVal;
                        string instrStr = "strb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
            }
            if (wBit)
            {
                regs.setReg(rN, effectiveAddress);
                string instrStr = base.getInstrStr();
                instrStr += "!";
                setInstrStr(instrStr);
            }

        }



        public int takeCareOfShift(int shift, int shiftType, int RmVal, shiftedRegOffset offset)
        {
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

                        RmVal = offset.rotateRmRight(shift, RmVal);

                        break;

                }
            }
            return RmVal;
        }

        public override string ToString()
        {
            string instrStr = "";
            // ldr
            if (lBit)
            {
                // ldr (word)
                if (!bBit)
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        
                        instrStr = "ldr r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                    else
                    {
                        
                        instrStr = "ldr r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
                // ldr (unsigned byte)
                else
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        
                        instrStr = "ldrb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);

                    }
                    else
                    {
                        
                        instrStr = "ldrb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
            }
            // str
            else
            {
                // str (word)
                if (!bBit)
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                       
                        instrStr = "str r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                    else
                    {
                        
                        instrStr = "str r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
                // str (unsigned byte)
                else
                {
                    if (os is shiftedRegOffset)
                    {
                        shiftedRegOffset offset = (shiftedRegOffset)os;
                        
                        instrStr = "strb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);

                    }
                    else
                    {
                       
                        instrStr = "strb r" + rD + ", [r" + rN + ", " + os.ToString();
                        base.setInstrStr(instrStr);
                    }
                }
            }
            return instrStr;
        }
    }
}
