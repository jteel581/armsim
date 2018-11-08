using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace armsim
{
    class SWIinstruction : Instruction
    {
        int imm24;

        public SWIinstruction(int instVal) :base(instVal)
        {
            Memory bits = base.getBits();
            imm24 = 0;
            imm24 = bits.ReadByte(2);
            imm24 <<= 8;
            imm24 |= bits.ReadByte(1);
            imm24 <<= 8;
            imm24 |= bits.ReadByte(0);
            base.setInstrStr(ToString());

        }

        public override void execute(CPU processor)
        {
            switch (imm24)
            {
                case 0:
                    // putchar
                    // gotta take care of cross thread stuff
                    TextBox tb = processor.GetComputer().getForm1().getConsole();
                    char r0Char = Convert.ToChar(processor.getRegisters().getReg(0));

                    if (tb.InvokeRequired)
                    {
                        Form1 f = processor.GetComputer().getForm1();
                        tb.Invoke(new MethodInvoker(delegate { f.writeCharToConsole(r0Char); }));

                    }
                    else
                    {
                        processor.GetComputer().getForm1().writeCharToConsole(r0Char);

                    }
                    break;
                case 17:
                    // halt
                    Button b = processor.GetComputer().getForm1().getStopButton();
                    if (b.InvokeRequired)
                    {
                        Form1 f = processor.GetComputer().getForm1();
                        b.Invoke(new MethodInvoker(delegate { f.clickStopButton(); }));
                    }
                    else
                    {
                        processor.GetComputer().getForm1().clickStopButton();

                    }
                    break;
                case 106:
                    // readline
                    DialogBox db = new DialogBox();
                    db.ShowDialog();
                    
                    string text = db.getText();
                    int r1Val = processor.getRegisters().getReg(1);
                    int r2Val = processor.getRegisters().getReg(2);


                    if (text.Length <= r2Val - 2)
                    {
                        //text += '\r';
                        //text += '\0';
                        for (int i = 0; i < text.Length; i++)
                        {
                            processor.getRAM().WriteByte(r1Val, (byte)text[i]);
                            r1Val += 1;
                        }
                        processor.getRAM().WriteByte(r1Val, (byte)'\r');
                        r1Val += 4;
                        processor.getRAM().WriteByte(r1Val, (byte)'\0');
                    }
                    else 
                    {
                        text = text.Substring(0, r2Val - 1);

                        // += "\0";
                        for (int i = 0; i < r2Val - 1; i++)
                        {
                            processor.getRAM().WriteByte(r1Val, (byte)text[i]);
                            r1Val += 1;
                        }
                        processor.getRAM().WriteByte(r1Val, (byte)'\0');
                    }
                    

                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return "swi " + imm24;
        }
    }
}
