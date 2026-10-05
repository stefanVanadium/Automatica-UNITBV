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
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    loadedFile = new NoutpedTextFile();
                    loadedFile.FileName = saveFileDialog.FileName;
                    loadedFile.FileContent = textBox1.Text;
                    loadedFile.IsSaved = loadedFile.save();
                    updateInterface();
                }
            }
            else
            {
                loadedFile.FileContent = textBox1.Text;
                loadedFile.IsSaved = loadedFile.save();
                updateInterface();
            }
        }

        void updateInterface()
        {
            labelStatus.Text = loadedFile.FileName;
        }
    }
}
