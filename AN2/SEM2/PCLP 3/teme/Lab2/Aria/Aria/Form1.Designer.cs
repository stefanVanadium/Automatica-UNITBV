namespace Aria
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
            this.textLen = new System.Windows.Forms.TextBox();
            this.labelLen = new System.Windows.Forms.Label();
            this.textWid = new System.Windows.Forms.TextBox();
            this.labelLat = new System.Windows.Forms.Label();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.labelRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textLen
            // 
            this.textLen.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLen.Location = new System.Drawing.Point(181, 35);
            this.textLen.Name = "textLen";
            this.textLen.Size = new System.Drawing.Size(525, 52);
            this.textLen.TabIndex = 0;
            this.textLen.TextChanged += new System.EventHandler(this.textGetData);
            // 
            // labelLen
            // 
            this.labelLen.AutoSize = true;
            this.labelLen.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLen.Location = new System.Drawing.Point(34, 39);
            this.labelLen.Margin = new System.Windows.Forms.Padding(3);
            this.labelLen.Name = "labelLen";
            this.labelLen.Size = new System.Drawing.Size(123, 45);
            this.labelLen.TabIndex = 1;
            this.labelLen.Text = "Length";
            // 
            // textWid
            // 
            this.textWid.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWid.Location = new System.Drawing.Point(181, 111);
            this.textWid.Name = "textWid";
            this.textWid.Size = new System.Drawing.Size(525, 52);
            this.textWid.TabIndex = 0;
            this.textWid.TextChanged += new System.EventHandler(this.textGetData);
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLat.Location = new System.Drawing.Point(34, 115);
            this.labelLat.Margin = new System.Windows.Forms.Padding(3);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(115, 45);
            this.labelLat.TabIndex = 1;
            this.labelLat.Text = "Width";
            // 
            // buttonCalc
            // 
            this.buttonCalc.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalc.Location = new System.Drawing.Point(42, 208);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(664, 72);
            this.buttonCalc.TabIndex = 2;
            this.buttonCalc.Text = "! Calculate !";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRes.Location = new System.Drawing.Point(45, 301);
            this.labelRes.MaximumSize = new System.Drawing.Size(661, 144);
            this.labelRes.MinimumSize = new System.Drawing.Size(661, 144);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(661, 144);
            this.labelRes.TabIndex = 3;
            this.labelRes.Text = "🗿";
            this.labelRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 471);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.buttonCalc);
            this.Controls.Add(this.labelLat);
            this.Controls.Add(this.labelLen);
            this.Controls.Add(this.textWid);
            this.Controls.Add(this.textLen);
            this.Name = "Form1";
            this.Text = "Area Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textLen;
        private System.Windows.Forms.Label labelLen;
        private System.Windows.Forms.TextBox textWid;
        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Label labelRes;
    }
}

