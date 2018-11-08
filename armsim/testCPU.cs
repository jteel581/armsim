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
            //f.Show();
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

            // these instructions cause the gui to pop up so I commented them out.
            /*
            // mov r1, r13
            int swiTestInstr = -509603827;
            instr = comp.getProcessor().decode(swiTestInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            // mov r2, #50
            swiTestInstr = -476045262;
            instr = comp.getProcessor().decode(swiTestInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);


            // swi 0x6a
            swiTestInstr = -285212566;
            instr = comp.getProcessor().decode(swiTestInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            // test if text was written appropriately
            int val0 = comp.getRAM().ReadWord(comp.getProcessor().getRegisters().getReg(13));
            string testStr = Converter.wordToString(val0);

            int val = comp.getRAM().ReadByte(comp.getProcessor().getRegisters().getReg(13));
            int val2 = comp.getRAM().ReadByte(comp.getProcessor().getRegisters().getReg(13) + 1);
            int val3 = comp.getRAM().ReadByte(comp.getProcessor().getRegisters().getReg(13) + 2);
            int val4 =  comp.getRAM().ReadByte(comp.getProcessor().getRegisters().getReg(13) + 3);
            f.getConsole().Text = Convert.ToString(Convert.ToChar(val));
            f.Update();

            // reg 5 = 100000 (for memory mapped device)
            comp.getRegisters().setReg(5, 0x100000);
            // put val0 (int val for string) into reg 6) 
            comp.getRegisters().setReg(6, val0);

            // str r6, [r5] this should write "i am" to our memory mapped console device
            int strInstr = -444243968;
            instr = comp.getProcessor().decode(strInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            val0 = comp.getRAM().ReadWord(comp.getProcessor().getRegisters().getReg(13) + 4);

            // this should write " gro" to our memory mapped console device
            comp.getRegisters().setReg(6, val0);
            strInstr = -444243968;
            instr = comp.getProcessor().decode(strInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            val0 = comp.getRAM().ReadWord(comp.getProcessor().getRegisters().getReg(13) + 8);

            // this should write "ot\r\0" (not displaying \r\0) to our memory mapped console device
            comp.getRegisters().setReg(6, val0);
            strInstr = -444243968;
            instr = comp.getProcessor().decode(strInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            f.Update();

            f.getConsole().Clear();

            f.Update();

            val0 = comp.getRAM().ReadWord(comp.getProcessor().getRegisters().getReg(13));

            // str r6, [r5] this should write 'i' to our memory mapped console device
            int strbInstr = -440049664;

            comp.getRegisters().setReg(6, val0);
            instr = comp.getProcessor().decode(strbInstr);
            instr.checkConditions(comp.getProcessor());
            instr.insertSuffix();
            comp.getProcessor().execute(instr);

            f.Update();
            */
            


            return true;
        }
    }
}
