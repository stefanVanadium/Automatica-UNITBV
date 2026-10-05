namespace Lab5
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
            this.tbNume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNota = new System.Windows.Forms.TextBox();
            this.lbxNote = new System.Windows.Forms.ListBox();
            this.lvStudentiSubMedie = new System.Windows.Forms.ListView();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnStergere = new System.Windows.Forms.Button();
            this.btnCalculeazaMedia = new System.Windows.Forms.Button();
            this.btnAfisareMinMax = new System.Windows.Forms.Button();
            this.btnStudentiSubMedie = new System.Windows.Forms.Button();
            this.lbNrStudenti = new System.Windows.Forms.Label();
            this.lbMedia = new System.Windows.Forms.Label();
            this.lbNotaMax = new System.Windows.Forms.Label();
            this.lbNotaMin = new System.Windows.Forms.Label();
            this.lvStudentiPesteMedie = new System.Windows.Forms.ListView();
            this.btnStudentiPesteMedie = new System.Windows.Forms.Button();
            this.tbCautare = new System.Windows.Forms.TextBox();
            this.btnCautare = new System.Windows.Forms.Button();
            this.btnSortare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNume
            // 
            this.tbNume.Location = new System.Drawing.Point(28, 47);
            this.tbNume.Name = "tbNume";
            this.tbNume.Size = new System.Drawing.Size(385, 26);
            this.tbNume.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nume Student:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Notele Studentului:";
            // 
            // tbNota
            // 
            this.tbNota.Location = new System.Drawing.Point(178, 99);
            this.tbNota.Name = "tbNota";
            this.tbNota.Size = new System.Drawing.Size(235, 26);
            this.tbNota.TabIndex = 0;
            // 
            // lbxNote
            // 
            this.lbxNote.FormattingEnabled = true;
            this.lbxNote.ItemHeight = 20;
            this.lbxNote.Location = new System.Drawing.Point(32, 250);
            this.lbxNote.Name = "lbxNote";
            this.lbxNote.Size = new System.Drawing.Size(381, 424);
            this.lbxNote.TabIndex = 2;
            // 
            // lvStudentiSubMedie
            // 
            this.lvStudentiSubMedie.HideSelection = false;
            this.lvStudentiSubMedie.Location = new System.Drawing.Point(630, 250);
            this.lvStudentiSubMedie.Name = "lvStudentiSubMedie";
            this.lvStudentiSubMedie.Size = new System.Drawing.Size(381, 210);
            this.lvStudentiSubMedie.TabIndex = 3;
            this.lvStudentiSubMedie.UseCompatibleStateImageBehavior = false;
            this.lvStudentiSubMedie.View = System.Windows.Forms.View.List;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(32, 149);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Padding = new System.Windows.Forms.Padding(20);
            this.btnAdauga.Size = new System.Drawing.Size(140, 76);
            this.btnAdauga.TabIndex = 4;
            this.btnAdauga.Text = "Adaugare";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnStergere
            // 
            this.btnStergere.Location = new System.Drawing.Point(273, 149);
            this.btnStergere.Name = "btnStergere";
            this.btnStergere.Padding = new System.Windows.Forms.Padding(20);
            this.btnStergere.Size = new System.Drawing.Size(140, 76);
            this.btnStergere.TabIndex = 4;
            this.btnStergere.Text = "Stergere";
            this.btnStergere.UseVisualStyleBackColor = true;
            this.btnStergere.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnCalculeazaMedia
            // 
            this.btnCalculeazaMedia.Location = new System.Drawing.Point(451, 46);
            this.btnCalculeazaMedia.Name = "btnCalculeazaMedia";
            this.btnCalculeazaMedia.Padding = new System.Windows.Forms.Padding(10);
            this.btnCalculeazaMedia.Size = new System.Drawing.Size(140, 76);
            this.btnCalculeazaMedia.TabIndex = 4;
            this.btnCalculeazaMedia.Text = "Calculare Medie";
            this.btnCalculeazaMedia.UseVisualStyleBackColor = true;
            this.btnCalculeazaMedia.Click += new System.EventHandler(this.btnCalculeazaMedia_Click);
            // 
            // btnAfisareMinMax
            // 
            this.btnAfisareMinMax.Location = new System.Drawing.Point(451, 149);
            this.btnAfisareMinMax.Name = "btnAfisareMinMax";
            this.btnAfisareMinMax.Padding = new System.Windows.Forms.Padding(10);
            this.btnAfisareMinMax.Size = new System.Drawing.Size(140, 76);
            this.btnAfisareMinMax.TabIndex = 4;
            this.btnAfisareMinMax.Text = "Afisare Note Min si Max";
            this.btnAfisareMinMax.UseVisualStyleBackColor = true;
            this.btnAfisareMinMax.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // btnStudentiSubMedie
            // 
            this.btnStudentiSubMedie.Location = new System.Drawing.Point(451, 250);
            this.btnStudentiSubMedie.Name = "btnStudentiSubMedie";
            this.btnStudentiSubMedie.Padding = new System.Windows.Forms.Padding(10);
            this.btnStudentiSubMedie.Size = new System.Drawing.Size(140, 91);
            this.btnStudentiSubMedie.TabIndex = 4;
            this.btnStudentiSubMedie.Text = "Afisare Studenti Sub Medie";
            this.btnStudentiSubMedie.UseVisualStyleBackColor = true;
            this.btnStudentiSubMedie.Click += new System.EventHandler(this.btnStudentiSubMedie_Click);
            // 
            // lbNrStudenti
            // 
            this.lbNrStudenti.AutoSize = true;
            this.lbNrStudenti.Location = new System.Drawing.Point(626, 69);
            this.lbNrStudenti.Name = "lbNrStudenti";
            this.lbNrStudenti.Size = new System.Drawing.Size(169, 20);
            this.lbNrStudenti.TabIndex = 1;
            this.lbNrStudenti.Text = "Numar total studenti: 0";
            // 
            // lbMedia
            // 
            this.lbMedia.AutoSize = true;
            this.lbMedia.Location = new System.Drawing.Point(626, 114);
            this.lbMedia.Name = "lbMedia";
            this.lbMedia.Size = new System.Drawing.Size(109, 20);
            this.lbMedia.TabIndex = 1;
            this.lbMedia.Text = "Media notelor:";
            // 
            // lbNotaMax
            // 
            this.lbNotaMax.AutoSize = true;
            this.lbNotaMax.Location = new System.Drawing.Point(626, 159);
            this.lbNotaMax.Name = "lbNotaMax";
            this.lbNotaMax.Size = new System.Drawing.Size(105, 20);
            this.lbNotaMax.TabIndex = 1;
            this.lbNotaMax.Text = "Nota Maxima:";
            // 
            // lbNotaMin
            // 
            this.lbNotaMin.AutoSize = true;
            this.lbNotaMin.Location = new System.Drawing.Point(626, 204);
            this.lbNotaMin.Name = "lbNotaMin";
            this.lbNotaMin.Size = new System.Drawing.Size(101, 20);
            this.lbNotaMin.TabIndex = 1;
            this.lbNotaMin.Text = "Nota Minima:";
            // 
            // lvStudentiPesteMedie
            // 
            this.lvStudentiPesteMedie.HideSelection = false;
            this.lvStudentiPesteMedie.Location = new System.Drawing.Point(630, 464);
            this.lvStudentiPesteMedie.Name = "lvStudentiPesteMedie";
            this.lvStudentiPesteMedie.Size = new System.Drawing.Size(381, 210);
            this.lvStudentiPesteMedie.TabIndex = 3;
            this.lvStudentiPesteMedie.UseCompatibleStateImageBehavior = false;
            this.lvStudentiPesteMedie.View = System.Windows.Forms.View.List;
            // 
            // btnStudentiPesteMedie
            // 
            this.btnStudentiPesteMedie.Location = new System.Drawing.Point(451, 464);
            this.btnStudentiPesteMedie.Name = "btnStudentiPesteMedie";
            this.btnStudentiPesteMedie.Padding = new System.Windows.Forms.Padding(10);
            this.btnStudentiPesteMedie.Size = new System.Drawing.Size(140, 91);
            this.btnStudentiPesteMedie.TabIndex = 4;
            this.btnStudentiPesteMedie.Text = "Afisare Studenti Peste Medie";
            this.btnStudentiPesteMedie.UseVisualStyleBackColor = true;
            this.btnStudentiPesteMedie.Click += new System.EventHandler(this.btnStudentiPesteMedie_Click);
            // 
            // tbCautare
            // 
            this.tbCautare.Location = new System.Drawing.Point(32, 680);
            this.tbCautare.Name = "tbCautare";
            this.tbCautare.Size = new System.Drawing.Size(287, 26);
            this.tbCautare.TabIndex = 0;
            // 
            // btnCautare
            // 
            this.btnCautare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnCautare.Location = new System.Drawing.Point(325, 680);
            this.btnCautare.Margin = new System.Windows.Forms.Padding(0);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(88, 33);
            this.btnCautare.TabIndex = 4;
            this.btnCautare.Text = "Cauta";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnSortare
            // 
            this.btnSortare.Location = new System.Drawing.Point(451, 656);
            this.btnSortare.Name = "btnSortare";
            this.btnSortare.Padding = new System.Windows.Forms.Padding(10);
            this.btnSortare.Size = new System.Drawing.Size(140, 50);
            this.btnSortare.TabIndex = 4;
            this.btnSortare.Text = "Sortare";
            this.btnSortare.UseVisualStyleBackColor = true;
            this.btnSortare.Click += new System.EventHandler(this.btnSortare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 745);
            this.Controls.Add(this.btnStudentiPesteMedie);
            this.Controls.Add(this.btnSortare);
            this.Controls.Add(this.btnStudentiSubMedie);
            this.Controls.Add(this.btnAfisareMinMax);
            this.Controls.Add(this.btnCalculeazaMedia);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.lvStudentiPesteMedie);
            this.Controls.Add(this.lvStudentiSubMedie);
            this.Controls.Add(this.lbxNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNotaMin);
            this.Controls.Add(this.lbNotaMax);
            this.Controls.Add(this.lbMedia);
            this.Controls.Add(this.lbNrStudenti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNota);
            this.Controls.Add(this.tbCautare);
            this.Controls.Add(this.tbNume);
            this.Name = "Form1";
            this.Text = "Manager Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNota;
        private System.Windows.Forms.ListBox lbxNote;
        private System.Windows.Forms.ListView lvStudentiSubMedie;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnStergere;
        private System.Windows.Forms.Button btnCalculeazaMedia;
        private System.Windows.Forms.Button btnAfisareMinMax;
        private System.Windows.Forms.Button btnStudentiSubMedie;
        private System.Windows.Forms.Label lbNrStudenti;
        private System.Windows.Forms.Label lbNotaMax;
        private System.Windows.Forms.Label lbNotaMin;
        private System.Windows.Forms.Label lbMedia;
        private System.Windows.Forms.ListView lvStudentiPesteMedie;
        private System.Windows.Forms.Button btnStudentiPesteMedie;
        private System.Windows.Forms.TextBox tbCautare;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.Button btnSortare;
    }
}

