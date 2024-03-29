﻿// Offset.cs
// This file holds the Offset class which is the base class for another type of offset class and 
// it holds information about the offset of a given load store instruction.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Offset
    {
        // the byte array that holds the offset portion of the encoded instruction
        Memory offsetArray;
        public int offset;
        /// <summary>
        /// This is the constructor for the Offset class
        /// </summary>
        /// <param name="offsetVal"></param> is used to fill the offset array with the encoded offset
        public Offset(short offsetVal)
        {
            // No psuedo code, but actual code:

            offsetArray = new Memory(2);
            offsetArray.WriteWord(0, offsetVal);
            offset = offsetVal;
        }

        // This is a getter for the offsetArray Variable
        public Memory getOffsetArray() { return offsetArray; }

        public int rotateRmRight(int rotVal, int curVal)
        {
            int num = (curVal >> rotVal) | (curVal << (32 - rotVal));
            return num;
        }

        public override string ToString()
        {
            string osStr = "";
            osStr += "#" + offset + "]";
            return osStr;
        }
    }
}
