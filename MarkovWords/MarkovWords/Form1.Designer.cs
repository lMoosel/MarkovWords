
namespace MarkovWords
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
            this.btnGen = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnGenGerm = new System.Windows.Forms.Button();
            this.btnGenerateProb = new System.Windows.Forms.Button();
            this.btnHawaiian = new System.Windows.Forms.Button();
            this.btnLatin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(12, 12);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(135, 23);
            this.btnGen.TabIndex = 0;
            this.btnGen.Text = "Generate New Word";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(9, 190);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(72, 13);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Markov Word";
            // 
            // btnGenGerm
            // 
            this.btnGenGerm.Enabled = false;
            this.btnGenGerm.Location = new System.Drawing.Point(12, 41);
            this.btnGenGerm.Name = "btnGenGerm";
            this.btnGenGerm.Size = new System.Drawing.Size(135, 23);
            this.btnGenGerm.TabIndex = 2;
            this.btnGenGerm.Text = "Generate Neu Wort";
            this.btnGenGerm.UseVisualStyleBackColor = true;
            this.btnGenGerm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerateProb
            // 
            this.btnGenerateProb.Location = new System.Drawing.Point(383, 12);
            this.btnGenerateProb.Name = "btnGenerateProb";
            this.btnGenerateProb.Size = new System.Drawing.Size(65, 23);
            this.btnGenerateProb.TabIndex = 3;
            this.btnGenerateProb.Text = "Get Probs";
            this.btnGenerateProb.UseVisualStyleBackColor = true;
            this.btnGenerateProb.Click += new System.EventHandler(this.btnGenerateProb_Click);
            // 
            // btnHawaiian
            // 
            this.btnHawaiian.Enabled = false;
            this.btnHawaiian.Location = new System.Drawing.Point(12, 70);
            this.btnHawaiian.Name = "btnHawaiian";
            this.btnHawaiian.Size = new System.Drawing.Size(135, 23);
            this.btnHawaiian.TabIndex = 4;
            this.btnHawaiian.Text = "Generate huaʻōlelo hou";
            this.btnHawaiian.UseVisualStyleBackColor = true;
            this.btnHawaiian.Click += new System.EventHandler(this.btnHawaiian_Click);
            // 
            // btnLatin
            // 
            this.btnLatin.Location = new System.Drawing.Point(12, 99);
            this.btnLatin.Name = "btnLatin";
            this.btnLatin.Size = new System.Drawing.Size(135, 23);
            this.btnLatin.TabIndex = 5;
            this.btnLatin.Text = "Generate Novum Verbum\r\n";
            this.btnLatin.UseVisualStyleBackColor = true;
            this.btnLatin.Click += new System.EventHandler(this.btnLatin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 212);
            this.Controls.Add(this.btnLatin);
            this.Controls.Add(this.btnHawaiian);
            this.Controls.Add(this.btnGenerateProb);
            this.Controls.Add(this.btnGenGerm);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnGen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnGenGerm;
        private System.Windows.Forms.Button btnGenerateProb;
        private System.Windows.Forms.Button btnHawaiian;
        private System.Windows.Forms.Button btnLatin;
    }
}

