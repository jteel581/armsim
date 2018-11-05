// testCPU.cs
// This file holds the unit tests for the CPU class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace armsim
{
    class testCPU
    {

        public static bool runTests()
        {

            Form1 f = new Form1();

            Computer comp = new Computer(32768, f);

            comp.getRAM().WriteWord(0, 123);
            comp.getRegisters().WriteWord(60, 0);
            int num = comp.getProcessor().fetch();
            Debug.Assert(num == 123);

            // Tests to make sure register holds 0 before the mov operation
            Debug.Assert(comp.getRegisters().ReadWord(8) == 0);

            // tests dpInstruction decode and execute
            int  j = -476045264;
            // decodes the instruction 0xe3a02030 from the design requirements page
            var instr = comp.getProcessor().decode(j);
            instr.checkConditions(comp.getProcessor());

            instr.insertSuffix();
            string instrStr = instr.getInstrStr();
            string compStr = "mov r2, #48";
            Debug.Assert(instrStr == compStr);
            // executes the instruction
            comp.getProcessor().execute(instr);

            // Tests that the new value of the register is 48
            Debug.Assert(comp.getRegisters().ReadWord(8) == 48);


            // tests lsInstruction decode
            j = -444256240;
            instr = comp.getProcessor().decode(j);
            instrStr = instr.getInstrStr();
            compStr = "str r3, [r5, #16]";
            Debug.Assert(instrStr == compStr);








            return true;
        }
    }
}
