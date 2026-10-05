using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C07
{
    public partial class Form1 : Form
    {
        private byte[,] modelJoc = new byte[7, 3];
        private int pozVierme=1;
        private int coefViteza = 0;
        private int coefVitezaMax = 25;

        private int coefSchimbaViteza = 0; // se reseteaza la fiecare 4 secunde = 200 ticks

        public Form1()
        {
            InitializeComponent();

            for (int i=0;i<modelJoc.GetLength(0);i++)
            {
                for (int j = 0; j < modelJoc.GetLength(1); j++)
                {
                    modelJoc[i, j] = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < modelJoc.GetLength(0); i++)
            {
                for (int j = 0; j < modelJoc.GetLength(1); j++)
                {
                    modelJoc[i, j] = 0;
                }
            }

            pozVierme = 1;
            coefViteza = 0;
            coefSchimbaViteza = 0;
            coefVitezaMax = 20;

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            if (pictureBox1.Image==null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            else
            {
                bmp = (Bitmap)pictureBox1.Image;
            }

            Graphics canvas = Graphics.FromImage(bmp);

            canvas.FillRectangle(Brushes.AntiqueWhite, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            canvas.DrawLine(Pens.Black, 150, 0, 150, pictureBox1.Height - 1);
            canvas.DrawLine(Pens.Black, 300, 0, 300, pictureBox1.Height - 1);
            canvas.DrawLine(Pens.Black, 450, 0, 450, pictureBox1.Height - 1);
            canvas.FillRectangle(Brushes.Navy, 0, pictureBox1.Height - 41, pictureBox1.Width - 1, pictureBox1.Height - 1);

            // decide daca schimbam viteza (coefVitezaMax)
            coefSchimbaViteza++;
            if (coefSchimbaViteza >= 200)
            {
                if (coefSchimbaViteza > 5)
                {
                    coefVitezaMax--;
                }
                coefSchimbaViteza = 0;
            }

            // generam un nou rand doar daca am atins coeficientul de viteza maxima
            // coefVitezaMax -> da timpul de actualizare a matricei = coefVitezaMax*20ms
            // 20ms este timer1.Interval
            if (coefViteza >= coefVitezaMax)
            {
                for (int i = modelJoc.GetLength(0) - 1; i > 0; i--)
                {
                    for (int j = 0; j < modelJoc.GetLength(1); j++)
                    {
                        modelJoc[i, j] = modelJoc[i - 1, j];
                    }
                }

                Random rand = new Random(DateTime.Now.Millisecond);

                modelJoc[0, 0] = (byte)(rand.Next(7000) % 4 == 0 ? 1 : 0);
                modelJoc[0, 1] = (byte)(rand.Next(5000) % 4 == 0 ? 1 : 0);
                modelJoc[0, 2] = (byte)(rand.Next(3000) % 4 == 0 ? 1 : 0);

                if (modelJoc[0, 0] == 1 && modelJoc[0, 1] == 1 && modelJoc[0, 2] == 1)
                {
                    modelJoc[0, rand.Next(3)] = 0;
                }

                while (notSolvable())
                {
                    if (modelJoc[0, 1]==1)
                    {
                        modelJoc[0, 1] = 0;
                    }
                    else
                    {
                        if (modelJoc[0, 0] == 1)
                        {
                            modelJoc[0, 0] = 0;
                        }
                        else
                        {
                            modelJoc[0, 2] = 0;
                            break;
                        }
                    }
                }

                coefViteza = 0;
            }

            coefViteza++;

            for (int i = 0; i < modelJoc.GetLength(0); i++)
            {
                for (int j = 0; j < modelJoc.GetLength(1); j++)
                {
                    if (modelJoc[i, j] == 1)
                    {
                        int x = (j + 1) * 150 - 40;
                        int y = i * 80;
                        canvas.DrawImage(imageList1.Images[0], x, y);
                    }
                }
            }

            if (modelJoc[5, pozVierme] == 1)
            {
                canvas.DrawImage(imageList1.Images[2], (pozVierme + 1) * 150 - 40, 400);
            }
            else
            {
                canvas.DrawImage(imageList1.Images[1], (pozVierme + 1) * 150 - 40, 400);
            }

            pictureBox1.Image = bmp;

            if (modelJoc[5, pozVierme] == 1)
            {
                timer1.Enabled = false;
                MessageBox.Show("AWWWWWWW");
            }
        }

        private bool notSolvable()
        {
            byte[,] mat = new byte[8,5];

            // initializare cu 1
            // 1111
            // 1111
            // 1111
            // 1111
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = 1;
                }
            }

            // copiere model jos in interiorul matricii
            // 1111
            // 1011
            // 1001
            // 1111
            for (int i = 1; i < mat.GetLength(0)-1; i++)
            {
                for (int j = 1; j < mat.GetLength(1)-1; j++)
                {
                    mat[i, j] = modelJoc[i-1, j-1];
                }
            }

            fillMat(mat, 6, pozVierme+1);
            
            if (mat[1, 1] == 2 || mat[1, 2] == 2 || mat[1, 3] == 2)
            {
                return false;
            }

            return true;
        }

        // umplem cu valoarea 2, pornind din pozitia viermelui
        // daca umplerea ajunge pana pe linia a doua-a, atunci se poate ajunge
        // din pozitia viermului la pozitia din linia 1 = traseul e rezolvabil
        private void fillMat(byte[,] mat, int x, int y)
        {
            if (mat[x,y]==0)
            {
                mat[x, y] = 2;
            }
            else
            {
                return;
            }

            fillMat(mat, x, y + 1);
            fillMat(mat, x, y - 1);
            fillMat(mat, x + 1, y);
            fillMat(mat, x - 1, y);
        }
        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (pozVierme < 2)
                    pozVierme++;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (pozVierme > 0)
                    pozVierme--;
            }
        }
    }
}
