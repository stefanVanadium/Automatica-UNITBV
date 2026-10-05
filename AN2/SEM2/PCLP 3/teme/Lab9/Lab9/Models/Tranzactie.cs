using System;
namespace Lab9.Models
{
    public class Tranzactie
    {
        public DateTime DataOra { get; }
        public TipTranzactie Tip { get; }
        public decimal Suma { get; }
        public decimal SoldDupaTranzactie { get; }
        public string Comentariu { get; }
        public Tranzactie(TipTranzactie tip,
        decimal suma,
        decimal soldDupaTranzactie,
        string comentariu)
        {
            DataOra = DateTime.Now;
            Tip = tip;
            Suma = suma;
            SoldDupaTranzactie = soldDupaTranzactie;
            Comentariu = comentariu ?? string.Empty;
        }
        public override string ToString()
        => $"{DataOra:HH:mm:ss} | {Tip,-10} | " +
        $"{Suma,10:F2} | Sold: {SoldDupaTranzactie,10:F2} | " +
        $"{Comentariu}";
    }
}