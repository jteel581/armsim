// Computer.cs
// This file holds the Computer class which is used as the main simulated computer in this program.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Computer
    {
        Memory RAM;
        Memory Registers;
        CPU Processor;

        public Memory getRAM() { return RAM; }
        public Memory getRegisters() { return Registers; }
        public CPU getProcessor() { return Processor; }
        /// <summary>
        /// This is a constructor for the Computer Class.
        /// </summary>
        /// <param name="ramSize"> is used to define the size of the byte array that our simulator
        /// will use as memory.</param>
        public Computer(int ramSize)
        {
            RAM = new Memory(ramSize);
            Registers = new Memory(15);
            Processor = new CPU(RAM, Registers);
        }

        /// <summary>
        /// This method is used to simulate the fetch, decode, and execute cycle until the value fetched is 0.
        /// </summary>
        public void run()
        {
            while(Processor.fetch() != 0)
            {
                Processor.decode();
                Processor.execute();
            }
        }
        /// <summary>
        /// This method is used to perform a single iteration of the fetch, decode, execute cycle.
        /// </summary>
        public void step()
        {
            Processor.fetch();
            Processor.decode();
            Processor.execute();
        }
    }
}
