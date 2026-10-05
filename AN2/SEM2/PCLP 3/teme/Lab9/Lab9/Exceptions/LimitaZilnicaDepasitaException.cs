using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Exceptions
{
    public class LimitaZilnicaDepasitaException : Exception
    {
        public decimal LimitaZilnica { get; }
        public decimal SumaTotalaRetrasaAzi { get; }
        public LimitaZilnicaDepasitaException() { }
        public LimitaZilnicaDepasitaException(string message)
            : base(message) { }
        public LimitaZilnicaDepasitaException(string message, Exception inner) : base(message, inner) { }
        public LimitaZilnicaDepasitaException(decimal limitaZilnica, decimal sumaTotalaRetrasaAzi)
            : base($"Limita Depasita ({limitaZilnica:F2} RON). " +
                  $"Suma totala retrasa: {sumaTotalaRetrasaAzi:F2} RON.")
        {
            LimitaZilnica = limitaZilnica;
            SumaTotalaRetrasaAzi = sumaTotalaRetrasaAzi;
        }
    }
}
