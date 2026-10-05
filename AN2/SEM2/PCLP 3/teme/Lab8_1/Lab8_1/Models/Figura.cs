using System.Drawing;
namespace Lab8_1.Models
{
    public abstract class Figura : IDesenabil, IScalabil
    {
        public string Nume { get; }
        protected Figura(string nume)
        {
            Nume = string.IsNullOrWhiteSpace(nume) ?
            "Fara nume" : nume.Trim();
        }
        public abstract double CalculeazaArie();
        public abstract double CalculeazaPerimetru();
        public abstract void Deseneaza(Graphics g, Point pozitie);
        public abstract void Scaleaza(double factor);
        public override string ToString()
        => $"{GetType().Name} [{Nume}] " +
        $"A = {CalculeazaArie():F2}, " +
        $"P = {CalculeazaPerimetru():F2}";
    }
}