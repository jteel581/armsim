﻿using System;
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
            Trace.WriteLine("Loader: TestRAM is setting up RAM to test methods...");
            RAM memory = new RAM(4);
            memory.WriteByte(0, 0x00);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x01);

            // Tests for TestFlag
            // test flag known to be 1
            Trace.WriteLine("Loader: TestRAM is testing WriteByte and TestFlag...");
            bool b = memory.TestFlag(0, 24);
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
            b = memory.TestFlag(0, 0);
            Debug.Assert(b == true);
            // test flag known to be 0
            b = memory.TestFlag(0, 1);
            Debug.Assert(b == false);
            Trace.WriteLine("Loader: WriteByte and TestFlag tests passed!");


            Trace.WriteLine("Loader: TestRAM is testing SetFlag and ReadWord...");
            // Tests for SetFlag and therefore also ReadWord and WriteWord/WriteHalfWord/WriteByte
            memory.SetFlag(0, 0, false);
            Debug.Assert(memory.ReadWord(0) == 0);
            Trace.WriteLine("Loader: SetFlag and ReadWord test passed!");

            Trace.WriteLine("Loader: TestRAM is testing ReadHalfWord...");

            // Tests for readHalfWord
            memory.WriteByte(0, 0x01);
            memory.WriteByte(1, 0x02);

            Debug.Assert(memory.ReadHalfWord(0) == 513);
            Trace.WriteLine("Loader: ReadHalfWord test passed!");

            Trace.WriteLine("Loader: TestRAM is testing WriteHalfWord...");

            // Test for WriteHalfWord
            memory.WriteHalfWord(2, 258);
            Debug.Assert(memory.ReadByte(2) == 0x01);
            Trace.WriteLine("Loader: WriteHalfWord test passed!");

            Trace.WriteLine("Loader: TestRAM is testing ExtractBits...");

            // Test for Extract bits
            Debug.Assert(RAM.ExtractBits(0x00B5, 1, 3) == 0x04);
            Trace.WriteLine("Loader: ExtractBits test passed!");

            return true;
        }
        
    }
}
