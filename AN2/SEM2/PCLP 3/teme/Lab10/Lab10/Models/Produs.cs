using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public decimal Pret { get; set; }
        public int Stoc { get; set; }
        public string Categorie { get; set; }
        public DateTime DataAdaugarii { get; set; }
        public decimal ValoareStoc => Pret * Stoc;
        public override string ToString()
        => $"{Denumire} - {Pret:F2} RON ({Stoc} buc.)";
    }
}
