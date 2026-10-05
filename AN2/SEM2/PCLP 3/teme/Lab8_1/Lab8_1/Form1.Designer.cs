namespace Lab8_1
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
            this.cbTipFigura = new System.Windows.Forms.ComboBox();
            this.tbNume = new System.Windows.Forms.TextBox();
            this.tbDim2 = new System.Windows.Forms.TextBox();
            this.tbDim1 = new System.Windows.Forms.TextBox();
            this.tbDim3 = new System.Windows.Forms.TextBox();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnTotaluri = new System.Windows.Forms.Button();
            this.lbxFiguri = new System.Windows.Forms.ListBox();
            this.pnlDesen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTotaluri = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSortare = new System.Windows.Forms.Button();
            this.btnFiltrare = new System.Windows.Forms.Button();
            this.tbFiltru = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbScalare = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnScalare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTipFigura
            // 
            this.cbTipFigura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipFigura.FormattingEnabled = true;
            this.cbTipFigura.Items.AddRange(new object[] {
            "Cerc",
            "Elipsa",
            "Dreptunghi",
            "Patrat",
            "Triunghi"});
            this.cbTipFigura.Location = new System.Drawing.Point(358, 61);
            this.cbTipFigura.Name = "cbTipFigura";
            this.cbTipFigura.Size = new System.Drawing.Size(239, 28);
            this.cbTipFigura.TabIndex = 0;
            // 
            // tbNume
            // 
            this.tbNume.Location = new System.Drawing.Point(358, 103);
            this.tbNume.Name = "tbNume";
            this.tbNume.Size = new System.Drawing.Size(239, 26);
            this.tbNume.TabIndex = 1;
            // 
            // tbDim2
            // 
            this.tbDim2.Location = new System.Drawing.Point(358, 183);
            this.tbDim2.Name = "tbDim2";
            this.tbDim2.Size = new System.Drawing.Size(239, 26);
            this.tbDim2.TabIndex = 1;
            // 
            // tbDim1
            // 
            this.tbDim1.Location = new System.Drawing.Point(358, 143);
            this.tbDim1.Name = "tbDim1";
            this.tbDim1.Size = new System.Drawing.Size(239, 26);
            this.tbDim1.TabIndex = 1;
            // 
            // tbDim3
            // 
            this.tbDim3.Location = new System.Drawing.Point(358, 223);
            this.tbDim3.Name = "tbDim3";
            this.tbDim3.Size = new System.Drawing.Size(239, 26);
            this.tbDim3.TabIndex = 1;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(16, 370);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(203, 50);
            this.btnAdauga.TabIndex = 2;
            this.btnAdauga.Text = "Adauga Figura";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(225, 370);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(150, 50);
            this.btnSterge.TabIndex = 3;
            this.btnSterge.Text = "Sterge Selectate";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnTotaluri
            // 
            this.btnTotaluri.Location = new System.Drawing.Point(381, 370);
            this.btnTotaluri.Name = "btnTotaluri";
            this.btnTotaluri.Size = new System.Drawing.Size(215, 50);
            this.btnTotaluri.TabIndex = 4;
            this.btnTotaluri.Text = "Calculeaza Totaluri";
            this.btnTotaluri.UseVisualStyleBackColor = true;
            this.btnTotaluri.Click += new System.EventHandler(this.btnTotaluri_Click);
            // 
            // lbxFiguri
            // 
            this.lbxFiguri.FormattingEnabled = true;
            this.lbxFiguri.ItemHeight = 20;
            this.lbxFiguri.Location = new System.Drawing.Point(16, 485);
            this.lbxFiguri.Name = "lbxFiguri";
            this.lbxFiguri.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxFiguri.Size = new System.Drawing.Size(580, 304);
            this.lbxFiguri.TabIndex = 5;
            // 
            // pnlDesen
            // 
            this.pnlDesen.BackColor = System.Drawing.Color.White;
            this.pnlDesen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDesen.Location = new System.Drawing.Point(617, 143);
            this.pnlDesen.Name = "pnlDesen";
            this.pnlDesen.Size = new System.Drawing.Size(610, 646);
            this.pnlDesen.TabIndex = 7;
            this.pnlDesen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDesen_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selectarea tipului figurii: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Numele figurii: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prima dimensiune (Raza / Lungime / Latura A): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "A doua dimensiune (Raza / Latime / Latura B): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "A treia dimensiune (Latura C):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(613, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Zona Desenare: ";
            // 
            // lbTotaluri
            // 
            this.lbTotaluri.AutoSize = true;
            this.lbTotaluri.Location = new System.Drawing.Point(747, 65);
            this.lbTotaluri.Name = "lbTotaluri";
            this.lbTotaluri.Size = new System.Drawing.Size(22, 20);
            this.lbTotaluri.TabIndex = 9;
            this.lbTotaluri.Text = " - ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Arii si Perimetre: ";
            // 
            // btnSortare
            // 
            this.btnSortare.Location = new System.Drawing.Point(225, 426);
            this.btnSortare.Name = "btnSortare";
            this.btnSortare.Size = new System.Drawing.Size(150, 50);
            this.btnSortare.TabIndex = 4;
            this.btnSortare.Text = "Sortare dupa Arie";
            this.btnSortare.UseVisualStyleBackColor = true;
            this.btnSortare.Click += new System.EventHandler(this.btnSortare_Click);
            // 
            // btnFiltrare
            // 
            this.btnFiltrare.Location = new System.Drawing.Point(16, 426);
            this.btnFiltrare.Name = "btnFiltrare";
            this.btnFiltrare.Size = new System.Drawing.Size(203, 50);
            this.btnFiltrare.TabIndex = 4;
            this.btnFiltrare.Text = "Filtrare perimetru";
            this.btnFiltrare.UseVisualStyleBackColor = true;
            this.btnFiltrare.Click += new System.EventHandler(this.btnFiltrare_Click);
            // 
            // tbFiltru
            // 
            this.tbFiltru.Location = new System.Drawing.Point(357, 269);
            this.tbFiltru.Name = "tbFiltru";
            this.tbFiltru.Size = new System.Drawing.Size(239, 26);
            this.tbFiltru.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Filtru perimetru:";
            // 
            // tbScalare
            // 
            this.tbScalare.Location = new System.Drawing.Point(358, 315);
            this.tbScalare.Name = "tbScalare";
            this.tbScalare.Size = new System.Drawing.Size(239, 26);
            this.tbScalare.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Factor scalare:";
            // 
            // btnScalare
            // 
            this.btnScalare.Location = new System.Drawing.Point(381, 426);
            this.btnScalare.Name = "btnScalare";
            this.btnScalare.Size = new System.Drawing.Size(215, 50);
            this.btnScalare.TabIndex = 4;
            this.btnScalare.Text = "Scaleaza selectate";
            this.btnScalare.UseVisualStyleBackColor = true;
            this.btnScalare.Click += new System.EventHandler(this.btnScalare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 812);
            this.Controls.Add(this.btnTotaluri);
            this.Controls.Add(this.lbTotaluri);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDesen);
            this.Controls.Add(this.lbxFiguri);
            this.Controls.Add(this.btnFiltrare);
            this.Controls.Add(this.btnScalare);
            this.Controls.Add(this.btnSortare);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.tbScalare);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.tbFiltru);
            this.Controls.Add(this.tbDim3);
            this.Controls.Add(this.tbDim1);
            this.Controls.Add(this.tbDim2);
            this.Controls.Add(this.tbNume);
            this.Controls.Add(this.cbTipFigura);
            this.Name = "Form1";
            this.Text = "Gestionar figuri";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipFigura;
        private System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.TextBox tbDim2;
        private System.Windows.Forms.TextBox tbDim1;
        private System.Windows.Forms.TextBox tbDim3;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnTotaluri;
        private System.Windows.Forms.ListBox lbxFiguri;
        private System.Windows.Forms.Panel pnlDesen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTotaluri;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSortare;
        private System.Windows.Forms.Button btnFiltrare;
        private System.Windows.Forms.TextBox tbFiltru;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbScalare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnScalare;
    }
}

