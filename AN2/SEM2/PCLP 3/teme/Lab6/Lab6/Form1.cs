using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filePath = "";
        List<int> numbers = new List<int>();

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Filter = "Text (*.txt)|*.txt";
                dialog.Title = "Add text file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                } else
                {
                    return;
                }

                string[] fileLines = File.ReadAllLines(filePath);
                foreach (string line in fileLines) {
                    if(int.TryParse(line, out int result))
                    {
                        numbers.Add(result);
                    }
                }
                updateLbls();
            }
        }

        private void updateLbls() {
            lbFileSel.Text = "File: " + filePath;
            lbSum.Text = "Suma: " + numbers.Sum();
            lbMedia.Text = "Media: " + numbers.Average();
            lbMin.Text = "Min: " + numbers.Min();
            lbMax.Text = "Max: " + numbers.Max();
        }
    }
}
