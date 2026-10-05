using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C09.Models
{
    class Tranzactie
    {
        public long Id
        {
            set; get;
        }

        public String TipOperatie
        {
            set; get;
        }

        public double Valoare
        {
            set; get;
        }

        public String Descriere
        {
            set; get;
        }

        public DateTime Timestamp
        {
            set; get;
        }
    }
}
