using Lab8_1.Models;
using System;
using System.Drawing;
namespace Lab8_1.Models
{
    public class Dreptunghi : Figura
    {
        public double Lungime { get; private set; }
        public double Latime { get; private set; }
        public Dreptunghi(string nume, double lungime, double latime)
        : base(nume)
        {
            if (lungime <= 0 || latime <= 0)
                throw new ArgumentException(
                "Dimensiunile trebuie sa fie pozitive.");
            Lungime = lungime;
            Latime = latime;
        }
        public override double CalculeazaArie()
        => Lungime * Latime;
        public override double CalculeazaPerimetru()
        => 2 * (Lungime + Latime);
        public override void Deseneaza(Graphics g, Point pozitie)
        {
            using (var pen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(pen, pozitie.X, pozitie.Y,
                (int)Lungime, (int)Latime);
            }
        }
        public override void Scaleaza(double factor)
        {
            Lungime *= factor;
            Latime *= factor;
        }
    }
}