using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Instruction
    {
        Memory bits;
        bool nFlag;
        bool zFlag;
        bool cFlag;
        bool fFlag;
        uint type;
        string instrStr;
        public Instruction(uint instVal)
        {
            bits = new Memory(4);
            bits.WriteWord(0, instVal);
            nFlag = bits.TestFlag(0, 31) ? true : false;
            zFlag = bits.TestFlag(0, 30) ? true : false;
            cFlag = bits.TestFlag(0, 29) ? true : false;
            fFlag = bits.TestFlag(0, 28) ? true : false;
            type = bits.ReadByte(3);
            type = type << 4;
            type = type >> 5;
            instrStr = "";
        }
        public virtual void execute(CPU processor)
        {

        }

        public Memory getBits() { return bits; }
    }
}
