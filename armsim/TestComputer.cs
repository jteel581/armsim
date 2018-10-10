using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace armsim
{
    class TestComputer
    {
        public static bool runTests(Options ops)
        {
            Form1 f = new Form1();
            
            Computer comp = new Computer(32768, f);
            comp.getRAM().memory[0] = 1;
            Debug.Assert(comp.getProcessor().getRAM().memory[0] == 1);
            comp.getProcessor().getRAM().memory[1] = 1;
            Debug.Assert(comp.getRAM().memory[1] == 1);


            for (int i = 0; i < 15; i++)
            {
                comp.getRegisters().WriteWord(i * 4, i);
            }
            string correctStr = "r0 \t= 00000000\r\nr1 \t= 00000001\r\nr2 \t= 00000002\r\nr3 \t= 00000003\r\nr4 \t= 00000004\r\nr5 \t= 00000005\r\nr6 \t= 00000006\r\nr7 \t= 00000007\r\nr8 \t= 00000008\r\nr9 \t= 00000009\r\nr10 \t= 0000000a\r\nr11 \t= 0000000b\r\nr12 \t= 0000000c\r\nr13 \t= 0000000d\r\nr14 \t= 0000000e\r\nr15 \t= 00000000\r\n";
            Debug.Assert(correctStr == comp.printRegs());

            int reg1Val = comp.getRegisters().getReg(1);
            Debug.Assert(reg1Val == 1);

            comp.reset(32768);
            reg1Val = comp.getRegisters().getReg(1);
            Debug.Assert(reg1Val == 0);

            Debug.Assert(comp.getRAM().ReadWord(comp.getProcessor().getProgramCounter()) == 0);
            string fileName = ops.getFileName();
            string newFileName = "test2.exe";
            ops.setFileName(newFileName);
            /*
            comp.load(f, ops);
            
            Debug.Assert(comp.getRAM().ReadWord(comp.getProcessor().getProgramCounter()) != 0);
            Debug.Assert(comp.getRAM().calculateChecksum(comp.getRAM().memory) == 536864433);
            */
            ops.setFileName(fileName);

            /*
            comp.load(f, ops);
            comp.run();
            int pc = comp.getRegisters().getReg(15);
            Debug.Assert(comp.getRAM().ReadWord(pc) == 0);
            comp.reset(32768);
            comp.load(f, ops);
            int num = comp.getRegisters().getReg(15);
            comp.step();
            int newNum = comp.getRegisters().getReg(15);
            Debug.Assert(num == newNum - 4);
            */










            return true;
        }
    }
}
