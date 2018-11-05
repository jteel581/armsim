using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace armsim
{
    public static class Tracer
    {
        static int stepNum = 1;
        static Memory RAM;
        static Memory Registers;
        static Memory CPSR;
        static string flags = "";
        static string mode = "SYS";
        public static bool enabled = true;
        static StreamWriter traceFile;
        public static bool okToClose = true;
        public static StreamWriter getTraceFile() { return traceFile; }
        public static string bPc = "";
        public static bool branchInstr = false;

        public static void setRAM(Memory newRam)
        {
            RAM = newRam;
        }
        public static void setRegs(Memory newRegs)
        {
            Registers = newRegs;
        }
        public static void setCPSR(Memory newCPSR)
        {
            CPSR = newCPSR;
        }
        public static void incrementStepNum()
        {
            stepNum += 1;
        }
        public static void setStepNum(int newNum)
        {
            stepNum = newNum;
        }
        public static void enableTrace()
        {
            Tracer.disableTrace();
            okToClose = false;
            enabled = true;
            if (File.Exists(Environment.CurrentDirectory + "\\trace.log"))
            {
                File.Delete(Environment.CurrentDirectory + "\\trace.log");
            }
            traceFile = new StreamWriter(Environment.CurrentDirectory + "\\trace.log");
        }
        public static void disableTrace()
        {
            if (traceFile != null)
            {
                traceFile.Flush();
                traceFile.Close();

            }
            enabled = false;
            okToClose = true;
        }
        static string printRegsNoNewLine()
        {
            string regString = "";
            for (int i = 0; i < 15; i++)
            {
                regString += i + "=" + Registers.getReg(i).ToString("x8") + " ";
            }

            regString = regString.ToUpper();
            return regString;
        }

        public static void trace()
        {
            if (enabled)
            {
                if (stepNum == 21)
                {

                }
                string step_number = stepNum.ToString("000000");
                int progCounter = Registers.getReg(15);
                progCounter -= progCounter == 0 ? 0 : 4;
                string program_counter = progCounter.ToString("x8");

                string checksum = RAM.calculateChecksum(RAM.memory).ToString("x8");

                flags = CPSR.getFlagsStr();
                if (!branchInstr)
                {
                    traceFile.WriteLine(step_number + " " + program_counter.ToUpper() + " " + checksum.ToUpper() + " " + flags + " " + mode + " " + printRegsNoNewLine());

                }
                else
                {
                    traceFile.WriteLine(step_number + " " + bPc + " " + checksum.ToUpper() + " " + flags + " " + mode + " " + printRegsNoNewLine());
                    bPc = "";
                    branchInstr = false;
                }
                stepNum++;
            }
            

        }
    }
}
