using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Offset
    {
        Memory offsetArray;

        public Offset(short offsetVal)
        {
            offsetArray = new Memory(2);
            offsetArray.WriteWord(0, (uint)offsetVal);
        }
        public Memory getOffsetArray() { return offsetArray; }
    }
}
