namespace TempConverter
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
            this.textTemp = new System.Windows.Forms.TextBox();
            this.labelTemp = new System.Windows.Forms.Label();
            this.buttonConvFC = new System.Windows.Forms.Button();
            this.labelRes = new System.Windows.Forms.Label();
            this.buttonConvCF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textTemp
            // 
            this.textTemp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTemp.Location = new System.Drawing.Point(244, 24);
            this.textTemp.Name = "textTemp";
            this.textTemp.Size = new System.Drawing.Size(530, 52);
            this.textTemp.TabIndex = 0;
            this.textTemp.TextChanged += new System.EventHandler(this.textTemp_TextChanged);
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemp.Location = new System.Drawing.Point(22, 24);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(216, 45);
            this.labelTemp.TabIndex = 1;
            this.labelTemp.Text = "Temperature";
            // 
            // buttonConvFC
            // 
            this.buttonConvFC.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvFC.Location = new System.Drawing.Point(30, 93);
            this.buttonConvFC.Name = "buttonConvFC";
            this.buttonConvFC.Size = new System.Drawing.Size(372, 66);
            this.buttonConvFC.TabIndex = 2;
            this.buttonConvFC.Text = "! F -> C !";
            this.buttonConvFC.UseVisualStyleBackColor = true;
            this.buttonConvFC.Click += new System.EventHandler(this.convertButtons_Click);
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRes.Location = new System.Drawing.Point(30, 196);
            this.labelRes.MaximumSize = new System.Drawing.Size(744, 66);
            this.labelRes.MinimumSize = new System.Drawing.Size(744, 66);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(744, 66);
            this.labelRes.TabIndex = 3;
            this.labelRes.Text = "Type something and convert!";
            this.labelRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvCF
            // 
            this.buttonConvCF.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvCF.Location = new System.Drawing.Point(402, 93);
            this.buttonConvCF.Name = "buttonConvCF";
            this.buttonConvCF.Size = new System.Drawing.Size(372, 66);
            this.buttonConvCF.TabIndex = 2;
            this.buttonConvCF.Text = "! C -> F !";
            this.buttonConvCF.UseVisualStyleBackColor = true;
            this.buttonConvCF.Click += new System.EventHandler(this.convertButtons_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 302);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.buttonConvCF);
            this.Controls.Add(this.buttonConvFC);
            this.Controls.Add(this.labelTemp);
            this.Controls.Add(this.textTemp);
            this.Name = "Form1";
            this.Text = "Temperature Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTemp;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Button buttonConvFC;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Button buttonConvCF;
    }
}

