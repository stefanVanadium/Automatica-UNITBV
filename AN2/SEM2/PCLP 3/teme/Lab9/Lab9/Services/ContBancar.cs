using Lab9.Exceptions;
using Lab9.Models;
using System;
using System.Collections.Generic;

namespace Lab9.Services
{
    public class ContBancar
    {
        private decimal _sold;
        private decimal _totalRetras;
        public const decimal limitaZ = 1000;
        private readonly List<Tranzactie> _tranzactii =
        new List<Tranzactie>();
        public string NumeTitular { get; }
        public decimal Sold => _sold;
        public decimal TotalRetras => _totalRetras;
        public IReadOnlyList<Tranzactie> Tranzactii => _tranzactii;
        public ContBancar(string numeTitular,
        decimal soldInitial = 0)
        {
            if (string.IsNullOrWhiteSpace(numeTitular))
                throw new ArgumentException(
                "Numele titularului este obligatoriu.",
                nameof(numeTitular));
            if (soldInitial < 0)
                throw new SumaInvalidaException(soldInitial);
            NumeTitular = numeTitular.Trim();
            _sold = soldInitial;
        }
        public Tranzactie Depune(decimal suma, string comentariu = "")
        {
            if (suma <= 0)
                throw new SumaInvalidaException(suma);
            _sold += suma;
            var t = new Tranzactie(TipTranzactie.Depunere,
            suma, _sold, comentariu);
            _tranzactii.Add(t);
            return t;
        }
        public Tranzactie Retrage(decimal suma, string comentariu = "")
        {
            if (suma <= 0)
                throw new SumaInvalidaException(suma);
            if (suma > _sold)
                throw new FondInsuficientException(_sold, suma);
            if (_totalRetras + suma > limitaZ)
                throw new LimitaZilnicaDepasitaException(limitaZ, _totalRetras);
            _sold -= suma;
            _totalRetras += suma;
            var t = new Tranzactie(TipTranzactie.Retragere, suma,
            _sold, comentariu);
            _tranzactii.Add(t);
            return t;
        }
        public void Reseteaza()
        {
            _sold = 0;
            _tranzactii.Clear();
        }
    }
}