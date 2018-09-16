namespace armsim
{
    partial class breakPointDialogBox
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
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.setBreakpointButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.Location = new System.Drawing.Point(3, 9);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(132, 17);
            this.addressLabel.TabIndex = 0;
            this.addressLabel.Text = "Breakpoint Address";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(137, 8);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(144, 20);
            this.addressBox.TabIndex = 1;
            this.addressBox.Text = "Enter an 8-digit hex address";
            this.addressBox.Click += new System.EventHandler(this.addressBox_Click);
            // 
            // setBreakpointButton
            // 
            this.setBreakpointButton.Location = new System.Drawing.Point(89, 34);
            this.setBreakpointButton.Name = "setBreakpointButton";
            this.setBreakpointButton.Size = new System.Drawing.Size(91, 23);
            this.setBreakpointButton.TabIndex = 2;
            this.setBreakpointButton.Text = "Set Breakpoint";
            this.setBreakpointButton.UseVisualStyleBackColor = true;
            this.setBreakpointButton.Click += new System.EventHandler(this.setBreakpointButton_Click);
            // 
            // breakPointDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 71);
            this.Controls.Add(this.setBreakpointButton);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.addressLabel);
            this.Name = "breakPointDialogBox";
            this.Text = "Set Breakpoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button setBreakpointButton;
    }
}