using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace armsim
{
    public partial class DialogBox : Form
    {
        bool enterPressed = false;
        string text = "";
        public DialogBox()
        {
            InitializeComponent();
        }

        public void setEnterPressed(bool newEnterPressed)
        {
            enterPressed = newEnterPressed;
            text = textBox1.Text;
        }
        public string getText() { return text; }
        public bool getEnterPressed() { return enterPressed; }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt32(Keys.Enter))
            {
                enterPressed = true;
                text = textBox1.Text;
                this.Close();
            }
        }
    }
}
