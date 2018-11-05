// Instruction.cs
// This file holds the instruction class which is the base class for all instruction types
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Instruction
    {
        // The byte array that stores the coded instruction
        Memory bits;
        // Status of the N Flag
        bool nFlag;
        // Status of the Z flag
        bool zFlag;
        // Status of the C flag
        bool cFlag;
        // Status of the V flag
        bool vFlag;

        string suffix = "";

        public string getSuffix()
        {
            return suffix;
        }
        public void setSuffix(string suff)
        {

            suffix = suff;
        }

        public bool getNflag() { return nFlag; }
        public bool getZflag() { return zFlag; }
        public bool getCflag() { return cFlag; }
        public bool getVflag() { return vFlag; }

        // A number used to determine whether the instruction is data processing, load store, or branch
        uint type;
        // the string representation of the decoded instruction
        string instrStr;

        public void setInstrStr(string newStr)
        {
            instrStr = newStr;

        }

        /// <summary>
        /// This is the constructor for the instruction class
        /// </summary>
        /// <param name="instVal"></param> is used to populate the byte array with the encoded instruction
        public Instruction(int instVal)
        {
            // No psuedo code, but actual code:

            bits = new Memory(4);
            bits.WriteWord(0, instVal);
            nFlag = bits.TestFlag(0, 31) ? true : false;
            zFlag = bits.TestFlag(0, 30) ? true : false;
            cFlag = bits.TestFlag(0, 29) ? true : false;
            vFlag = bits.TestFlag(0, 28) ? true : false;
            type = bits.ReadByte(3);
            type = type << 4;
            type = type >> 5;
            instrStr = "";
        
        }

        public bool checkConditions(CPU processor)
        {

            bool nFlag, zFlag, cFlag, vFlag = false;
            processor.getCPSR().getFlags(out nFlag, out zFlag, out cFlag, out vFlag);
            int code = 0;
            code += getNflag() ? 8 : 0;
            code += getZflag() ? 4 : 0;
            code += getCflag() ? 2 : 0;
            code += getVflag() ? 1 : 0;

            switch (code)
            {
                case 0:
                    this.setSuffix("eq");
                    return zFlag ? true : false;
                case 1:
                    this.setSuffix("ne");
                    return !zFlag ? true : false;
                case 2:
                    this.setSuffix("cs/hs");
                    return cFlag ? true : false;
                case 3:
                    this.setSuffix("cc/lo");
                    return !cFlag ? true : false;
                case 4:
                    this.setSuffix("mi");
                    return nFlag ? true : false;
                case 5:
                    this.setSuffix("pl");
                    return !nFlag ? true : false;
                case 6:
                    this.setSuffix("vs");
                    return vFlag ? true : false;
                case 7:
                    this.setSuffix("vc");
                    return !vFlag ? true : false;
                case 8:
                    this.setSuffix("hi");
                    return (cFlag && !zFlag) ? true : false;
                case 9:
                    this.setSuffix("ls");
                    return (!cFlag || zFlag) ? true : false;
                case 10:
                    this.setSuffix("ge");
                    return (nFlag == vFlag) ? true : false;
                case 11:
                    this.setSuffix("lt");
                    return (nFlag != vFlag) ? true : false;
                case 12:
                    this.setSuffix("gt");
                    return (!zFlag && (nFlag == vFlag)) ? true : false;
                case 13:
                    this.setSuffix("le");
                    return (zFlag || (nFlag != vFlag)) ? true : false;
                case 14:
                    this.setSuffix("al");
                    return true;
            }
            return false;
        }
        public virtual void execute(CPU processor)
        {
            // this method exists only to be overridden
        }
        // This is a getter method for the bits memory instance
        public Memory getBits() { return bits; }

        // This is a gettter method for the instrStr 
        public string getInstrStr()
        {
            return instrStr;
        }
        public string insertSuffix()
        {
            string curStr = this.getInstrStr();
            int index = curStr.IndexOf(' ');
            if (index == -1)
            {
                return curStr;
            }
            curStr = curStr.Insert(index, suffix);
            return curStr;

        }
    }
}
