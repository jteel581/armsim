// TestRAM.cs
// This file holds unit tests to test the RAM class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace armsim
{
    // This class is used to test the RAM class. It performs tests on each method in the RAM class
    // with the exception of getter and setter methods.
    class TestRAM
    {
        // This is a static method that can be called to run the unit tests on the RAM class. It returns 
        // true if all the tests are passed.
        public static bool runTests()
        {
            // set up RAM
            Options ops = new Options(System.Environment.GetCommandLineArgs());
            if (ops.log)
            {
                Trace.WriteLine("Loader: TestRAM is setting up RAM to test methods...");

            }
            Memory memory = new Memory(4);
            memory.WriteByte(0, 0x00);
            memory.WriteByte(1, 0x00);
            memory.WriteByte(2, 0x00);
            memory.WriteByte(3, 0x01);
            if (ops.log)
            {
                Trace.WriteLine("Loader: TestRAM is testing WriteByte...");

            }
            Debug.Assert(memory.memory[3] == 0x01);
            if (ops.log)
            {
                Trace.WriteLine("Loader: WriteByte test passed!");

                Trace.WriteLine("Loader: TestRAM is testing ReadByte...");
            }
            
            Debug.Assert(memory.ReadByte(3) == 0x01);
            if (ops.log)
            {
                Trace.WriteLine("Loader: ReadByte test passed!");
               
                Trace.WriteLine("Loader: TestRAM is testing TestFlag...");
            }
            // Tests for TestFlag
            // test flag known to be 1
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
            if (ops.log)
            {
                Trace.WriteLine("Loader: TestFlag tests passed!");


                Trace.WriteLine("Loader: TestRAM is testing SetFlag...");
            }
            
            // Tests for SetFlag and therefore also ReadWord and WriteWord/WriteHalfWord/WriteByte
            memory.SetFlag(0, 0, false);
            Debug.Assert(memory.ReadByte(0) == 0);
            if (ops.log)
            {
                Trace.WriteLine("Loader: SetFlag test passed!");
                Trace.WriteLine("Loader: TestRAM is testing ReadWord...");
            }
            
            Debug.Assert(memory.ReadWord(0) == 0);
            if (ops.log)
            {
                Trace.WriteLine("Loader: ReadWord test passed!");

                Trace.WriteLine("Loader: TestRAM is testing WriteWord...");
            }
            
            memory.WriteWord(0, 67305985);
            Debug.Assert(memory.ReadWord(0) == 67305985);
            if (ops.log)
            {
                Trace.WriteLine("Loader: WriteWord test passed!");

                Trace.WriteLine("Loader: TestRAM is testing ReadHalfWord...");
            }
            

            // Tests for readHalfWord
            memory.WriteByte(0, 0x01);
            memory.WriteByte(1, 0x02);

            Debug.Assert(memory.ReadHalfWord(0) == 513);
            if (ops.log)
            {
                Trace.WriteLine("Loader: ReadHalfWord test passed!");

                Trace.WriteLine("Loader: TestRAM is testing WriteHalfWord...");
            }
            

            // Test for WriteHalfWord
            memory.WriteHalfWord(2, 258);
            Debug.Assert(memory.ReadHalfWord(2) == 258);
            Debug.Assert(memory.ReadByte(2) == 0x02);
            if (ops.log)
            {
                Trace.WriteLine("Loader: WriteHalfWord test passed!");

                Trace.WriteLine("Loader: TestRAM is testing ExtractBits...");
            }
            

            // Test for Extract bits
            Debug.Assert(Memory.ExtractBits(0x00B5, 1, 3) == 0x04);
            if (ops.log)
            {
                Trace.WriteLine("Loader: ExtractBits test passed!");

                Trace.WriteLine("Loader: TestRAM is testing calculateChecksum...");
            }
            
            memory.WriteWord(0, 2214822401);
            Debug.Assert(memory.calculateChecksum(memory.memory) == 268);
            if (ops.log)
            {
                Trace.WriteLine("Loader: calculateChecksum test passed!");

            }

            return true;
        }
        
    }
}
