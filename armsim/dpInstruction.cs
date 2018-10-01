using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class dpInstruction : Instruction
    {
        int opCodeVal;
        bool sBit;
        int rN;
        int rD;
        short op2Val;
        bool isSpecific = false;
        public void setSpecific(bool b) { isSpecific = b; }
        dpInstruction specificInstr;

        Operand2 op2;

        public dpInstruction getSpecificInstr() { return specificInstr; }
        public bool getSBit() { return sBit; }
        public int getrN() { return rN; }
        public int getrD() { return rD; }
        public short getOp2Val() { return op2Val; }
        public Operand2 getOp2() { return op2; }
        public dpInstruction(uint instVal, bool specific): base(instVal)
        {
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
            if (!isSpecific)
            {
                switch (opCodeVal)
                {
                    case 13:
                        specificInstr = new MOVdpInstruction(instVal);
                        specificInstr.setSpecific(true);
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

        public void setOp2Val()
        {
            int val = 0;
            Memory bits = base.getBits();
            for (int i = 11; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            op2Val = (short)val;
        }

    }
}
