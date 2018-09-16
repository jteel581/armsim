// Form1.cs
// This file contains logic used to read the elf files and load the application.

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
using System.Threading;

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



    // This class holds logic to load the application and calls methods from the RAM, Options, and unit test classes to 
    // process the command line arguments, run tests if applicable, read the elf file and load the program into RAM.
    public partial class Form1 : Form
    {
        Computer comp;
        Options ops;
        Thread runThread;
        bool stopButtonClicked = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void setCheckSum(int newSum)
        {
            checkSumLabel.Text = newSum.ToString() ;
        }

        public void setFileNameLabel(string newName)
        {
            fileNameLabel.Text = newName;
        }
        public void setRegPanelText(string newText)
        {
            if (registerBox.InvokeRequired)
            {
                registerBox.Invoke(new MethodInvoker(delegate { registerBox.Text = newText; }));
            }
            else
            {
                registerBox.Text = newText;

            }
        }
        public ListView getDisasseblyListView() { return disassemblyListView; }
        public bool getStopButtonClicked()
        {
            return stopButtonClicked;
        }
        public void setStopButtonClicked(bool b)
        {
            stopButtonClicked = b;
        }

        public void addMemLine(string addressStr, string hexStr, string asciiStr )
        {
            ListViewItem memLine = new ListViewItem(new string[] { addressStr, hexStr, asciiStr });
            memoryListView.Items.Add(memLine);
        }


        public void fillMemPanel()
        {
            var items = memoryListView.Items;
            items.Clear();
            string addressStr = "";
            string hexStr = "";
            string asciiStr = "";
            int tempNum = 0;
            for (int i = 0; i < comp.getRAM().getSize(); i += 16)
            {
                addressStr = "";
                hexStr = "";
                asciiStr = "";
                addressStr = i.ToString("x8");
                for (int j = 0; j < 16; j++)
                {
                    if ((i + j) == 0x138)
                    {
                        tempNum = 0;
                    }
                    tempNum = comp.getRAM().ReadByte(i + j);

                    hexStr += tempNum.ToString("x2");
                    hexStr += " ";
                    if ((tempNum >= 0 && tempNum <= 32) || tempNum == 127)
                    {
                        asciiStr += ".";
                        //asciiStr += Encoding.ASCII.GetString(comp.getRAM().memory, i + j, 1) + " ";
                        //asciiStr += Convert.ToChar(tempNum) + " ";
                    }
                    else if (tempNum > 32 && tempNum < 127)
                    {
                        asciiStr +=  Convert.ToChar(tempNum);
                    }
                    else
                    {
                        asciiStr += ".";

                    }

                }
                addMemLine(addressStr, hexStr, asciiStr);
                
            }
            memoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void configureMemPanel()
        {
            ListView.ColumnHeaderCollection columns = memoryListView.Columns;
            //columns[0].AutoResize();
            //columns[0].Width = 60;
            //columns[1].Width = 225;
            //columns[2].Width = 115;
            memoryListView.FullRowSelect = true;
            // for debuging only
            /*
            for (int i = 0; i < 100; i++)
            {

                ListViewItem memLine = new ListViewItem(new string[] { i.ToString("x4"), "haha", "beep" });
                memoryListView.Items.Add(memLine);

            }*/
        }

        // This method holds logic to process the command line arguments, run tests if applicable, read the 
        // elf file and load the program into RAM.
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            ops = new Options(args);
            if (ops.getTestStatus() == true)
            {
                if (ops.log)
                {
                    Trace.WriteLine("Loader: Performing Unit Tests...");

                }
                bool b = TestRAM.runTests();
                b = TestConverter.runTests();
                b = TestComputer.runTests();
                if (b == true)
                {
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: All Tests Passed!");

                    }
                    System.Environment.Exit(-1);
                }  
                else
                {
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Test Failed");

                    }
                    System.Environment.Exit(-1);

                }
            }

            fileNameLabel.Text = ops.getFileName();
            memSizeLabel.Text = ops.getMemSize().ToString();

            comp = new Computer(ops.getMemSize() == 0 ? 32768 : ops.getMemSize(), this);
            if (ops.getFileName() != "")
            {
                comp.load(this, ops);
            }
            



        }

        public void fillDissAssembPanel()
        {
            disassemblyListView.FullRowSelect = true;
            
            ListViewItem lvi = new ListViewItem(new string[] { "00001000", "e52db004", "push	{fp}		; (str fp, [sp, #-4]!)" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001004", "e28db000", "add	fp, sp, #0" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001008", "e24dd00c", "sub	sp, sp, #12" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000100c", "e50b0008", "str	r0, [fp, #-8]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001010", "e28bd000", "add	sp, fp, #0" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001014", "e8bd0800", "ldmfd	sp!, {fp}" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001018", "e12fff1e", "bx	lr" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000101c", "e52db004", "push	{fp}		; (str fp, [sp, #-4]!)" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001020", "e28db000", "add	fp, sp, #0" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001024", "e24dd00c", "sub	sp, sp, #12" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001028", "e50b0008", "str	r0, [fp, #-8]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000102c", "e28bd000", "sp, fp, #0" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001030", "e8bd0800", "sp!, {fp}" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001034", "e12fff1e", "bx	lr" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001038", "e92d4800", "push	{fp, lr}" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000103c", "e28db004", "add	fp, sp, #4" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001040", "e24dd008", "sub	sp, sp, #8" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001044", "e3a0300a", "mov	r3, #10" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001048", "e50b3008", "str	r3, [fp, #-8]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000104c", "e3a03000", "mov	r3, #0" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001050", "e50b300c", "str	r3, [fp, #-12]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001054", "e51b000c", "ldr	r0, [fp, #-12]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001058", "ebffffe8", "bl	1000 <putc>" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000105c", "e59f301c", "ldr	r3, [pc, #28]	; 1080 <mystart+0x48>" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001060", "e5933000", "ldr	r3, [r3]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001064", "e1a00003", "mov	r0, r3" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001068", "ebffffeb", "bl	101c <puts>" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000106c", "e51b300c", "ldr	r3, [fp, #-12]" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001070", "e1a00003", "mov	r0, r3" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001074", "e24bd004", "sub	sp, fp, #4" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001078", "e8bd4800", "pop	{fp, lr}" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "0000107c", "e12fff1e", "bx	lr" });
            disassemblyListView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "00001080", "00001200", ".word	0x00001200" });
            disassemblyListView.Items.Add(lvi);
            disassemblyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            disassemblyListView.TopItem = disassemblyListView.Items[12];

            disassemblyListView.Items[14].Selected = true;
            
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Executable files (*.exe) | *.exe| All Files | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                comp.reset(ops.getMemSize());
                string newFileName = openFileDialog.FileName;   
                ops.setFileName(newFileName);
                comp.load(this, ops);
            }
        }

        private void addressBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt32(Keys.Enter))
            {
                string numStr = addressBox.Text;
                numStr = numStr.Replace("0x", "");
                numStr = numStr.Replace("0X", "");
                int num = Convert.ToInt32(numStr, 16);
                if ( num % 16 != 0)
                {
                    num -= (num % 16);
                }
                memoryListView.TopItem = memoryListView.Items[num / 16];
                memoryListView.Items[num / 16].Selected = true;
                memoryListView.Focus();
            }
        }

        private void addressBox_Click(object sender, EventArgs e)
        {
            addressBox.Text = "";
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runThread = new Thread(new ThreadStart(comp.run));
            runThread.IsBackground = true;
            runThread.Start();

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButtonClicked = true;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            comp.step();
        }
    }
}
