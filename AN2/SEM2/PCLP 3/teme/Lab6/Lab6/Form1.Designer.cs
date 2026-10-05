namespace Lab6
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
            this.btnAddFile = new System.Windows.Forms.Button();
            this.lbFileSel = new System.Windows.Forms.Label();
            this.lbSum = new System.Windows.Forms.Label();
            this.lbMedia = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(12, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(48, 46);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "+";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // lbFileSel
            // 
            this.lbFileSel.AutoSize = true;
            this.lbFileSel.Location = new System.Drawing.Point(75, 25);
            this.lbFileSel.Name = "lbFileSel";
            this.lbFileSel.Size = new System.Drawing.Size(38, 20);
            this.lbFileSel.TabIndex = 1;
            this.lbFileSel.Text = "File:";
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Location = new System.Drawing.Point(12, 77);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(55, 20);
            this.lbSum.TabIndex = 2;
            this.lbSum.Text = "Suma:";
            // 
            // lbMedia
            // 
            this.lbMedia.AutoSize = true;
            this.lbMedia.Location = new System.Drawing.Point(12, 111);
            this.lbMedia.Name = "lbMedia";
            this.lbMedia.Size = new System.Drawing.Size(60, 20);
            this.lbMedia.TabIndex = 2;
            this.lbMedia.Text = "Media: ";
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(12, 145);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(38, 20);
            this.lbMin.TabIndex = 2;
            this.lbMin.Text = "Min:";
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(12, 179);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(42, 20);
            this.lbMax.TabIndex = 2;
            this.lbMax.Text = "Max:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 222);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.lbMedia);
            this.Controls.Add(this.lbSum);
            this.Controls.Add(this.lbFileSel);
            this.Controls.Add(this.btnAddFile);
            this.Name = "Form1";
            this.Text = "Operatii cu numere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Label lbFileSel;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Label lbMedia;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbMax;
    }
}

