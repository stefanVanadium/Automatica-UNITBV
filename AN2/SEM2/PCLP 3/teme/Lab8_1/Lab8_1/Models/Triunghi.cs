using Lab8_1.Models;
using System;
using System.Drawing;
namespace Lab8_1.Models
{
    public class Triunghi : Figura
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public Triunghi(string nume, double a, double b, double c)
        : base(nume)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException(
                "Laturile trebuie sa fie pozitive.");
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException(
                "Laturile nu formeaza un triunghi valid.");
            A = a; B = b; C = c;
        }
        public override double CalculeazaArie()
        {
            double s = CalculeazaPerimetru() / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public override double CalculeazaPerimetru() => A + B + C;
        public override void Deseneaza(Graphics g, Point pozitie)
        {
            using (var pen = new Pen(Color.Green, 2))
            {
                var p1 = new Point(pozitie.X, pozitie.Y + (int)A);
                var p2 = new Point(pozitie.X + (int)B, pozitie.Y + (int)A);
                var p3 = new Point(pozitie.X + (int)(B / 2), pozitie.Y);
                g.DrawPolygon(pen, new[] { p1, p2, p3 });
            }
        }
        public override void Scaleaza(double factor)
        {
            A *= factor;
            B *= factor;
            C *= factor;
        }
    }
}