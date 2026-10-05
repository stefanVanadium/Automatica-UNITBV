using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C06Desene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp.SetPixel(10, 10, Color.Red);

            Graphics grf = Graphics.FromImage(bmp);
            grf.FillRectangle(Brushes.Azure, 0, 0, bmp.Width, bmp.Height);

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Graphics grf = Graphics.FromImage(bmp);

            grf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            grf.FillRectangle(Brushes.Azure, 0, 0, bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Height / 3; i += 5)
            {
                grf.DrawEllipse(
                    Pens.Red,
                    bmp.Width / 2 - i,
                    bmp.Height / 2 - i,
                    i * 2,
                    i * 2);
            }

            grf.FillEllipse(
                Brushes.Blue,
                bmp.Width / 2 - 35,
                bmp.Height / 2 -35,
                70,
                70);

            int r = (int)(bmp.Height * 0.45);
            int dx, dy;
            double u;

            for (int i=0;i<360;i+=15)
            {
                u = i * Math.PI / 180;
                dx = (int)(r * Math.Cos(u));
                dy = (int)(r * Math.Sin(u));

                int x = bmp.Width / 2 + dx;
                int y = bmp.Height / 2 - dy;

                grf.FillEllipse(Brushes.BlueViolet, x - 5, y - 5, 10, 10);
            }

            r = (int)(bmp.Height * 0.40);
            for (int i = 0; i < 360; i += 6)
            {
                u = i * Math.PI / 180;
                dx = (int)(r * Math.Cos(u));
                dy = (int)(r * Math.Sin(u));

                int x = bmp.Width / 2 + dx;
                int y = bmp.Height / 2 - dy;

                grf.FillEllipse(Brushes.CadetBlue, x - 2, y - 2, 4, 4);
            }

            DateTime crtTime = DateTime.Now;

            u = (crtTime.Hour*15+90) * Math.PI / 180;
            r = (int)(bmp.Height * 0.34);
            dx = (int)(r * Math.Cos(u));
            dy = (int)(r * Math.Sin(u));

            Pen penOra = new Pen(Brushes.BlueViolet, 3);

            grf.DrawLine(penOra, bmp.Width / 2, bmp.Height / 2, bmp.Width / 2 - dx, bmp.Height / 2 - dy);

            u = (crtTime.Minute * 6+90) * Math.PI / 180;
            r = (int)(bmp.Height * 0.37);
            dx = (int)(r * Math.Cos(u));
            dy = (int)(r * Math.Sin(u));

            penOra = new Pen(Brushes.CadetBlue, 3);

            grf.DrawLine(penOra, bmp.Width / 2, bmp.Height / 2, bmp.Width / 2 - dx, bmp.Height / 2 - dy);

            u = (crtTime.Second * 6 + 90) * Math.PI / 180;
            r = (int)(bmp.Height * 0.37);
            dx = (int)(r * Math.Cos(u));
            dy = (int)(r * Math.Sin(u));

            grf.DrawLine(Pens.DarkGoldenrod, bmp.Width / 2, bmp.Height / 2, bmp.Width / 2 - dx, bmp.Height / 2 - dy);


            pictureBox1.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
