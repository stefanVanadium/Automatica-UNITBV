using System;
namespace Lab9.Exceptions
{
    public class SumaInvalidaException : ArgumentException
    {
        public decimal SumaPrimita { get; }
        public SumaInvalidaException() { }
        public SumaInvalidaException(string message)
        : base(message) { }
        public SumaInvalidaException(string message, Exception inner)
        : base(message, inner) { }
        public SumaInvalidaException(decimal suma)
        : base($"Suma {suma:F2} este invalidă. " +
        "Trebuie să fie un număr pozitiv.")
        {
            SumaPrimita = suma;
        }
    }
}