namespace armsim
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.memSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.testStatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkSumLabel = new System.Windows.Forms.Label();
            this.memoryBox = new System.Windows.Forms.TextBox();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.disassemblyLabel = new System.Windows.Forms.Label();
            this.disassemblyBox = new System.Windows.Forms.TextBox();
            this.terminalBox = new System.Windows.Forms.Label();
            this.terminalTextBox = new System.Windows.Forms.TextBox();
            this.stackLabel = new System.Windows.Forms.Label();
            this.stackBox = new System.Windows.Forms.TextBox();
            this.registerLabel = new System.Windows.Forms.Label();
            this.registerBox = new System.Windows.Forms.TextBox();
            this.flagLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ELF File:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(66, 30);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(35, 13);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Memory Size:";
            // 
            // memSizeLabel
            // 
            this.memSizeLabel.AutoSize = true;
            this.memSizeLabel.Location = new System.Drawing.Point(183, 30);
            this.memSizeLabel.Name = "memSizeLabel";
            this.memSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.memSizeLabel.TabIndex = 3;
            this.memSizeLabel.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Test Status:";
            // 
            // testStatusLabel
            // 
            this.testStatusLabel.AutoSize = true;
            this.testStatusLabel.Location = new System.Drawing.Point(294, 30);
            this.testStatusLabel.Name = "testStatusLabel";
            this.testStatusLabel.Size = new System.Drawing.Size(35, 13);
            this.testStatusLabel.TabIndex = 5;
            this.testStatusLabel.Text = "NULL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loader";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Checksum:";
            // 
            // checkSumLabel
            // 
            this.checkSumLabel.AutoSize = true;
            this.checkSumLabel.Location = new System.Drawing.Point(402, 30);
            this.checkSumLabel.Name = "checkSumLabel";
            this.checkSumLabel.Size = new System.Drawing.Size(35, 13);
            this.checkSumLabel.TabIndex = 8;
            this.checkSumLabel.Text = "NULL";
            // 
            // memoryBox
            // 
            this.memoryBox.Location = new System.Drawing.Point(15, 63);
            this.memoryBox.Multiline = true;
            this.memoryBox.Name = "memoryBox";
            this.memoryBox.Size = new System.Drawing.Size(422, 133);
            this.memoryBox.TabIndex = 9;
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryLabel.Location = new System.Drawing.Point(15, 44);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(58, 17);
            this.memoryLabel.TabIndex = 10;
            this.memoryLabel.Text = "Memory";
            // 
            // disassemblyLabel
            // 
            this.disassemblyLabel.AutoSize = true;
            this.disassemblyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disassemblyLabel.Location = new System.Drawing.Point(15, 203);
            this.disassemblyLabel.Name = "disassemblyLabel";
            this.disassemblyLabel.Size = new System.Drawing.Size(87, 17);
            this.disassemblyLabel.TabIndex = 11;
            this.disassemblyLabel.Text = "Disassembly";
            // 
            // disassemblyBox
            // 
            this.disassemblyBox.Location = new System.Drawing.Point(15, 223);
            this.disassemblyBox.Multiline = true;
            this.disassemblyBox.Name = "disassemblyBox";
            this.disassemblyBox.Size = new System.Drawing.Size(422, 133);
            this.disassemblyBox.TabIndex = 12;
            // 
            // terminalBox
            // 
            this.terminalBox.AutoSize = true;
            this.terminalBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminalBox.Location = new System.Drawing.Point(15, 517);
            this.terminalBox.Name = "terminalBox";
            this.terminalBox.Size = new System.Drawing.Size(63, 17);
            this.terminalBox.TabIndex = 13;
            this.terminalBox.Text = "Terminal";
            // 
            // terminalTextBox
            // 
            this.terminalTextBox.Location = new System.Drawing.Point(15, 537);
            this.terminalTextBox.Multiline = true;
            this.terminalTextBox.Name = "terminalTextBox";
            this.terminalTextBox.Size = new System.Drawing.Size(699, 148);
            this.terminalTextBox.TabIndex = 14;
            // 
            // stackLabel
            // 
            this.stackLabel.AutoSize = true;
            this.stackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackLabel.Location = new System.Drawing.Point(18, 363);
            this.stackLabel.Name = "stackLabel";
            this.stackLabel.Size = new System.Drawing.Size(43, 17);
            this.stackLabel.TabIndex = 15;
            this.stackLabel.Text = "Stack";
            // 
            // stackBox
            // 
            this.stackBox.Location = new System.Drawing.Point(15, 381);
            this.stackBox.Multiline = true;
            this.stackBox.Name = "stackBox";
            this.stackBox.Size = new System.Drawing.Size(422, 133);
            this.stackBox.TabIndex = 16;
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabel.Location = new System.Drawing.Point(481, 44);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(68, 17);
            this.registerLabel.TabIndex = 17;
            this.registerLabel.Text = "Registers";
            // 
            // registerBox
            // 
            this.registerBox.Location = new System.Drawing.Point(484, 65);
            this.registerBox.Multiline = true;
            this.registerBox.Name = "registerBox";
            this.registerBox.Size = new System.Drawing.Size(230, 198);
            this.registerBox.TabIndex = 18;
            // 
            // flagLabel
            // 
            this.flagLabel.AutoSize = true;
            this.flagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagLabel.Location = new System.Drawing.Point(484, 270);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(42, 17);
            this.flagLabel.TabIndex = 19;
            this.flagLabel.Text = "Flags";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(484, 290);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 224);
            this.textBox1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 697);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.registerBox);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.stackBox);
            this.Controls.Add(this.stackLabel);
            this.Controls.Add(this.terminalTextBox);
            this.Controls.Add(this.terminalBox);
            this.Controls.Add(this.disassemblyBox);
            this.Controls.Add(this.disassemblyLabel);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.memoryBox);
            this.Controls.Add(this.checkSumLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.testStatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.memSizeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "armsim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label memSizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label testStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label checkSumLabel;
        private System.Windows.Forms.TextBox memoryBox;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.Label disassemblyLabel;
        private System.Windows.Forms.TextBox disassemblyBox;
        private System.Windows.Forms.Label terminalBox;
        private System.Windows.Forms.TextBox terminalTextBox;
        private System.Windows.Forms.Label stackLabel;
        private System.Windows.Forms.TextBox stackBox;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.TextBox registerBox;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}

