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
        bool isSpecific = false;
        public void setSpecific(bool b) { isSpecific = b; }


        lsInstruction specificInstr;
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
        public lsInstruction(int instVal, bool specific) : base(instVal)
        {
            // No psuedo code, but actual code:
            setSpecific(specific);
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
                os = new shiftedRegOffset(offsetVal);
            }


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
                        RnVal = ram.ReadWord(RmVal);
                        regs.setReg(rD, RnVal);
                        effectiveAddress = RmVal;
                    }
                    else
                    {
                        RnVal = ram.ReadWord(RnVal + offsetVal);
                        regs.setReg(rD, RnVal);
                        effectiveAddress = RnVal + offsetVal;
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
                        RnVal = ram.ReadByte(RmVal);
                        regs.setReg(rD, RnVal);
                        effectiveAddress = RmVal;

                    }
                    else
                    {
                        RnVal = ram.ReadByte(RnVal + offsetVal);
                        regs.setReg(rD, RnVal);
                        effectiveAddress = RnVal + offsetVal;
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
                        ram.WriteWord(RmVal, RdVal);
                        effectiveAddress = RmVal;
                    }
                    else
                    {
                        ram.WriteWord(RnVal + offsetVal, RdVal);
                        effectiveAddress = RnVal + offsetVal;
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
                        byte bRdVal = regs.ReadByte(rD * 4);
                        if (rD == 15)
                        {
                            bRdVal += 8;
                        }
                        ram.WriteByte(RmVal, bRdVal);
                        effectiveAddress = RmVal;

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
                    }
                }
            }
            if (wBit)
            {
                regs.setReg(rN, effectiveAddress);
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
    }
}
