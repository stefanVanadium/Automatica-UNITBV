using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nr = int.Parse(numar_cifre.Text);
            string s="";
            int x = nr / 10;

            if(nr<=20 && nr>=99)
            {
                MessageBox.Show("Termen in afara intervalului", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                switch (x)
                {
                    case 2:
                        {
                            s = "douazeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 3:
                        {
                            s = "treizeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 4:
                        {
                            s = "patruzeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 5:
                        {
                            s = "cincizeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 6:
                        {
                            s = "saizeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 7:
                        {
                            s = "saptezeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 8:
                        {
                            s = "optzeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                    case 9:
                        {
                            s = "nouazeci";
                            if (nr % 10 != 0)
                            {
                                s = s + ultima_cifra(nr);
                            }
                            break;
                        }
                }

            }

            numar_litere.Text = s;
        }

        public string ultima_cifra(int nr)
        {
            string s="";
            
            switch(nr%10)
            {
                case 1: s = " si unu";
                    break;
                case 2: s = " si doi";
                    break;
                case 3: s = " si trei";
                    break;
                case 4: s= " si patru";
                    break;
                case 5: s = " si cinci";
                    break;
                case 6: s = " si sase";
                    break;
                case 7: s = " si sapte";
                    break;
                case 8: s = " si opt";
                    break;
                case 9: s = " si noua";
                    break;
            }

            return s;
        }
    }
}
