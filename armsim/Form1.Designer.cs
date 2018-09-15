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
            this.label5 = new System.Windows.Forms.Label();
            this.checkSumLabel = new System.Windows.Forms.Label();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.disassemblyLabel = new System.Windows.Forms.Label();
            this.terminalBox = new System.Windows.Forms.Label();
            this.terminalTextBox = new System.Windows.Forms.TextBox();
            this.stackLabel = new System.Windows.Forms.Label();
            this.stackBox = new System.Windows.Forms.TextBox();
            this.registerLabel = new System.Windows.Forms.Label();
            this.registerBox = new System.Windows.Forms.TextBox();
            this.flagLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.memoryListView = new System.Windows.Forms.ListView();
            this.addressCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hexRepCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.asciiRepCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressBox = new System.Windows.Forms.TextBox();
            this.disassemblyListView = new System.Windows.Forms.ListView();
            this.disassembAddrCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instructionCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.disassembledRepCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controlsLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.breakPointButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ELF File:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(354, 9);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(35, 13);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Memory Size:";
            // 
            // memSizeLabel
            // 
            this.memSizeLabel.AutoSize = true;
            this.memSizeLabel.Location = new System.Drawing.Point(515, 9);
            this.memSizeLabel.Name = "memSizeLabel";
            this.memSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.memSizeLabel.TabIndex = 3;
            this.memSizeLabel.Text = "NULL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Checksum:";
            // 
            // checkSumLabel
            // 
            this.checkSumLabel.AutoSize = true;
            this.checkSumLabel.Location = new System.Drawing.Point(664, 9);
            this.checkSumLabel.Name = "checkSumLabel";
            this.checkSumLabel.Size = new System.Drawing.Size(35, 13);
            this.checkSumLabel.TabIndex = 8;
            this.checkSumLabel.Text = "NULL";
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryLabel.Location = new System.Drawing.Point(15, 75);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(58, 17);
            this.memoryLabel.TabIndex = 10;
            this.memoryLabel.Text = "Memory";
            // 
            // disassemblyLabel
            // 
            this.disassemblyLabel.AutoSize = true;
            this.disassemblyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disassemblyLabel.Location = new System.Drawing.Point(15, 245);
            this.disassemblyLabel.Name = "disassemblyLabel";
            this.disassemblyLabel.Size = new System.Drawing.Size(87, 17);
            this.disassemblyLabel.TabIndex = 11;
            this.disassemblyLabel.Text = "Disassembly";
            // 
            // terminalBox
            // 
            this.terminalBox.AutoSize = true;
            this.terminalBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminalBox.Location = new System.Drawing.Point(15, 539);
            this.terminalBox.Name = "terminalBox";
            this.terminalBox.Size = new System.Drawing.Size(63, 17);
            this.terminalBox.TabIndex = 13;
            this.terminalBox.Text = "Terminal";
            // 
            // terminalTextBox
            // 
            this.terminalTextBox.Location = new System.Drawing.Point(15, 559);
            this.terminalTextBox.Multiline = true;
            this.terminalTextBox.Name = "terminalTextBox";
            this.terminalTextBox.Size = new System.Drawing.Size(741, 126);
            this.terminalTextBox.TabIndex = 14;
            // 
            // stackLabel
            // 
            this.stackLabel.AutoSize = true;
            this.stackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackLabel.Location = new System.Drawing.Point(15, 403);
            this.stackLabel.Name = "stackLabel";
            this.stackLabel.Size = new System.Drawing.Size(43, 17);
            this.stackLabel.TabIndex = 15;
            this.stackLabel.Text = "Stack";
            // 
            // stackBox
            // 
            this.stackBox.Location = new System.Drawing.Point(15, 423);
            this.stackBox.Multiline = true;
            this.stackBox.Name = "stackBox";
            this.stackBox.Size = new System.Drawing.Size(740, 113);
            this.stackBox.TabIndex = 16;
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabel.Location = new System.Drawing.Point(616, 75);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(68, 17);
            this.registerLabel.TabIndex = 17;
            this.registerLabel.Text = "Registers";
            // 
            // registerBox
            // 
            this.registerBox.Location = new System.Drawing.Point(619, 95);
            this.registerBox.Multiline = true;
            this.registerBox.Name = "registerBox";
            this.registerBox.Size = new System.Drawing.Size(137, 228);
            this.registerBox.TabIndex = 18;
            // 
            // flagLabel
            // 
            this.flagLabel.AutoSize = true;
            this.flagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagLabel.Location = new System.Drawing.Point(616, 333);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(42, 17);
            this.flagLabel.TabIndex = 19;
            this.flagLabel.Text = "Flags";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(619, 353);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 49);
            this.textBox1.TabIndex = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // memoryListView
            // 
            this.memoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.addressCH,
            this.hexRepCH,
            this.asciiRepCH});
            this.memoryListView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryListView.Location = new System.Drawing.Point(15, 95);
            this.memoryListView.Name = "memoryListView";
            this.memoryListView.Size = new System.Drawing.Size(598, 147);
            this.memoryListView.TabIndex = 22;
            this.memoryListView.UseCompatibleStateImageBehavior = false;
            this.memoryListView.View = System.Windows.Forms.View.Details;
            // 
            // addressCH
            // 
            this.addressCH.Text = "Address";
            // 
            // hexRepCH
            // 
            this.hexRepCH.Text = "Hexidecimal Representation";
            this.hexRepCH.Width = 234;
            // 
            // asciiRepCH
            // 
            this.asciiRepCH.Text = "ASCII Representation";
            this.asciiRepCH.Width = 124;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(79, 74);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(100, 20);
            this.addressBox.TabIndex = 1;
            this.addressBox.Text = "Enter address";
            this.addressBox.Click += new System.EventHandler(this.addressBox_Click);
            this.addressBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addressBox_KeyPress);
            // 
            // disassemblyListView
            // 
            this.disassemblyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.disassembAddrCH,
            this.instructionCH,
            this.disassembledRepCH});
            this.disassemblyListView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disassemblyListView.Location = new System.Drawing.Point(15, 266);
            this.disassemblyListView.Name = "disassemblyListView";
            this.disassemblyListView.Size = new System.Drawing.Size(595, 136);
            this.disassemblyListView.TabIndex = 0;
            this.disassemblyListView.UseCompatibleStateImageBehavior = false;
            this.disassemblyListView.View = System.Windows.Forms.View.Details;
            // 
            // disassembAddrCH
            // 
            this.disassembAddrCH.Text = "Address";
            // 
            // instructionCH
            // 
            this.instructionCH.Text = "Instruction";
            this.instructionCH.Width = 80;
            // 
            // disassembledRepCH
            // 
            this.disassembledRepCH.Text = "Disassembled Representation";
            this.disassembledRepCH.Width = 160;
            // 
            // controlsLabel
            // 
            this.controlsLabel.AutoSize = true;
            this.controlsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsLabel.Location = new System.Drawing.Point(13, 24);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(68, 20);
            this.controlsLabel.TabIndex = 23;
            this.controlsLabel.Text = "Controls";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(17, 47);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(50, 23);
            this.runButton.TabIndex = 24;
            this.runButton.Text = "Run -->";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(73, 47);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(49, 23);
            this.stepButton.TabIndex = 25;
            this.stepButton.Text = "Step ↓";
            this.stepButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(128, 47);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(46, 23);
            this.stopButton.TabIndex = 26;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // breakPointButton
            // 
            this.breakPointButton.Location = new System.Drawing.Point(180, 47);
            this.breakPointButton.Name = "breakPointButton";
            this.breakPointButton.Size = new System.Drawing.Size(89, 23);
            this.breakPointButton.TabIndex = 27;
            this.breakPointButton.Text = "Add Breakpoint";
            this.breakPointButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.breakPointButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(275, 47);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(45, 23);
            this.resetButton.TabIndex = 28;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 697);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.breakPointButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.disassemblyListView);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.memoryListView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.registerBox);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.stackBox);
            this.Controls.Add(this.stackLabel);
            this.Controls.Add(this.terminalTextBox);
            this.Controls.Add(this.terminalBox);
            this.Controls.Add(this.disassemblyLabel);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.checkSumLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.memSizeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "armsim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label memSizeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label checkSumLabel;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.Label disassemblyLabel;
        private System.Windows.Forms.Label terminalBox;
        private System.Windows.Forms.TextBox terminalTextBox;
        private System.Windows.Forms.Label stackLabel;
        private System.Windows.Forms.TextBox stackBox;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.TextBox registerBox;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView memoryListView;
        private System.Windows.Forms.ColumnHeader addressCH;
        private System.Windows.Forms.ColumnHeader hexRepCH;
        private System.Windows.Forms.ColumnHeader asciiRepCH;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.ListView disassemblyListView;
        private System.Windows.Forms.ColumnHeader disassembAddrCH;
        private System.Windows.Forms.ColumnHeader instructionCH;
        private System.Windows.Forms.ColumnHeader disassembledRepCH;
        private System.Windows.Forms.Label controlsLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button breakPointButton;
        private System.Windows.Forms.Button resetButton;
    }
}

