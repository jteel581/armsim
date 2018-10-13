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
        public Options getOps() { return ops; }
        
        Thread runThread;
        public List<int> breakPoints = new List<int>();
        public bool breakPointsEnabled = true;

        bool stopButtonClicked = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            disassemblyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            memoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            stackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
           
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
        public void hilightApropriateRow()
        {
            if (disassemblyListView.SelectedIndices.Count > 0)
            {
                int i = disassemblyListView.SelectedIndices[0];
                disassemblyListView.Items[i].Selected = false;
            }

            int address = comp.getRegisters().getReg(15);
            if (address % 4 != 0)
            {
                address -= (address % 4);
            }
            string addrStr = address.ToString("x8");


            
            var items = disassemblyListView.Items;
            foreach (ListViewItem lvi in items)
            {
               
                if (lvi.Text == addrStr)
                {
                    lvi.Selected = true;
                    disassemblyListView.TopItem = items[lvi.Index - 2];
                    return;
                }
            }
            items[items.Count - 1].Selected = true;
            disassemblyListView.TopItem = items[items.Count - 1];


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

        public void addStackLine(string addressStr, string value)
        {
            ListViewItem stackLine = new ListViewItem(new string[] { addressStr, value });
            stackListView.Items.Add(stackLine);
        }

        public void fillStackPanel()
        {
            var items = stackListView.Items;
            items.Clear();
            int firstWord = comp.getRAM().ReadWord(0);
            addStackLine("0x00000000", firstWord.ToString("x8"));
            stackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


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
                b = TestComputer.runTests(ops);
                b = testCPU.runTests();
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
            else if (ops.getExecStatus() == true)
            {


                if (ops.getFileName() == "")
                {
                    ops.setExecStatus(false);
                }
                else
                {
                    // perform unit tests
                    if (ops.log)
                    {
                        Trace.WriteLine("Loader: Performing Unit Tests...");

                    }
                    bool b = TestRAM.runTests();
                    b = TestConverter.runTests();
                    b = TestComputer.runTests(ops);
                    b = testCPU.runTests();
                    if (b == true)
                    {
                        if (ops.log)
                        {
                            Trace.WriteLine("Loader: All Tests Passed!");

                        }
                    }
                    else
                    {
                        if (ops.log)
                        {
                            Trace.WriteLine("Loader: Test Failed");

                        }
                        System.Environment.Exit(-1);

                    }

                    // execute from beginning
                    fileNameLabel.Text = ops.getFileName();
                    memSizeLabel.Text = ops.getMemSize().ToString();

                    comp = new Computer(ops.getMemSize() == 0 ? 32768 : ops.getMemSize(), this);

                    if (ops.getFileName() != "")
                    {
                        if (!comp.load(this, ops))
                        {
                            string message = "Somthing went wrong with loading!";
                            string caption = "Loader Error";
                            MessageBox.Show(message, caption);
                            handleBadLoading();
                            //something went wrong with loading
                        }
                    }
                    Tracer.setRAM(comp.getRAM());
                    Tracer.setRegs(comp.getRegisters());
                    Tracer.enableTrace();





                    runButton.PerformClick();

                    

                }
            }
            else
            {
                fileNameLabel.Text = ops.getFileName();
                memSizeLabel.Text = ops.getMemSize().ToString();

                comp = new Computer(ops.getMemSize() == 0 ? 32768 : ops.getMemSize(), this);

                if (ops.getFileName() != "")
                {
                    if (!comp.load(this, ops))
                    {
                        string message = "Somthing went wrong with loading!";
                        string caption = "Loader Error";
                        MessageBox.Show(message, caption);
                        handleBadLoading();
                        //something went wrong with loading
                    }
                }
                Tracer.setRAM(comp.getRAM());
                Tracer.setRegs(comp.getRegisters());
                Tracer.enableTrace();
            }
            




        }

        public void fillDissAssembPanel()
        {
            disassemblyListView.Items.Clear();
            disassemblyListView.FullRowSelect = true;
            CPU processor = comp.getProcessor();

            int oldPc = processor.getProgramCounter();
            processor.setProgramCounter(comp.getFirstAddr());
            Instruction instr;
            string addrStr;
            string instrValStr;
            string instrStr;
            int curPc = processor.getProgramCounter();
            Memory bits;
            Memory registers = processor.getRegisters();
            while (!((instr = processor.decode(processor.fetch())) is SWIinstruction) && processor.fetch() != 0)
            {
                bits = instr.getBits();
                addrStr = curPc.ToString("x8");
                instrValStr = bits.ReadWord(0).ToString("x8");
                instrStr = instr.ToString();
                ListViewItem lvi = new ListViewItem(new string[] { addrStr, instrValStr, instrStr });
                disassemblyListView.Items.Add(lvi);

                registers.setReg(15, registers.getReg(15) + 4);
                processor.setProgramCounter(registers.getReg(15));
                curPc = processor.getProgramCounter();

            }
            processor.setProgramCounter(oldPc);
            registers.setReg(15, oldPc);

            /*ListViewItem lvi = new ListViewItem(new string[] { "00001000", "e52db004", "push	{fp}		; (str fp, [sp, #-4]!)" });
            disassemblyListView.Items.Add(lvi);*/

            disassemblyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            // hilight the right row
            int i = 0;
            foreach(ListViewItem lvi in disassemblyListView.Items)
            {

                string address = lvi.SubItems[0].Text;
                if (address == processor.getProgramCounter().ToString("x8"))
                {
                    if (i > 2)
                    {
                        disassemblyListView.TopItem = disassemblyListView.Items[i - 2];
                        disassemblyListView.Items[i].Selected = true;

                    }
                    else
                    {
                        disassemblyListView.TopItem = disassemblyListView.Items[i];
                        disassemblyListView.Items[i].Selected = true;

                    }
                    break;

                }
                i++;
            }
            disassemblyListView.Focus();
            //disassemblyListView.TopItem = disassemblyListView.Items[12];

            //disassemblyListView.Items[14].Selected = true;
            
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
                if (!comp.load(this, ops))
                {
                    string message = "Somthing went wrong with loading!";
                    string caption = "Loader Error";
                    MessageBox.Show(message, caption);
                    handleBadLoading();
                    // somthing went wrong with loading
                }
            }
        }

        public void setFlagBox()
        {
            flagBox.Text = "0000";
        }

        public void handleBadLoading()
        {
            fileNameLabel.Text = "None";
            var items = disassemblyListView.Items;
            items.Clear();
            items = memoryListView.Items;
            items.Clear();
            items = stackListView.Items;
            items.Clear();
            flagBox.Clear();
            checkSumLabel.Text = "";
            registerBox.Clear();
        }

        private void addressBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToInt32(Keys.Enter))
                {
                    string numStr = addressBox.Text;
                    numStr = numStr.Replace("0x", "");
                    numStr = numStr.Replace("0X", "");
                    int num = Convert.ToInt32(numStr, 16);
                    if (num % 16 != 0)
                    {
                        num -= (num % 16);
                    }
                    memoryListView.TopItem = memoryListView.Items[num / 16];
                    memoryListView.Items[num / 16].Selected = true;
                    memoryListView.Focus();
                }
            }
            catch (FormatException fe)
            {
                string caption = "Input Error";
                string message = "You must enter a hexacecimal address.";
                MessageBox.Show(message, caption);
            }
            
        }

        private void addressBox_Click(object sender, EventArgs e)
        {
            addressBox.Text = "";
        }

        public void enableRunButton()
        {
            runButton.Enabled = true;
        }
        public void disableStopButton()
        {
            stopButton.Enabled = false;
        }

        public void enableStepButton()
        {
            stepButton.Enabled = true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            stopButton.Enabled = true;
            stepButton.Enabled = false;
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

        private void breakPointButton_Click(object sender, EventArgs e)
        {
            breakPointDialogBox dialogBox = new breakPointDialogBox(this);
            dialogBox.Show();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            
            bool b = comp.load(this, ops);
            if (b == false)
            {
                string message = "Somthing went wrong with loading!";
                string caption = "Loader Error";
                MessageBox.Show(message, caption);
                handleBadLoading();
                // something went wrong with loading
            }
            hilightApropriateRow();
            disassemblyListView.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:
                    if (e.Control)
                    {
                        openToolStripMenuItem.PerformClick();
                    }
                    break;
                case Keys.F5:
                    runButton.PerformClick();
                    break;
                case Keys.F10:
                    stepButton.PerformClick();
                    break;
                case Keys.Q:
                    if (e.Control)
                    {
                        stopButton.PerformClick();
                    }
                    break;
                case Keys.T:
                    if (e.Control)
                    {
                        traceButton.PerformClick();
                    }
                    break;
                case Keys.R:
                    if (e.Control)
                    {
                        resetButton.PerformClick();
                    }
                    break;
                case Keys.B:
                    if (e.Control)
                    {
                        if (breakPointsEnabled)
                        {
                            breakPointsStatusLabel.Text = "Disabled";
                        }
                        else
                        {
                            breakPointsStatusLabel.Text = "Enabled";
                        }
                        breakPointsEnabled = !breakPointsEnabled;

                    }
                    break;

            }
        }

        private void traceButton_Click(object sender, EventArgs e)
        {
            if (Tracer.enabled)
            {
                traceStatusLabel.Text = "Disabled";
                Tracer.disableTrace();
            }
            else
            {
                traceStatusLabel.Text = "Enabled";
                Tracer.enableTrace();
            }
        }
    }
}
