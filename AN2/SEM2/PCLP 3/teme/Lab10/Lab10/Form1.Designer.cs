namespace Lab10
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
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbStoc = new System.Windows.Forms.TextBox();
            this.tbCategorie = new System.Windows.Forms.TextBox();
            this.tbCautare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.dgvProduse = new System.Windows.Forms.DataGridView();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnReincarca = new System.Windows.Forms.Button();
            this.btnVinde = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduse)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDenumire
            // 
            this.tbDenumire.Location = new System.Drawing.Point(160, 40);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(218, 26);
            this.tbDenumire.TabIndex = 0;
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(160, 72);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(218, 26);
            this.tbPret.TabIndex = 1;
            // 
            // tbStoc
            // 
            this.tbStoc.Location = new System.Drawing.Point(160, 104);
            this.tbStoc.Name = "tbStoc";
            this.tbStoc.Size = new System.Drawing.Size(218, 26);
            this.tbStoc.TabIndex = 2;
            // 
            // tbCategorie
            // 
            this.tbCategorie.Location = new System.Drawing.Point(475, 40);
            this.tbCategorie.Name = "tbCategorie";
            this.tbCategorie.Size = new System.Drawing.Size(208, 26);
            this.tbCategorie.TabIndex = 3;
            // 
            // tbCautare
            // 
            this.tbCautare.Location = new System.Drawing.Point(475, 72);
            this.tbCautare.Name = "tbCautare";
            this.tbCautare.Size = new System.Drawing.Size(208, 26);
            this.tbCautare.TabIndex = 4;
            this.tbCautare.TextChanged += new System.EventHandler(this.tbCautare_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Denumire produs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pret:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stoc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Categorie:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cautare:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(398, 101);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(22, 29);
            this.lbTotal.TabIndex = 7;
            this.lbTotal.Text = "-";
            // 
            // dgvProduse
            // 
            this.dgvProduse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduse.Location = new System.Drawing.Point(14, 191);
            this.dgvProduse.Name = "dgvProduse";
            this.dgvProduse.ReadOnly = true;
            this.dgvProduse.RowHeadersWidth = 62;
            this.dgvProduse.RowTemplate.Height = 28;
            this.dgvProduse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduse.Size = new System.Drawing.Size(1335, 676);
            this.dgvProduse.TabIndex = 8;
            this.dgvProduse.SelectionChanged += new System.EventHandler(this.dgvProduse_SelectionChanged);
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(14, 140);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(135, 45);
            this.btnAdauga.TabIndex = 9;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(155, 140);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(135, 45);
            this.btnModifica.TabIndex = 9;
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(296, 140);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(135, 45);
            this.btnSterge.TabIndex = 9;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnReincarca
            // 
            this.btnReincarca.Location = new System.Drawing.Point(437, 140);
            this.btnReincarca.Name = "btnReincarca";
            this.btnReincarca.Size = new System.Drawing.Size(135, 45);
            this.btnReincarca.TabIndex = 9;
            this.btnReincarca.Text = "Reincarca";
            this.btnReincarca.UseVisualStyleBackColor = true;
            this.btnReincarca.Click += new System.EventHandler(this.btnReincarca_Click);
            // 
            // btnVinde
            // 
            this.btnVinde.Location = new System.Drawing.Point(578, 140);
            this.btnVinde.Name = "btnVinde";
            this.btnVinde.Size = new System.Drawing.Size(135, 45);
            this.btnVinde.TabIndex = 9;
            this.btnVinde.Text = "Vinde";
            this.btnVinde.UseVisualStyleBackColor = true;
            this.btnVinde.Click += new System.EventHandler(this.btnVinde_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 879);
            this.Controls.Add(this.btnVinde);
            this.Controls.Add(this.btnReincarca);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.dgvProduse);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCautare);
            this.Controls.Add(this.tbCategorie);
            this.Controls.Add(this.tbStoc);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbDenumire);
            this.Name = "Form1";
            this.Text = "Manager Produse";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.TextBox tbStoc;
        private System.Windows.Forms.TextBox tbCategorie;
        private System.Windows.Forms.TextBox tbCautare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DataGridView dgvProduse;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnReincarca;
        private System.Windows.Forms.Button btnVinde;
    }
}

