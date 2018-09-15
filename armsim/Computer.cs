// Computer.cs
// This file holds the Computer class which is used as the main simulated computer in this program.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace armsim
{
    class Computer
    {
        // Converts a byte array to a struct
        static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                typeof(T));
            handle.Free();
            return stuff;
        }



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
            Registers = new Memory(64);
            Processor = new CPU(RAM, Registers);
        }

        public string printRegs()
        {
            string regString = "";
            for (int i = 0;  i < 16; i++)
            {
                regString += "r" + i + " \t= " + Registers.getReg(i).ToString("x8") + "\r\n";
            }

            
            return regString;
        }

        public void reset(int ramSize)
        {
            RAM = new Memory(ramSize);
            Registers = new Memory(64);
            Processor = new CPU(RAM, Registers);
        }


        public void load( Form1 f, Options ops)
        {
            string newFileName = ops.getFileName();
            int lastSlash = newFileName.LastIndexOf("\\");
            newFileName = newFileName.Remove(0, lastSlash + 1);
            f.setFileNameLabel(newFileName);
            
            // Dr. Schaub code for reading elf files with some modifications for my program
            string elfFilename = ops.getFileName();
            if (ops.log)
            {
                Trace.WriteLine("Loader: Opening " + elfFilename + "...");

            }
            try
            {
                using (FileStream strm = new FileStream(elfFilename, FileMode.Open))
                {
                    ELF elfHeader = new ELF();
                    byte[] data = new byte[Marshal.SizeOf(elfHeader)];

                    // Read ELF header data
                    strm.Read(data, 0, data.Length);





                    // Convert to struct
                    elfHeader = ByteArrayToStructure<ELF>(data);
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Checking for ELF signature...");

                    }
                    if (!(elfHeader.EI_MAG0 == '\x7f' &&
                        elfHeader.EI_MAG1 == 'E' &&
                        elfHeader.EI_MAG2 == 'L' &&
                        elfHeader.EI_MAG3 == 'F'))
                    {
                        String message = "File entered for loading is not an ELF file.";
                        if (ops.log)
                        {
                            Trace.WriteLine("Loader: " + message);

                        }
                        String caption = "Invalid File Type Error";
                        MessageBox.Show(message, caption);
                        if (ops.log)
                        {
                            Trace.WriteLine("Loader: Exiting...");

                        }

                        System.Environment.Exit(-1);
                    }
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Confirmed ELF signature");
                        Trace.WriteLine("Loader: Number of segments: " + elfHeader.e_phnum);
                        Trace.WriteLine("Loader: Program header offset: " + elfHeader.e_phoff);
                    }

                    Processor.setProgramCounter((int)elfHeader.e_entry);
                    f.setRegPanelText(printRegs());
                    // read each program header 
                    strm.Seek(elfHeader.e_phoff, SeekOrigin.Begin);

                    for (int i = 0; i < elfHeader.e_phnum; i++)
                    {
                        data = new byte[elfHeader.e_phentsize];
                        strm.Read(data, 0, (int)elfHeader.e_phentsize);
                        long curLocation = strm.Position;
                        ELFheaderEntry progHeaderEntry = new ELFheaderEntry();

                        progHeaderEntry = ByteArrayToStructure<ELFheaderEntry>(data);
                        if (ops.log)
                        {
                            Trace.WriteLine("Loader: Segment " + i + " - Address = " + progHeaderEntry.p_vaddr + ", Offset = "
                            + progHeaderEntry.p_offset + ", Size = " + progHeaderEntry.p_filesz);
                        }

                        data = new byte[progHeaderEntry.p_filesz];
                        strm.Seek(progHeaderEntry.p_offset, SeekOrigin.Begin);
                        strm.Read(data, 0, (int)progHeaderEntry.p_filesz);
                        strm.Position = curLocation;
                        int address = (int)progHeaderEntry.p_vaddr;
                        foreach (byte b in data)
                        {
                            RAM.WriteByte(address, b);
                            address++;
                            if (address == ops.getMemSize())
                            {
                                String message = "Could not load entire program into memory.";
                                if (ops.log)
                                {
                                    Trace.WriteLine("Loader: " + message);

                                }
                                String caption = "Not Enough Memory Error";
                                MessageBox.Show(message, caption);
                                if (ops.log)
                                {
                                    Trace.WriteLine("Loader: Exiting...");

                                }
                                System.Environment.Exit(-1);
                            }
                        }

                    }
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Computing Checksum...");

                    }
                    int checkSum = RAM.calculateChecksum(RAM.memory);
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Checksum = " + checkSum);

                    }
                    f.setCheckSum(checkSum);
                    f.configureMemPanel();
                    f.fillMemPanel();
                    f.fillDissAssembPanel();
                    
                }



            }
            catch (FileNotFoundException)
            {
                string message = "That file was not found.";
                string caption = "File not found";
                MessageBox.Show(message, caption);
                System.Environment.Exit(-1);


            }
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
