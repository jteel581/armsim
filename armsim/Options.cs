using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace armsim
{
    class Options
    {
        // option variables
        private string fileName = "";
        private int memsize = 0;
        private Boolean testStatus = false;

        // option getter and setter methods
        public string getFileName()
        {
            return fileName;
        }
        public void setFileName(String name)
        {
            fileName = name;
        }
        public int getMemSize()
        {
            return memsize == 0 ? 32768 : memsize;
        }
        public void setMemSize(int newSize)
        {
            memsize = newSize;
        }
        public Boolean getTestStatus()
        {
            return testStatus;
        }
        public void setTestStatus(Boolean newTestStatus)
        {
            testStatus = newTestStatus;
        }

        // Options class constructor
        public Options(String[] Arguments)
        {
            if(!Arguments.Contains("--load"))
            {
                String message = "You must enter a --load option followed by an executable file.\nusage: armsim[--load elf - file][--mem memory - size][--test]";
                String caption = "No Load Option";
                MessageBox.Show(message, caption);
                Trace.WriteLine("Loader: Exiting...");

                System.Environment.Exit(-1);
            }
            if (Arguments.Length > 1)
            {
                for (int i= 1; i < Arguments.Length; i++)
                {
                    string arg = Arguments[i];
                    if (i != Arguments.Length && arg == "--load")
                    {
                        string fileName = Arguments[i + 1];
                        setFileName(fileName);
                        i++;
                    }
                    else if (i != Arguments.Length && arg == "--mem")
                    {
                        int memSize = 0;
                        try
                        {
                            memSize = Convert.ToInt32(Arguments[i + 1]);
                        }
                        catch (FormatException e)
                        {
                            String message = "Memory size must be any positive number between 0 and 1,048,576";
                            String caption = "Invalid Size Type Error";
                            MessageBox.Show(message, caption);
                            Trace.WriteLine("Loader: Exiting...");

                            System.Environment.Exit(-1);
                        }
                        if (memSize > 1048576 || memSize < 0)
                        {
                            String message = "Memory size must be any positive number between 0 and 1,048,576";
                            String caption = "Invalid Size Error";
                            MessageBox.Show(message, caption);
                            Trace.WriteLine("Loader: Exiting...");

                            System.Environment.Exit(-1);
                        }
                        setMemSize(memSize);
                        i++;
                    }
                    else if (arg == "--test")
                    {
                        setTestStatus(true);
                    }
                    else
                    {
                        String message = "'" + arg + "' is not a valid option.\nusage: armsim [ --load elf-file ] [ --mem memory-size ] [ --test ]";
                        String caption = "Invalid Option Error";
                        MessageBox.Show(message, caption);
                        Trace.WriteLine("Loader: Exiting...");

                        System.Environment.Exit(-1);
                    }

                }
            }
        } 

    }
}
