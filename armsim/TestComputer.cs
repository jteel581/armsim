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
        public static bool runTests()
        {
            Computer jteel = new Computer(32768);
            jteel.getRAM().memory[0] = 1;
            Debug.Assert(jteel.getProcessor().getRAM().memory[0] == 1);
            jteel.getProcessor().getRAM().memory[1] = 1;
            Debug.Assert(jteel.getRAM().memory[1] == 1);
            return true;
        }
    }
}
