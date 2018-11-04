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
            if ((getNflag() && getZflag() && getCflag() && !getVflag()) || (nFlag == getNflag() && zFlag == getZflag() && cFlag == getCflag() && vFlag == getVflag()))
            {
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
    }
}
