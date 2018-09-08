// TestConverter.cs
// This file contains a class used to test the methods in the Converter class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace armsim
{
    // This class contains a static method to test the Converter class with unit tests.
    class TestConverter
    {
        // This method runs tests on all the methods within the Converter class. If all tests pass,
        // it returns true
        public static bool runTests()
        {
            Options ops = new Options(System.Environment.GetCommandLineArgs());
            if (ops.log)
            {
                Trace.WriteLine("Loader: testConverter is testing wordToShortArray...");

            }
            Debug.Assert(Converter.wordToShortArray(67305985)[0] == 513);
            if (ops.log)
            {
                Trace.WriteLine("Loader: wordToShortArray test passed!");
                Trace.WriteLine("Loader: testConverter is testing halfToByteArray...");
            }
            
            Debug.Assert(Converter.halfToByteArray(513)[0] == 1);
            if (ops.log)
            {
                Trace.WriteLine("Loader: halfToByteArray test passed!");

            }
            return true;
        }
    }
}
