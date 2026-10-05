namespace Lab3
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
            this.dataGridDate = new System.Windows.Forms.DataGridView();
            this.disciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrCredite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.labelValidare = new System.Windows.Forms.Label();
            this.labelCredite = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDate
            // 
            this.dataGridDate.AllowUserToResizeColumns = false;
            this.dataGridDate.AllowUserToResizeRows = false;
            this.dataGridDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disciplina,
            this.nrCredite,
            this.nota});
            this.dataGridDate.Location = new System.Drawing.Point(0, 0);
            this.dataGridDate.Name = "dataGridDate";
            this.dataGridDate.RowHeadersWidth = 62;
            this.dataGridDate.RowTemplate.Height = 28;
            this.dataGridDate.Size = new System.Drawing.Size(583, 411);
            this.dataGridDate.TabIndex = 0;
            // 
            // disciplina
            // 
            this.disciplina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.disciplina.DividerWidth = 1;
            this.disciplina.HeaderText = "Disciplina";
            this.disciplina.MinimumWidth = 200;
            this.disciplina.Name = "disciplina";
            // 
            // nrCredite
            // 
            this.nrCredite.HeaderText = "Numar Credite";
            this.nrCredite.MinimumWidth = 100;
            this.nrCredite.Name = "nrCredite";
            // 
            // nota
            // 
            this.nota.HeaderText = "Nota";
            this.nota.MinimumWidth = 50;
            this.nota.Name = "nota";
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(676, 348);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(139, 63);
            this.buttonCalc.TabIndex = 1;
            this.buttonCalc.Text = "Calculeaza Media!";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // labelValidare
            // 
            this.labelValidare.AutoSize = true;
            this.labelValidare.Location = new System.Drawing.Point(12, 421);
            this.labelValidare.Name = "labelValidare";
            this.labelValidare.Size = new System.Drawing.Size(125, 20);
            this.labelValidare.TabIndex = 2;
            this.labelValidare.Text = "Introduceti date.";
            // 
            // labelCredite
            // 
            this.labelCredite.AutoSize = true;
            this.labelCredite.Location = new System.Drawing.Point(620, 28);
            this.labelCredite.Name = "labelCredite";
            this.labelCredite.Size = new System.Drawing.Size(137, 20);
            this.labelCredite.TabIndex = 2;
            this.labelCredite.Text = "Suma creditelor: 0";
            this.labelCredite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(620, 64);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(146, 20);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "Media ponderata: 0";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 450);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelCredite);
            this.Controls.Add(this.labelValidare);
            this.Controls.Add(this.buttonCalc);
            this.Controls.Add(this.dataGridDate);
            this.Name = "Form1";
            this.Text = "Medie Ponderata";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDate;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Label labelValidare;
        private System.Windows.Forms.Label labelCredite;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplina;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrCredite;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
    }
}

