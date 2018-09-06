using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Arguments.Length > 1)
            {
                for (int i= 0; i < Arguments.Length; i++)
                {
                    string arg = Arguments[i];
                    if (i != Arguments.Length && arg == "--load")
                    {
                        string fileName = Arguments[i + 1];
                        setFileName(fileName);
                    }
                    else if (i != Arguments.Length && arg == "--mem")
                    {
                        int memSize = Convert.ToInt32(Arguments[i + 1]);
                        setMemSize(memSize);
                    }
                    else if (arg == "--test")
                    {
                        setTestStatus(true);
                    }
                    else
                    {
                        // error

                    }

                }
            }
        } 

    }
}
