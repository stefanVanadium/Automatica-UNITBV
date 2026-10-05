namespace Agenda
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNrTel = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.btnNou = new System.Windows.Forms.Button();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnModificare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.agendaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Agenda.DataSet1();
            this.agendaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.agendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numarDeTelefonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeSiPrenumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDeEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtNume);
            this.panel1.Controls.Add(this.txtNrTel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 153);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numar de telefon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nume si prenume:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Adresa de e-mail:";
            // 
            // txtNrTel
            // 
            this.txtNrTel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agendaBindingSource, "Numar de telefon", true));
            this.txtNrTel.Location = new System.Drawing.Point(158, 14);
            this.txtNrTel.Name = "txtNrTel";
            this.txtNrTel.Size = new System.Drawing.Size(195, 26);
            this.txtNrTel.TabIndex = 0;
            // 
            // txtNume
            // 
            this.txtNume.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agendaBindingSource1, "Nume si prenume", true));
            this.txtNume.Location = new System.Drawing.Point(158, 55);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(646, 26);
            this.txtNume.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agendaBindingSource2, "Adresa de e-mail", true));
            this.txtEmail.Location = new System.Drawing.Point(158, 99);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(498, 26);
            this.txtEmail.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numarDeTelefonDataGridViewTextBoxColumn,
            this.numeSiPrenumeDataGridViewTextBoxColumn,
            this.adresaDeEmailDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.agendaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(26, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(823, 181);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGrid);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cautati:";
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(184, 191);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(646, 26);
            this.txtCautare.TabIndex = 1;
            this.txtCautare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCautare_Key);
            // 
            // btnNou
            // 
            this.btnNou.Location = new System.Drawing.Point(161, 445);
            this.btnNou.Name = "btnNou";
            this.btnNou.Size = new System.Drawing.Size(97, 29);
            this.btnNou.TabIndex = 2;
            this.btnNou.Text = "NOU";
            this.btnNou.UseVisualStyleBackColor = true;
            this.btnNou.Click += new System.EventHandler(this.btnNou_Click);
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(304, 445);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(92, 29);
            this.btnSalvare.TabIndex = 3;
            this.btnSalvare.Text = "SALVATI";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnModificare
            // 
            this.btnModificare.Location = new System.Drawing.Point(427, 445);
            this.btnModificare.Name = "btnModificare";
            this.btnModificare.Size = new System.Drawing.Size(122, 29);
            this.btnModificare.TabIndex = 4;
            this.btnModificare.Text = "MODIFICATI";
            this.btnModificare.UseVisualStyleBackColor = true;
            this.btnModificare.Click += new System.EventHandler(this.btnModificare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.Location = new System.Drawing.Point(600, 445);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(109, 29);
            this.btnAnulare.TabIndex = 5;
            this.btnAnulare.Text = "ANULARE";
            this.btnAnulare.UseVisualStyleBackColor = true;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // agendaBindingSource2
            // 
            this.agendaBindingSource2.DataMember = "Agenda";
            this.agendaBindingSource2.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // agendaBindingSource1
            // 
            this.agendaBindingSource1.DataMember = "Agenda";
            this.agendaBindingSource1.DataSource = this.dataSet1;
            // 
            // agendaBindingSource
            // 
            this.agendaBindingSource.DataMember = "Agenda";
            this.agendaBindingSource.DataSource = this.dataSet1;
            // 
            // numarDeTelefonDataGridViewTextBoxColumn
            // 
            this.numarDeTelefonDataGridViewTextBoxColumn.DataPropertyName = "Numar de telefon";
            this.numarDeTelefonDataGridViewTextBoxColumn.HeaderText = "Numar de telefon";
            this.numarDeTelefonDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numarDeTelefonDataGridViewTextBoxColumn.Name = "numarDeTelefonDataGridViewTextBoxColumn";
            this.numarDeTelefonDataGridViewTextBoxColumn.Width = 150;
            // 
            // numeSiPrenumeDataGridViewTextBoxColumn
            // 
            this.numeSiPrenumeDataGridViewTextBoxColumn.DataPropertyName = "Nume si prenume";
            this.numeSiPrenumeDataGridViewTextBoxColumn.HeaderText = "Nume si prenume";
            this.numeSiPrenumeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numeSiPrenumeDataGridViewTextBoxColumn.Name = "numeSiPrenumeDataGridViewTextBoxColumn";
            this.numeSiPrenumeDataGridViewTextBoxColumn.Width = 150;
            // 
            // adresaDeEmailDataGridViewTextBoxColumn
            // 
            this.adresaDeEmailDataGridViewTextBoxColumn.DataPropertyName = "Adresa de e-mail";
            this.adresaDeEmailDataGridViewTextBoxColumn.HeaderText = "Adresa de e-mail";
            this.adresaDeEmailDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.adresaDeEmailDataGridViewTextBoxColumn.Name = "adresaDeEmailDataGridViewTextBoxColumn";
            this.adresaDeEmailDataGridViewTextBoxColumn.Width = 200;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 499);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnModificare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnNou);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtNrTel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Button btnNou;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnModificare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.BindingSource agendaBindingSource2;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource agendaBindingSource1;
        private System.Windows.Forms.BindingSource agendaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarDeTelefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeSiPrenumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDeEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}

