using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editoru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editoru' de texte - v.1", "Despre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool saveFile(string fName)
        {
            bool res = false;

            try
            {
                StreamWriter sw = new StreamWriter(fName);
                sw.Write(textBox1.Text);
                sw.Close();

                isSaved = true;

                updateInterface();

                res = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvare!\n" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        private void salveazaCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveAsDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFile(saveAsDialog.FileName))
                {
                    fileNameInEditor = saveAsDialog.FileName;
                    updateInterface();
                }
            }
        }

        private string fileNameInEditor = null;
        private bool isSaved = true;

        private void updateInterface()
        {
            if (!isSaved)
            {
                string s = this.Text;
                if (s[0]!='*')
                {
                    this.Text = "*" + s;
                }
            }
            else
            {
                string s = this.Text;
                if (s[0] == '*')
                {
                    this.Text = s.Replace("*","");
                }
            }

            labelFName.Text = (fileNameInEditor == null) ? "Fisier fara nume" : fileNameInEditor;
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileNameInEditor == null)
            {
                salveazaCaToolStripMenuItem_Click(sender, null);
            }
            else
            {
                saveFile(fileNameInEditor);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSaved = false;
            updateInterface();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isExitSure = true;

            if (!isSaved)
            {
                DialogResult resDiag = MessageBox.Show("Aveti modificari nesalvate.\nSunteti sigur ca vreti sa parasiti aplicatia?", "Confirmare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resDiag == DialogResult.Yes)
                {
                    salveazaToolStripMenuItem_Click(sender, null);
                }

                if (resDiag == DialogResult.Cancel)
                {
                    isExitSure = false;
                }
            }

            if (!isExitSure)
            {
                e.Cancel = true;
            }
        }

        private void nouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isDoNou = true;


            if (!isSaved)
            {
                DialogResult resDiag = MessageBox.Show("Aveti modificari nesalvate.\nVreti sa le salvati?", "Confirmare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resDiag == DialogResult.Yes)
                {
                    salveazaToolStripMenuItem_Click(sender, null);
                }

                if (resDiag == DialogResult.Cancel)
                {
                    isDoNou = false;
                }
            }

            if (isDoNou)
            {
                textBox1.Text = "";
                fileNameInEditor = null;
                isSaved = true;

                updateInterface();
            }

            
            
        }

        

        private void deschideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isDoOpen = true;

            if (!isSaved)
            {
                DialogResult resDiag = MessageBox.Show("Aveti modificari nesalvate.\nVreti sa le salvati?", "Confirmare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resDiag == DialogResult.Yes)
                {
                    salveazaToolStripMenuItem_Click(sender, null);
                }

                if (resDiag == DialogResult.Cancel)
                {
                    isDoOpen = false;
                }
            }

            if (isDoOpen && openDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openDialog.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();

                    fileNameInEditor = openDialog.FileName;
                    isSaved = true;

                    updateInterface();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Eroare la deschidere!\n" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fisierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
