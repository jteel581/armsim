// Operand2.cs
// This file holds the operand2 class which is the base class for all types of operand2 and it holds
// information regarding operand 2 objects in general
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Operand2
    {
        // This is the byte array that stores the operand2 bytes
        Memory op2Array;

        // This is a getter that must be overridden by an inherited class
        public virtual int getImmediateVal()
        {
            return 0;
        }

        /// <summary>
        /// This is the constructor of the Operand2 class
        /// </summary>
        /// <param name="op2Val"></param> is used to fill the op2Array with the encoded operand2
        public Operand2(short op2Val)
        {
            // No psuedo code, but actual code:

            op2Array = new Memory(4);
            op2Array.WriteHalfWord(0, op2Val);
        }

        // This is a getter for the op2Array memory object
        public Memory getOp2Array() { return op2Array; }

        public int rotateRight(int rotVal, int curVal)
        {
            int num = (curVal >> rotVal * 2) | (curVal << (32 - rotVal * 2));
            return num;
        }
        public int rotateRmRight(int rotVal, int curVal)
        {
            int num = (curVal >> rotVal) | (curVal << (32 - rotVal));
            return num;
        }

        public override string ToString()
        {

            return base.ToString();
        }

    }
}
