namespace Lab9
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
            this.lbSold = new System.Windows.Forms.Label();
            this.tbSuma = new System.Windows.Forms.TextBox();
            this.tbComentariu = new System.Windows.Forms.TextBox();
            this.btnDepune = new System.Windows.Forms.Button();
            this.btnRetrage = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbxTranzactii = new System.Windows.Forms.ListBox();
            this.lbxErori = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnIncarca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSold
            // 
            this.lbSold.AutoSize = true;
            this.lbSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSold.Location = new System.Drawing.Point(529, 41);
            this.lbSold.Name = "lbSold";
            this.lbSold.Size = new System.Drawing.Size(163, 25);
            this.lbSold.TabIndex = 0;
            this.lbSold.Text = "Sold: 0,00 RON";
            // 
            // tbSuma
            // 
            this.tbSuma.Location = new System.Drawing.Point(139, 38);
            this.tbSuma.Name = "tbSuma";
            this.tbSuma.Size = new System.Drawing.Size(376, 26);
            this.tbSuma.TabIndex = 1;
            // 
            // tbComentariu
            // 
            this.tbComentariu.Location = new System.Drawing.Point(139, 82);
            this.tbComentariu.Multiline = true;
            this.tbComentariu.Name = "tbComentariu";
            this.tbComentariu.Size = new System.Drawing.Size(376, 100);
            this.tbComentariu.TabIndex = 2;
            // 
            // btnDepune
            // 
            this.btnDepune.Location = new System.Drawing.Point(31, 198);
            this.btnDepune.Name = "btnDepune";
            this.btnDepune.Size = new System.Drawing.Size(150, 100);
            this.btnDepune.TabIndex = 3;
            this.btnDepune.Text = "Depune";
            this.btnDepune.UseVisualStyleBackColor = true;
            this.btnDepune.Click += new System.EventHandler(this.btnDepune_Click);
            // 
            // btnRetrage
            // 
            this.btnRetrage.Location = new System.Drawing.Point(198, 198);
            this.btnRetrage.Name = "btnRetrage";
            this.btnRetrage.Size = new System.Drawing.Size(150, 100);
            this.btnRetrage.TabIndex = 4;
            this.btnRetrage.Text = "Retrage";
            this.btnRetrage.UseVisualStyleBackColor = true;
            this.btnRetrage.Click += new System.EventHandler(this.btnRetrage_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(365, 198);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 100);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbxTranzactii
            // 
            this.lbxTranzactii.FormattingEnabled = true;
            this.lbxTranzactii.ItemHeight = 20;
            this.lbxTranzactii.Location = new System.Drawing.Point(31, 343);
            this.lbxTranzactii.Name = "lbxTranzactii";
            this.lbxTranzactii.Size = new System.Drawing.Size(484, 384);
            this.lbxTranzactii.TabIndex = 6;
            // 
            // lbxErori
            // 
            this.lbxErori.ForeColor = System.Drawing.Color.Red;
            this.lbxErori.FormattingEnabled = true;
            this.lbxErori.ItemHeight = 20;
            this.lbxErori.Location = new System.Drawing.Point(534, 343);
            this.lbxErori.Name = "lbxErori";
            this.lbxErori.Size = new System.Drawing.Size(934, 384);
            this.lbxErori.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Suma:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Comentariu:";
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(534, 198);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(236, 100);
            this.btnSalvare.TabIndex = 3;
            this.btnSalvare.Text = "Salveaza Tranzactiile";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnIncarca
            // 
            this.btnIncarca.Location = new System.Drawing.Point(782, 198);
            this.btnIncarca.Name = "btnIncarca";
            this.btnIncarca.Size = new System.Drawing.Size(236, 100);
            this.btnIncarca.TabIndex = 3;
            this.btnIncarca.Text = "Incarca Tranzactiile";
            this.btnIncarca.UseVisualStyleBackColor = true;
            this.btnIncarca.Click += new System.EventHandler(this.btnIncarca_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 755);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxErori);
            this.Controls.Add(this.lbxTranzactii);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRetrage);
            this.Controls.Add(this.btnIncarca);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnDepune);
            this.Controls.Add(this.tbComentariu);
            this.Controls.Add(this.tbSuma);
            this.Controls.Add(this.lbSold);
            this.Name = "Form1";
            this.Text = "Gestionar Cont";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSold;
        private System.Windows.Forms.TextBox tbSuma;
        private System.Windows.Forms.TextBox tbComentariu;
        private System.Windows.Forms.Button btnDepune;
        private System.Windows.Forms.Button btnRetrage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListBox lbxTranzactii;
        private System.Windows.Forms.ListBox lbxErori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnIncarca;
    }
}

