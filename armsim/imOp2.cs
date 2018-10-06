// imOp2.cs
// This file contains the imOp2 class which inherits from the Operand2 class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class imOp2 : Operand2
    {
        // The value of the alignment bits
        int alignmentVal;
        // The value of the immediate bits
        int immediateVal;
        // An overrided version of the getter method for the immediateVal variable.
        public override int  getImmediateVal() { return immediateVal; }
        /// <summary>
        /// This is a constructor for the imOp2 class
        /// </summary>
        /// <param name="op2Val"></param> is used to instantiate the base class Operand2
        public imOp2(short op2Val) : base( op2Val)
        {
            setAlignmentVal();
            setImVal();
        }

        /// <summary>
        /// This method is used to get the nummeric value of the alignment bits and assign it to the 
        /// alignmentVal variable
        /// </summary>
        public void setAlignmentVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 11; i > 7; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i - 8) : 0;
            }
            alignmentVal = val;
        }
        /// <summary>
        /// This method is used to get the value of the immediate bits and assign it to the
        /// immediateVal variable
        /// </summary>
        public void setImVal()
        {
            // No psuedo code, but actual code:

            int val = 0;
            Memory bits = base.getOp2Array();
            for (int i = 7; i > -1; i--)
            {
                val += bits.TestFlag(0, i) ? (int)Math.Pow(2, i) : 0;
            }
            immediateVal = val;
        }
    }
}
