using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace armsim
{
    // A struct that mimics memory layout of ELF file header
    // See http://www.sco.com/developers/gabi/latest/contents.html for details
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ELF
    {
        public byte EI_MAG0, EI_MAG1, EI_MAG2, EI_MAG3, EI_CLASS, EI_DATA, EI_VERSION;
        byte unused1, unused2, unused3, unused4, unused5, unused6, unused7, unused8, unused9;
        public ushort e_type;
        public ushort e_machine;
        public uint e_version;
        public uint e_entry;
        public uint e_phoff;
        public uint e_shoff;
        public uint e_flags;
        public ushort e_ehsize;
        public ushort e_phentsize;
        public ushort e_phnum;
        public ushort e_shentsize;
        public ushort e_shnum;
        public ushort e_shstrndx;
    }

    // a struct for dealing with elf header entries
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ELFheaderEntry
    {
        public uint p_type;
        public uint p_offset;
        public uint p_vaddr;
        public uint p_paddr;
        public uint p_filesz;
        public uint p_memsz;
        public uint p_flags;
        public uint p_align;
    }




    public partial class Form1 : Form
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


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this is used to get the command line arguments onto the form
            string[] args = Environment.GetCommandLineArgs();
            Options ops = new Options(args);
            if (ops.getTestStatus() == true)
            {
                Trace.WriteLine("Loader: Performing Unit Tests...");
                bool b = TestRAM.runTests();
                if (b == true)
                {
                    Trace.WriteLine("Loader: All Tests Passed!");
                    System.Environment.Exit(-1);
                }  
                else
                {
                    Trace.WriteLine("Loader: Test Failed");
                    System.Environment.Exit(-1);

                }
            }

            fileNameLabel.Text = ops.getFileName();
            memSizeLabel.Text = ops.getMemSize().ToString();
            testStatusLabel.Text = ops.getTestStatus().ToString();


            RAM memory = new RAM(ops.getMemSize() == 0 ? 32768 : ops.getMemSize());
            
            // Dr. Schaub code for reading elf files with some modifications for my program
            string elfFilename = ops.getFileName();
            Trace.WriteLine("Loader: Opening " + elfFilename + "...");
            using (FileStream strm = new FileStream(elfFilename, FileMode.Open))
            {
                ELF elfHeader = new ELF();
                byte[] data = new byte[Marshal.SizeOf(elfHeader)];

                // Read ELF header data
                strm.Read(data, 0, data.Length);





                // Convert to struct
                elfHeader = ByteArrayToStructure<ELF>(data);
                Trace.WriteLine("Loader: Checking for ELF signature...");
                if (!(elfHeader.EI_MAG0 == '\x7f' &&
                    elfHeader.EI_MAG1 == 'E' &&
                    elfHeader.EI_MAG2 == 'L' &&
                    elfHeader.EI_MAG3 == 'F'))
                {
                    String message = "File entered for loading is not an ELF file.";
                    Trace.WriteLine("Loader: " + message);
                    String caption = "Invalid File Type Error";
                    MessageBox.Show(message, caption);
                    Trace.WriteLine("Loader: Exiting...");

                    System.Environment.Exit(-1);
                }
                Trace.WriteLine("Loader: Confirmed ELF signature");
                Trace.WriteLine("Loader: Number of segments: " + elfHeader.e_phnum);
                Trace.WriteLine("Loader: Program header offset: " + elfHeader.e_phoff);

                // read each program header 
                strm.Seek(elfHeader.e_phoff, SeekOrigin.Begin);

                for (int i = 0; i < elfHeader.e_phnum; i++)
                {
                    data = new byte[elfHeader.e_phentsize];
                    strm.Read(data, 0, (int)elfHeader.e_phentsize);
                    long curLocation = strm.Position;
                    ELFheaderEntry progHeaderEntry = new ELFheaderEntry();

                    progHeaderEntry = ByteArrayToStructure<ELFheaderEntry>(data);
                    Trace.WriteLine("Loader: Segment " + i + " - Address = " + progHeaderEntry.p_vaddr + ", Offset = "
                        + progHeaderEntry.p_offset + ", Size = " + progHeaderEntry.p_filesz);
                    data = new byte[progHeaderEntry.p_filesz];
                    strm.Seek(progHeaderEntry.p_offset, SeekOrigin.Begin);
                    strm.Read(data, 0, (int)progHeaderEntry.p_filesz);
                    strm.Position = curLocation;
                    int address = (int)progHeaderEntry.p_vaddr;
                    foreach (byte b in data)
                    {
                        memory.WriteByte(address, b);
                        address++;
                        if (address == ops.getMemSize())
                        {
                            String message = "Could not load entire program into memory.";
                            Trace.WriteLine("Loader: " + message);
                            String caption = "Not Enough Memory Error";
                            MessageBox.Show(message, caption);
                            Trace.WriteLine("Loader: Exiting...");
                            System.Environment.Exit(-1);
                        }
                    }

                }
                Trace.WriteLine("Loader: Computing Checksum...");
                int checkSum = memory.calculateChecksum(memory.memory);
                Trace.WriteLine("Loader: Checksum = " + checkSum);
                checkSumLabel.Text = checkSum.ToString();
                checkSumLabel.Update();

            }
        }
    }
}
