﻿using System;
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
            Form1 f = new Form1();
            Computer jteel = new Computer(32768, f);
            jteel.getRAM().memory[0] = 1;
            Debug.Assert(jteel.getProcessor().getRAM().memory[0] == 1);
            jteel.getProcessor().getRAM().memory[1] = 1;
            Debug.Assert(jteel.getRAM().memory[1] == 1);
            return true;
        }
    }
}
