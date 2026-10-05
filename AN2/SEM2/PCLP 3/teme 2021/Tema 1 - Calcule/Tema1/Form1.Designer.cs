
namespace Tema1
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
            this.components = new System.ComponentModel.Container();
            this.Termen1 = new System.Windows.Forms.TextBox();
            this.Termen2 = new System.Windows.Forms.TextBox();
            this.Semn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Rezultat = new System.Windows.Forms.TextBox();
            this.Calculeaza = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Termen1
            // 
            this.Termen1.Location = new System.Drawing.Point(23, 37);
            this.Termen1.Name = "Termen1";
            this.Termen1.Size = new System.Drawing.Size(56, 22);
            this.Termen1.TabIndex = 0;
            this.Termen1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Termen1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Termen2
            // 
            this.Termen2.Location = new System.Drawing.Point(140, 37);
            this.Termen2.Name = "Termen2";
            this.Termen2.Size = new System.Drawing.Size(56, 22);
            this.Termen2.TabIndex = 1;
            this.Termen2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Semn
            // 
            this.Semn.Location = new System.Drawing.Point(94, 37);
            this.Semn.Name = "Semn";
            this.Semn.Size = new System.Drawing.Size(30, 22);
            this.Semn.TabIndex = 2;
            this.Semn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Semn.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "=";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Rezultat
            // 
            this.Rezultat.Location = new System.Drawing.Point(242, 37);
            this.Rezultat.Name = "Rezultat";
            this.Rezultat.ReadOnly = true;
            this.Rezultat.Size = new System.Drawing.Size(56, 22);
            this.Rezultat.TabIndex = 6;
            this.Rezultat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Rezultat.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // Calculeaza
            // 
            this.Calculeaza.Location = new System.Drawing.Point(304, 36);
            this.Calculeaza.Name = "Calculeaza";
            this.Calculeaza.Size = new System.Drawing.Size(90, 24);
            this.Calculeaza.TabIndex = 7;
            this.Calculeaza.Text = "Calculeaza";
            this.Calculeaza.UseVisualStyleBackColor = true;
            this.Calculeaza.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rezultat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 89);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Calculeaza);
            this.Controls.Add(this.Rezultat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Semn);
            this.Controls.Add(this.Termen2);
            this.Controls.Add(this.Termen1);
            this.Name = "Form1";
            this.Text = "Calcule";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Termen1;
        private System.Windows.Forms.TextBox Termen2;
        private System.Windows.Forms.TextBox Semn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox Rezultat;
        private System.Windows.Forms.Button Calculeaza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

