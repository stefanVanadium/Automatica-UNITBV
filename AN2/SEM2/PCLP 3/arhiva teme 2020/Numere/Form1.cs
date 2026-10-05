using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NumereListBox.Items.Add(NumereTextBox.Text);

            NumereTextBox.Clear();
            NumereTextBox.Focus();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            NumereListBox.Items.Remove(NumereListBox.SelectedItem);
        }

        private void DeleteListButton_Click(object sender, EventArgs e)
        {
            NumereListBox.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            Int32 max = Convert.ToInt32(NumereListBox.Items[0]);
            Int32 min = Convert.ToInt32(NumereListBox.Items[0]);

            for(int i=1; i<NumereListBox.Items.Count; i++)
            {
                int x = Convert.ToInt32(NumereListBox.Items[i]);
                if (x > max)
                {
                    max = x;
                }
                else if(x<min)
                {
                    min = x;
                }
            }

            textBox1.Text = textBox1.Text + "Maximul:" + Convert.ToString(max);
            */

        }
    }
}
