using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace armsim
{
    class TestRAM
    {
        public static bool runTests()
        {
            RAM memory = new RAM(4);
            memory.WriteByte(0, 0x00);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x01);
            bool b = memory.TestFlag(0, 0);
            Debug.Assert(b == true);
            b = memory.TestFlag(0, 31);
            Debug.Assert(b == false);
            memory.WriteByte(0, 0x01);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x00);
            b = memory.TestFlag(0, 24);
            Debug.Assert(b == true);
            b = memory.TestFlag(0, 0);
            Debug.Assert(b == false);
            return true;
        }
        
    }
}
