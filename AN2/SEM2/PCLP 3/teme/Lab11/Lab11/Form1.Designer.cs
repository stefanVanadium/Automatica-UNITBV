namespace Lab11
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
            tbDenumire = new TextBox();
            tbPret = new TextBox();
            tbStoc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbTotal = new Label();
            dgvProduse = new DataGridView();
            btnAdauga = new Button();
            btnModifica = new Button();
            btnSterge = new Button();
            cbCategorie = new ComboBox();
            cbFiltruCategorie = new ComboBox();
            label6 = new Label();
            tbCautare = new TextBox();
            btnDeschideRapoarte = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProduse).BeginInit();
            SuspendLayout();
            // 
            // tbDenumire
            // 
            tbDenumire.Location = new Point(178, 50);
            tbDenumire.Margin = new Padding(3, 4, 3, 4);
            tbDenumire.Name = "tbDenumire";
            tbDenumire.Size = new Size(242, 31);
            tbDenumire.TabIndex = 0;
            // 
            // tbPret
            // 
            tbPret.Location = new Point(178, 90);
            tbPret.Margin = new Padding(3, 4, 3, 4);
            tbPret.Name = "tbPret";
            tbPret.Size = new Size(242, 31);
            tbPret.TabIndex = 1;
            // 
            // tbStoc
            // 
            tbStoc.Location = new Point(178, 130);
            tbStoc.Margin = new Padding(3, 4, 3, 4);
            tbStoc.Name = "tbStoc";
            tbStoc.Size = new Size(242, 31);
            tbStoc.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 50);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 5;
            label1.Text = "Denumire produs:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 90);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 6;
            label2.Text = "Pret:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 130);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 6;
            label3.Text = "Stoc:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(430, 58);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 6;
            label4.Text = "Categorie:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(443, 90);
            label5.Name = "label5";
            label5.Size = new Size(69, 25);
            label5.TabIndex = 6;
            label5.Text = "Filtrare:";
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotal.Location = new Point(442, 126);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(22, 29);
            lbTotal.TabIndex = 7;
            lbTotal.Text = "-";
            // 
            // dgvProduse
            // 
            dgvProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduse.Location = new Point(16, 239);
            dgvProduse.Margin = new Padding(3, 4, 3, 4);
            dgvProduse.Name = "dgvProduse";
            dgvProduse.ReadOnly = true;
            dgvProduse.RowHeadersWidth = 62;
            dgvProduse.RowTemplate.Height = 28;
            dgvProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduse.Size = new Size(1483, 845);
            dgvProduse.TabIndex = 8;
            dgvProduse.SelectionChanged += dgvProduse_SelectionChanged;
            // 
            // btnAdauga
            // 
            btnAdauga.Location = new Point(16, 175);
            btnAdauga.Margin = new Padding(3, 4, 3, 4);
            btnAdauga.Name = "btnAdauga";
            btnAdauga.Size = new Size(150, 56);
            btnAdauga.TabIndex = 9;
            btnAdauga.Text = "Adauga";
            btnAdauga.UseVisualStyleBackColor = true;
            btnAdauga.Click += btnAdauga_Click;
            // 
            // btnModifica
            // 
            btnModifica.Location = new Point(172, 175);
            btnModifica.Margin = new Padding(3, 4, 3, 4);
            btnModifica.Name = "btnModifica";
            btnModifica.Size = new Size(150, 56);
            btnModifica.TabIndex = 9;
            btnModifica.Text = "Modifica";
            btnModifica.UseVisualStyleBackColor = true;
            btnModifica.Click += btnModifica_Click;
            // 
            // btnSterge
            // 
            btnSterge.Location = new Point(329, 175);
            btnSterge.Margin = new Padding(3, 4, 3, 4);
            btnSterge.Name = "btnSterge";
            btnSterge.Size = new Size(150, 56);
            btnSterge.TabIndex = 9;
            btnSterge.Text = "Sterge";
            btnSterge.UseVisualStyleBackColor = true;
            btnSterge.Click += btnSterge_Click;
            // 
            // cbCategorie
            // 
            cbCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategorie.FormattingEnabled = true;
            cbCategorie.Location = new Point(528, 47);
            cbCategorie.Name = "cbCategorie";
            cbCategorie.Size = new Size(182, 33);
            cbCategorie.TabIndex = 10;
            // 
            // cbFiltruCategorie
            // 
            cbFiltruCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltruCategorie.FormattingEnabled = true;
            cbFiltruCategorie.Location = new Point(528, 86);
            cbFiltruCategorie.Name = "cbFiltruCategorie";
            cbFiltruCategorie.Size = new Size(182, 33);
            cbFiltruCategorie.TabIndex = 10;
            cbFiltruCategorie.SelectedIndexChanged += cbFiltruCategorie_Changed;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(752, 50);
            label6.Name = "label6";
            label6.Size = new Size(76, 25);
            label6.TabIndex = 6;
            label6.Text = "Cautare:";
            // 
            // tbCautare
            // 
            tbCautare.Location = new Point(834, 47);
            tbCautare.Margin = new Padding(3, 4, 3, 4);
            tbCautare.Name = "tbCautare";
            tbCautare.Size = new Size(242, 31);
            tbCautare.TabIndex = 0;
            tbCautare.TextChanged += tbCautare_TextChanged;
            // 
            // btnDeschideRapoarte
            // 
            btnDeschideRapoarte.Location = new Point(485, 175);
            btnDeschideRapoarte.Margin = new Padding(3, 4, 3, 4);
            btnDeschideRapoarte.Name = "btnDeschideRapoarte";
            btnDeschideRapoarte.Size = new Size(196, 56);
            btnDeschideRapoarte.TabIndex = 9;
            btnDeschideRapoarte.Text = "Deschide Rapoarte";
            btnDeschideRapoarte.UseVisualStyleBackColor = true;
            btnDeschideRapoarte.Click += btnDeschideRapoarte_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1512, 1099);
            Controls.Add(cbFiltruCategorie);
            Controls.Add(cbCategorie);
            Controls.Add(btnDeschideRapoarte);
            Controls.Add(btnSterge);
            Controls.Add(btnModifica);
            Controls.Add(btnAdauga);
            Controls.Add(dgvProduse);
            Controls.Add(lbTotal);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbStoc);
            Controls.Add(tbPret);
            Controls.Add(tbCautare);
            Controls.Add(tbDenumire);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Manager Produse";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProduse).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.TextBox tbStoc;
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
        private ComboBox cbCategorie;
        private ComboBox cbFiltruCategorie;
        private Label label6;
        private TextBox tbCautare;
        private Button btnDeschideRapoarte;
    }
}

