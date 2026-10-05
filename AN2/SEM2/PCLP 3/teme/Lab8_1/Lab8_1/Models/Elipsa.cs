using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1.Models
{
    public class Elipsa : Figura
    {
        public double RazaMare { get; private set; }
        public double RazaMica { get; private set; }

        public Elipsa(string nume, double razaMare, double razaMica) : base(nume)
        {
            if (razaMare <= 0 || razaMica <= 0)
                throw new ArgumentException(
                "Dimensiunile trebuie sa fie pozitive.");
            RazaMare = razaMare;
            RazaMica = razaMica;
        }
        public override double CalculeazaArie() => Math.PI * RazaMare * RazaMica;
        public override double CalculeazaPerimetru() => 2 * Math.PI * Math.Sqrt((RazaMare * RazaMare + RazaMica * RazaMica) / 2);
        public override void Deseneaza(Graphics g, Point pozitie)
        {
            using (var pen = new Pen(Color.Blue, 2))
            {
                g.DrawEllipse(pen, pozitie.X, pozitie.Y, (int)RazaMare * 2, (int)RazaMica * 2);
            }
        }
        public override void Scaleaza(double factor)
        {
            RazaMare *= factor;
            RazaMica *= factor;
        }
    }
}
