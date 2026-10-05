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
            if(NumereTextBox.Text!="")
            {
                NumereListBox.Items.Add(NumereTextBox.Text);
                NumereTextBox.Clear();
                NumereTextBox.Focus();
                updateRezultate();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            NumereListBox.Items.Remove(NumereListBox.SelectedItem);
            updateRezultate();
        }

        private void DeleteListButton_Click(object sender, EventArgs e)
        {
            NumereListBox.Items.Clear();
            updateRezultate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void NumereTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumereTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
        }
        private bool verificare(double nr)
        {
            bool okay = true;
            double jum = nr / 2;
            for(int i=2;i<=jum;i++)
            {
                if(nr%i==0)
                {
                    okay = false;
                    break;
                }
            }
            return okay;
        }

    private void updateRezultate()
        {
            RezultateListBox.Text = "";
            if(NumereListBox.Items.Count>0)
            {
                if(NumereListBox.Items.Count>1)
                {
                    //Operatie de medie aritmetica
                    double medie = 0;
                    for(int i=0; i<NumereListBox.Items.Count; i++)
                    {
                        medie = medie + Convert.ToDouble(NumereListBox.Items[i]);
                    }
                    medie = medie / NumereListBox.Items.Count;
                    RezultateListBox.Text += "Medie: ";
                    RezultateListBox.Text += medie;
                    RezultateListBox.Text += "\r\n";

                    //Obtinerea minimului si maximului
                    double min = 2147483647;
                    double max = -min;
                    for(int i=0; i<NumereListBox.Items.Count;i++)
                    {
                        if (Convert.ToDouble(NumereListBox.Items[i]) > max)
                            max = Convert.ToDouble(NumereListBox.Items[i]);
                        if (Convert.ToDouble(NumereListBox.Items[i]) < min)
                            min = Convert.ToDouble(NumereListBox.Items[i]);
                    }
                    RezultateListBox.Text += "Maxim: ";
                    RezultateListBox.Text += max;
                    RezultateListBox.Text += "\r\n";
                    RezultateListBox.Text += "Minim: ";
                    RezultateListBox.Text += min;
                    RezultateListBox.Text += "\r\n";

                    //Produsul numerelor nenule
                    double produs = 1;
                    for (int i = 0; i < NumereListBox.Items.Count; i++)
                    {
                        if(Convert.ToString(NumereListBox.Items[i])!="0")
                        {
                            produs = produs + Convert.ToDouble(NumereListBox.Items[i]);
                        }
                    }
                    RezultateListBox.Text += "Produsul numerelor nenule: ";
                    RezultateListBox.Text += produs;
                    RezultateListBox.Text += "\r\n";

                    //Calculul Deviatiei Standard

                    double deviatieStandard = 0;
                    for (int i = 0; i<NumereListBox.Items.Count;i++)
                    {
                        deviatieStandard += Math.Pow(Convert.ToDouble(NumereListBox.Items[i]) - medie, 2);

                    }
                    deviatieStandard = Math.Sqrt(deviatieStandard / NumereListBox.Items.Count);

                    RezultateListBox.Text += "Deviatia standard este: ";
                    RezultateListBox.Text += deviatieStandard;
                    RezultateListBox.Text += "\r\n";

                    //Numerele prime

                    List<Double> nrPrim = new List<Double>();
                    for(int i=0;i<NumereListBox.Items.Count;i++)
                    {
                        if (verificare(Convert.ToDouble(NumereListBox.Items[i])))
                        {
                            nrPrim.Add(Convert.ToDouble(NumereListBox.Items[i]));
                        }
                    }
                    RezultateListBox.Text += "Numerele/Numarul prime/prim sunt/este: ";
                    foreach(Double nr in nrPrim)
                    {
                        RezultateListBox.Text += nr + " ";
                    }
                    RezultateListBox.Text += "\r\n";
                }
            }
        }
    }
}
