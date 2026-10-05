using System;
namespace Lab9.Exceptions
{
    public class FondInsuficientException : Exception
    {
        public decimal SoldCurent { get; }
        public decimal SumaCeruta { get; }
        public FondInsuficientException() { }
        public FondInsuficientException(string message)
        : base(message) { }
        public FondInsuficientException(string message,
        Exception inner)
        : base(message, inner) { }
        public FondInsuficientException(decimal soldCurent,
        decimal sumaCeruta)
        : base($"Fond insuficient: sold = {soldCurent:F2}, " +
        $"cerut = {sumaCeruta:F2}.")
        {
            SoldCurent = soldCurent;
            SumaCeruta = sumaCeruta;
        }
    }
}