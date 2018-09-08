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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ELF File:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(78, 33);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(35, 13);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Memory Size:";
            // 
            // memSizeLabel
            // 
            this.memSizeLabel.AutoSize = true;
            this.memSizeLabel.Location = new System.Drawing.Point(78, 50);
            this.memSizeLabel.Name = "memSizeLabel";
            this.memSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.memSizeLabel.TabIndex = 3;
            this.memSizeLabel.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Test Status:";
            // 
            // testStatusLabel
            // 
            this.testStatusLabel.AutoSize = true;
            this.testStatusLabel.Location = new System.Drawing.Point(78, 67);
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
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Checksum:";
            // 
            // checkSumLabel
            // 
            this.checkSumLabel.AutoSize = true;
            this.checkSumLabel.Location = new System.Drawing.Point(79, 89);
            this.checkSumLabel.Name = "checkSumLabel";
            this.checkSumLabel.Size = new System.Drawing.Size(35, 13);
            this.checkSumLabel.TabIndex = 8;
            this.checkSumLabel.Text = "NULL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 120);
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
    }
}

