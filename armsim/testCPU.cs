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


            Debug.Assert(comp.getRegisters().ReadWord(8) == 0);
            var instr = comp.getProcessor().decode(0xe3a02030);

            comp.getProcessor().execute(instr);

            Debug.Assert(comp.getRegisters().ReadWord(8) == 48);


            if (instr is dpInstruction)
            {
                dpInstruction dpi = (dpInstruction)instr;
            }
            else
            {
                lsInstruction lsI = (lsInstruction)instr;
            }

            // decode and execute do nothing for now


            return true;
        }
    }
}
