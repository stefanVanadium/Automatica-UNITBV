using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1.Models
{
    public class Patrat : Dreptunghi
    {
        public Patrat(string nume, double latura) : base(nume, latura, latura)
        {
            if (latura <= 0)
                throw new ArgumentException(
                "Dimensiunile trebuie sa fie pozitive.");
        }
        public override void Deseneaza(Graphics g, Point pozitie)
        {
            using (var pen = new Pen(Color.Orange, 2))
            {
                g.DrawRectangle(pen, pozitie.X, pozitie.Y,
                (int)Lungime, (int)Latime);
            }
        }
        public override void Scaleaza(double factor)
        {
            base.Scaleaza(factor);
        }
    }
}
