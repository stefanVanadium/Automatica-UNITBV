using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C04_Editor
{
    public partial class Form1 : Form
    {
        private NoutpedTextFile loadedFile = null;
        private bool isChanged = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Noutped v. 0.0.1 / 2021","Despre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedFile == null)
            {
                salveazaCaToolStripMenuItem_Click(sender, null);
            }
            else
            {
                loadedFile.FileContent = textBox1.Text;
                loadedFile.IsSaved = loadedFile.save();
                isChanged = false;
                updateInterface();
            }
        }

        void updateInterface()
        {
            if (loadedFile != null)
            {
                labelStatus.Text = loadedFile.FileName;
            }
            else
            {
                labelStatus.Text = "Gata";
            }

            if (isChanged)
            {
                this.Text = "Noutped*";
            }
            else
            {
                this.Text = "Noutped";
            }
        }

        private void salveazaCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                loadedFile = new NoutpedTextFile();
                loadedFile.FileName = saveFileDialog.FileName;
                loadedFile.FileContent = textBox1.Text;
                loadedFile.IsSaved = loadedFile.save();
                isChanged = !loadedFile.IsSaved;
                updateInterface();
                if (!loadedFile.IsSaved)
                {
                    MessageBox.Show("Fisierul nu a putut fi salvat", "Eroare", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askForSaveIfChanged())
            {
                return;
            }

            textBox1.Text = "";
            loadedFile = null;
            isChanged = false;
            updateInterface();
        }

        private bool askForSaveIfChanged()
        {
            if (isChanged)
            {
                DialogResult dr = MessageBox.Show("Doriti sa salvati modificarile facute?", "Confirmare",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    salveazaToolStripMenuItem_Click(this, null);
                }

                if (dr == DialogResult.Cancel)
                {
                    return true;
                }
            }

            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool oldChange = isChanged;
            isChanged = true;
            if (oldChange!=isChanged)
            {
                updateInterface();
            }
        }

        private void deschideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askForSaveIfChanged())
            {
                return;
            }

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                NoutpedTextFile oldFile = loadedFile;

                loadedFile = new NoutpedTextFile();
                loadedFile.FileName = openFileDialog.FileName;
                if (!loadedFile.load())
                {
                    MessageBox.Show("Fisierul nu a putut fi deschis", "Eroare",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadedFile = oldFile;
                    return;
                }
                textBox1.Text = loadedFile.FileContent;
                loadedFile.IsSaved = true;
                isChanged = !loadedFile.IsSaved;
                updateInterface();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (askForSaveIfChanged())
            {
                e.Cancel = true;
            }
        }
    }
}
