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
            // set up RAM
            RAM memory = new RAM(4);
            memory.WriteByte(0, 0x00);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x01);

            // Tests for TestFlag
            // test flag known to be 1
            bool b = memory.TestFlag(0, 0);
            Debug.Assert(b == true);
            // test flag known to be 0
            b = memory.TestFlag(0, 31);
            Debug.Assert(b == false);

            // set up new RAM values and test WriteByte
            memory.WriteByte(0, 0x01);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x00);

            // test flag known to be 1
            b = memory.TestFlag(0, 24);
            Debug.Assert(b == true);
            // test flag known to be 0
            b = memory.TestFlag(0, 0);
            Debug.Assert(b == false);

            // Tests for SetFlag and therefore also ReadWord and WriteWord/WriteHalfWord/WriteByte
            memory.SetFlag(0, 24, false);
            Debug.Assert(memory.ReadWord(0) == 0);

            // Tests for readHalfWord
            memory.WriteByte(0, 0x01);
            memory.WriteByte(1, 0x02);

            Debug.Assert(memory.ReadHalfWord(0) == 258);

            // Test for WriteHalfWord
            memory.WriteHalfWord(2, 258);
            Debug.Assert(memory.ReadByte(2) == 0x01);
            return true;
        }
        
    }
}
