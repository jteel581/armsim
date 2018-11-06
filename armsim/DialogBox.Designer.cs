namespace armsim
{
    partial class DialogBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.swiLabel = new System.Windows.Forms.Label();
            this.enterTextLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // swiLabel
            // 
            this.swiLabel.AutoSize = true;
            this.swiLabel.Location = new System.Drawing.Point(13, 13);
            this.swiLabel.Name = "swiLabel";
            this.swiLabel.Size = new System.Drawing.Size(111, 13);
            this.swiLabel.TabIndex = 0;
            this.swiLabel.Text = "swi 0x6a encountered";
            // 
            // enterTextLabel
            // 
            this.enterTextLabel.AutoSize = true;
            this.enterTextLabel.Location = new System.Drawing.Point(13, 30);
            this.enterTextLabel.Name = "enterTextLabel";
            this.enterTextLabel.Size = new System.Drawing.Size(205, 13);
            this.enterTextLabel.TabIndex = 1;
            this.enterTextLabel.Text = "Please enter text for read line to complete:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 46);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 105);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.enterTextLabel);
            this.Controls.Add(this.swiLabel);
            this.Name = "DialogBox";
            this.Text = "DialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label swiLabel;
        private System.Windows.Forms.Label enterTextLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}