using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C02_Controale_grafice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valoarea casutei de validare: " + (checkBox1.Checked?"selectat":"neselectat"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("S-a selectat indexul " + comboBox1.SelectedIndex +
                "; item: " + comboBox1.SelectedItem);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar1.Value = (int)numericUpDown1.Value;
            progressBar3.Value = 100-(int)numericUpDown1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este selectat indexul: " + listBox1.SelectedIndex + 
                "; item: " + listBox1.SelectedItem);

            string str = "";
            foreach(int idx in listBox1.SelectedIndices)
            {
                str += idx + ",";
            }

            MessageBox.Show("Indecsi selectati: " + str);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data aleasa: " + dateTimePicker1.Value.ToString("dd.MM.yyyy HH:mm:ss"));
        }
    }
}
