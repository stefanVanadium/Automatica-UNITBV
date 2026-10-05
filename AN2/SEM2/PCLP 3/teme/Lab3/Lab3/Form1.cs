using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            dataGridDate.EndEdit();

            int notaCur = 0;
            int creditCur = 0;
            int totalNote = 0;
            int totalCredite = 0;
            int totalNumarator = 0;
            decimal mediaPonder = 0;

            bool isGridValid = true;

            foreach (DataGridViewRow row in dataGridDate.Rows)
            {
                if (row.IsNewRow) continue;

                var disciplina = row.Cells["disciplina"].Value;
                if (disciplina == null || string.IsNullOrWhiteSpace(disciplina.ToString()))
                {
                    isGridValid = false;
                    row.Cells["disciplina"].ErrorText = "Disciplina trebuie mentionata.";
                } else
                {
                    row.Cells["disciplina"].ErrorText = "";
                }

                var credite = row.Cells["nrCredite"].Value;
                if (credite == null || !int.TryParse(credite.ToString(), out creditCur) || creditCur < 0)
                {
                    isGridValid = false;
                    row.Cells["nrCredite"].ErrorText = "Numar de credite invalid.";
                } else
                {
                    totalCredite += creditCur;
                    row.Cells["nrCredite"].ErrorText = "";
                }

                var nota = row.Cells["nota"].Value;
                if (nota == null || !int.TryParse(nota.ToString(), out notaCur) || notaCur <= 0 || notaCur > 10)
                {
                    isGridValid = false;
                    row.Cells["nota"].ErrorText = "Nota invalida.";
                } else
                {
                    totalNote += notaCur;
                    row.Cells["nota"].ErrorText = "";
                }
                
                if (isGridValid)
                {
                    totalNumarator += notaCur * creditCur;
                }
            }
            if (!isGridValid)
            {
                labelValidare.Text = "Datele din tabel sunt invalide!";
                return;
            } else
            {
                labelValidare.Text = "Datele sunt OK.";
            }
            labelCredite.Text = "Suma creditelor: " + totalCredite;
            mediaPonder = (decimal)totalNumarator / (decimal)totalCredite;
            labelResult.Text = "Media ponderata: " + Math.Round(mediaPonder, 2).ToString();

        }
    }
}
