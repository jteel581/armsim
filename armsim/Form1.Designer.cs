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
            this.elfFileLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.memSizeLabelLabel = new System.Windows.Forms.Label();
            this.memSizeLabel = new System.Windows.Forms.Label();
            this.checkSumLabelLabel = new System.Windows.Forms.Label();
            this.checkSumLabel = new System.Windows.Forms.Label();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.disassemblyLabel = new System.Windows.Forms.Label();
            this.terminalBox = new System.Windows.Forms.Label();
            this.terminalTextBox = new System.Windows.Forms.TextBox();
            this.stackLabel = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.Label();
            this.registerBox = new System.Windows.Forms.TextBox();
            this.flagLabel = new System.Windows.Forms.Label();
            this.flagBox = new System.Windows.Forms.TextBox();
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
            this.stackListView = new System.Windows.Forms.ListView();
            this.stackAddressCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stackValCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.traceLabelLabel = new System.Windows.Forms.Label();
            this.traceStatusLabel = new System.Windows.Forms.Label();
            this.breakPointsLabelLabel = new System.Windows.Forms.Label();
            this.breakPointsStatusLabel = new System.Windows.Forms.Label();
            this.traceButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.breakPointButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elfFileLabel
            // 
            this.elfFileLabel.AutoSize = true;
            this.elfFileLabel.Location = new System.Drawing.Point(60, 9);
            this.elfFileLabel.Name = "elfFileLabel";
            this.elfFileLabel.Size = new System.Drawing.Size(48, 13);
            this.elfFileLabel.TabIndex = 0;
            this.elfFileLabel.Text = "ELF File:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(114, 9);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 13);
            this.fileNameLabel.TabIndex = 1;
            // 
            // memSizeLabelLabel
            // 
            this.memSizeLabelLabel.AutoSize = true;
            this.memSizeLabelLabel.Location = new System.Drawing.Point(199, 9);
            this.memSizeLabelLabel.Name = "memSizeLabelLabel";
            this.memSizeLabelLabel.Size = new System.Drawing.Size(70, 13);
            this.memSizeLabelLabel.TabIndex = 2;
            this.memSizeLabelLabel.Text = "Memory Size:";
            // 
            // memSizeLabel
            // 
            this.memSizeLabel.AutoSize = true;
            this.memSizeLabel.Location = new System.Drawing.Point(275, 9);
            this.memSizeLabel.Name = "memSizeLabel";
            this.memSizeLabel.Size = new System.Drawing.Size(0, 13);
            this.memSizeLabel.TabIndex = 3;
            // 
            // checkSumLabelLabel
            // 
            this.checkSumLabelLabel.AutoSize = true;
            this.checkSumLabelLabel.Location = new System.Drawing.Point(358, 9);
            this.checkSumLabelLabel.Name = "checkSumLabelLabel";
            this.checkSumLabelLabel.Size = new System.Drawing.Size(60, 13);
            this.checkSumLabelLabel.TabIndex = 7;
            this.checkSumLabelLabel.Text = "Checksum:";
            // 
            // checkSumLabel
            // 
            this.checkSumLabel.AutoSize = true;
            this.checkSumLabel.Location = new System.Drawing.Point(424, 9);
            this.checkSumLabel.Name = "checkSumLabel";
            this.checkSumLabel.Size = new System.Drawing.Size(0, 13);
            this.checkSumLabel.TabIndex = 8;
            // 
            // memoryLabel
            // 
            this.memoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.terminalBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.terminalBox.AutoSize = true;
            this.terminalBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminalBox.Location = new System.Drawing.Point(12, 415);
            this.terminalBox.Name = "terminalBox";
            this.terminalBox.Size = new System.Drawing.Size(63, 17);
            this.terminalBox.TabIndex = 13;
            this.terminalBox.Text = "Terminal";
            // 
            // terminalTextBox
            // 
            this.terminalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.terminalTextBox.Location = new System.Drawing.Point(15, 435);
            this.terminalTextBox.Multiline = true;
            this.terminalTextBox.Name = "terminalTextBox";
            this.terminalTextBox.Size = new System.Drawing.Size(580, 250);
            this.terminalTextBox.TabIndex = 14;
            // 
            // stackLabel
            // 
            this.stackLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stackLabel.AutoSize = true;
            this.stackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackLabel.Location = new System.Drawing.Point(598, 415);
            this.stackLabel.Name = "stackLabel";
            this.stackLabel.Size = new System.Drawing.Size(43, 17);
            this.stackLabel.TabIndex = 15;
            this.stackLabel.Text = "Stack";
            // 
            // registerLabel
            // 
            this.registerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.registerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registerBox.Location = new System.Drawing.Point(619, 95);
            this.registerBox.Multiline = true;
            this.registerBox.Name = "registerBox";
            this.registerBox.Size = new System.Drawing.Size(137, 228);
            this.registerBox.TabIndex = 18;
            // 
            // flagLabel
            // 
            this.flagLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flagLabel.AutoSize = true;
            this.flagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagLabel.Location = new System.Drawing.Point(616, 333);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(42, 17);
            this.flagLabel.TabIndex = 19;
            this.flagLabel.Text = "Flags";
            // 
            // flagBox
            // 
            this.flagBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flagBox.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagBox.Location = new System.Drawing.Point(619, 353);
            this.flagBox.Multiline = true;
            this.flagBox.Name = "flagBox";
            this.flagBox.Size = new System.Drawing.Size(137, 49);
            this.flagBox.TabIndex = 20;
            this.flagBox.Text = "0000";
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
            this.memoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.disassemblyListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disassemblyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.disassembAddrCH,
            this.instructionCH,
            this.disassembledRepCH});
            this.disassemblyListView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disassemblyListView.Location = new System.Drawing.Point(15, 266);
            this.disassemblyListView.Name = "disassemblyListView";
            this.disassemblyListView.Size = new System.Drawing.Size(598, 136);
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
            // stackListView
            // 
            this.stackListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stackListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stackAddressCH,
            this.stackValCH});
            this.stackListView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackListView.Location = new System.Drawing.Point(601, 435);
            this.stackListView.Name = "stackListView";
            this.stackListView.Size = new System.Drawing.Size(155, 250);
            this.stackListView.TabIndex = 29;
            this.stackListView.UseCompatibleStateImageBehavior = false;
            this.stackListView.View = System.Windows.Forms.View.Details;
            // 
            // stackAddressCH
            // 
            this.stackAddressCH.Text = "Address";
            // 
            // stackValCH
            // 
            this.stackValCH.Text = "Value";
            // 
            // traceLabelLabel
            // 
            this.traceLabelLabel.AutoSize = true;
            this.traceLabelLabel.Location = new System.Drawing.Point(532, 9);
            this.traceLabelLabel.Name = "traceLabelLabel";
            this.traceLabelLabel.Size = new System.Drawing.Size(38, 13);
            this.traceLabelLabel.TabIndex = 31;
            this.traceLabelLabel.Text = "Trace:";
            // 
            // traceStatusLabel
            // 
            this.traceStatusLabel.AutoSize = true;
            this.traceStatusLabel.Location = new System.Drawing.Point(577, 9);
            this.traceStatusLabel.Name = "traceStatusLabel";
            this.traceStatusLabel.Size = new System.Drawing.Size(46, 13);
            this.traceStatusLabel.TabIndex = 32;
            this.traceStatusLabel.Text = "Enabled";
            // 
            // breakPointsLabelLabel
            // 
            this.breakPointsLabelLabel.AutoSize = true;
            this.breakPointsLabelLabel.Location = new System.Drawing.Point(630, 9);
            this.breakPointsLabelLabel.Name = "breakPointsLabelLabel";
            this.breakPointsLabelLabel.Size = new System.Drawing.Size(66, 13);
            this.breakPointsLabelLabel.TabIndex = 33;
            this.breakPointsLabelLabel.Text = "Breakpoints:";
            // 
            // breakPointsStatusLabel
            // 
            this.breakPointsStatusLabel.AutoSize = true;
            this.breakPointsStatusLabel.Location = new System.Drawing.Point(703, 9);
            this.breakPointsStatusLabel.Name = "breakPointsStatusLabel";
            this.breakPointsStatusLabel.Size = new System.Drawing.Size(46, 13);
            this.breakPointsStatusLabel.TabIndex = 34;
            this.breakPointsStatusLabel.Text = "Enabled";
            // 
            // traceButton
            // 
            this.traceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traceButton.Image = global::armsim.Properties.Resources.traceIcon;
            this.traceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.traceButton.Location = new System.Drawing.Point(416, 43);
            this.traceButton.Name = "traceButton";
            this.traceButton.Size = new System.Drawing.Size(110, 27);
            this.traceButton.TabIndex = 30;
            this.traceButton.Text = "Toggle Trace";
            this.traceButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.traceButton.UseVisualStyleBackColor = true;
            this.traceButton.Click += new System.EventHandler(this.traceButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Image = global::armsim.Properties.Resources.resetIcon;
            this.resetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetButton.Location = new System.Drawing.Point(341, 42);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(69, 28);
            this.resetButton.TabIndex = 28;
            this.resetButton.Text = "Reset";
            this.resetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // breakPointButton
            // 
            this.breakPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakPointButton.Image = global::armsim.Properties.Resources.breakpointIcon;
            this.breakPointButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.breakPointButton.Location = new System.Drawing.Point(212, 42);
            this.breakPointButton.Name = "breakPointButton";
            this.breakPointButton.Size = new System.Drawing.Size(123, 28);
            this.breakPointButton.TabIndex = 27;
            this.breakPointButton.Text = "Add Breakpoint";
            this.breakPointButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.breakPointButton.UseVisualStyleBackColor = true;
            this.breakPointButton.Click += new System.EventHandler(this.breakPointButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Image = global::armsim.Properties.Resources.stopIcon;
            this.stopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopButton.Location = new System.Drawing.Point(145, 42);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(61, 28);
            this.stopButton.TabIndex = 26;
            this.stopButton.Text = "Stop";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepButton.Image = global::armsim.Properties.Resources.stepIcon;
            this.stepButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stepButton.Location = new System.Drawing.Point(79, 42);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(60, 28);
            this.stepButton.TabIndex = 25;
            this.stepButton.Text = "Step";
            this.stepButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Image = global::armsim.Properties.Resources.runIcon;
            this.runButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.runButton.Location = new System.Drawing.Point(15, 42);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(58, 28);
            this.runButton.TabIndex = 24;
            this.runButton.Text = "Run";
            this.runButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.runButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 697);
            this.Controls.Add(this.breakPointsStatusLabel);
            this.Controls.Add(this.breakPointsLabelLabel);
            this.Controls.Add(this.traceStatusLabel);
            this.Controls.Add(this.traceLabelLabel);
            this.Controls.Add(this.traceButton);
            this.Controls.Add(this.stackListView);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.breakPointButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.disassemblyListView);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.memoryListView);
            this.Controls.Add(this.flagBox);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.registerBox);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.stackLabel);
            this.Controls.Add(this.terminalTextBox);
            this.Controls.Add(this.terminalBox);
            this.Controls.Add(this.disassemblyLabel);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.checkSumLabel);
            this.Controls.Add(this.checkSumLabelLabel);
            this.Controls.Add(this.memSizeLabel);
            this.Controls.Add(this.memSizeLabelLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.elfFileLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "armsim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elfFileLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label memSizeLabelLabel;
        private System.Windows.Forms.Label memSizeLabel;
        private System.Windows.Forms.Label checkSumLabelLabel;
        private System.Windows.Forms.Label checkSumLabel;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.Label disassemblyLabel;
        private System.Windows.Forms.Label terminalBox;
        private System.Windows.Forms.TextBox terminalTextBox;
        private System.Windows.Forms.Label stackLabel;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.TextBox registerBox;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.TextBox flagBox;
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
        private System.Windows.Forms.ListView stackListView;
        private System.Windows.Forms.ColumnHeader stackAddressCH;
        private System.Windows.Forms.ColumnHeader stackValCH;
        private System.Windows.Forms.Button traceButton;
        private System.Windows.Forms.Label traceLabelLabel;
        private System.Windows.Forms.Label traceStatusLabel;
        private System.Windows.Forms.Label breakPointsLabelLabel;
        private System.Windows.Forms.Label breakPointsStatusLabel;
    }
}

