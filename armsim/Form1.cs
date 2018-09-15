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
            registerBox.Text = newText;
        }

        public void addMemLine()
        {
            ListView.ColumnHeaderCollection columns = memoryListView.Columns;
            columns[0].Width = 60;
            columns[1].Width = 225;
            columns[2].Width = 115;
            memoryListView.FullRowSelect = true;
            for (int i = 0; i < 100; i++)
            {

                ListViewItem memLine = new ListViewItem(new string[] { i.ToString("x4"), "haha", "beep" });
                memoryListView.Items.Add(memLine);

            }
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

            comp = new Computer(ops.getMemSize() == 0 ? 32768 : ops.getMemSize());
            if (ops.getFileName() != "")
            {
                comp.load(this, ops);
            }
            



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
                memoryListView.TopItem = memoryListView.Items[num];
                memoryListView.Items[num].Selected = true;
                memoryListView.Focus();
            }
        }
    }
}
