using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonCalc_Click(object sender, EventArgs e)
        {
            String semn = Semn.Text;
            double A = double.Parse(Termen1.Text);
            double B = double.Parse(Termen2.Text);
            if (semn == "+")
            {
                double C = A + B;
                Rezultat.Text = C.ToString();
            }
            if (semn == "*")
            {
                double C = A * B;
                Rezultat.Text = C.ToString();
            }
            if (semn == "-")
            {
                double C = A - B;
                Rezultat.Text = C.ToString();
            }
            if (semn == "/")
            {
                if (B == 0)
                {
                    MessageBox.Show("Operatie invalida! Termenul al doilea este nul!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Rezultat.Text = "";
                }
                else
                {
                    double C = A / B;
                    Rezultat.Text = C.ToString();
                }
            }

        }
    }

}