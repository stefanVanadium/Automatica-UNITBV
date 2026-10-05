using Lab8_1.Models;
using System;
using System.Drawing;
namespace Lab8_1.Models
{
    public class Cerc : Figura
    {
        public double Raza { get; private set; }
        public Cerc(string nume, double raza) : base(nume)
        {
            if (raza <= 0)
                throw new ArgumentException("Raza trebuie sa fie pozitiva.");
            Raza = raza;
        }
        public override double CalculeazaArie()
        => Math.PI * Raza * Raza;
        public override double CalculeazaPerimetru()
        => 2 * Math.PI * Raza;
        public override void Deseneaza(Graphics g, Point pozitie)
        {
            using (var pen = new Pen(Color.Blue, 2))
            {
                int d = (int)(2 * Raza);
                g.DrawEllipse(pen, pozitie.X, pozitie.Y, d, d);
            }
        }
        public override void Scaleaza(double factor)
        {
            Raza *= factor;
        }
    }
}