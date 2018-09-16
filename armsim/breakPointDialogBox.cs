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
    public partial class breakPointDialogBox : Form
    {
        int breakPoint;
        Form1 form;
        public breakPointDialogBox(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void addressBox_Click(object sender, EventArgs e)
        {
            addressBox.Text = "";
        }

        private void setBreakpointButton_Click(object sender, EventArgs e)
        {
            breakPoint = Convert.ToInt32(addressBox.Text, 16);
            form.breakPoints.Add(breakPoint);
            this.Close();
        }
    }
}
