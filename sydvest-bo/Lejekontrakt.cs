using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Lejekontrakt
    {
        public int Lejekontrakid { get; set; }
        public int Ferieboligid { get; set; }
        public int Kundeid { get; set; }
        public int Kundekonsulentid { get; set; }
        public int Udlejningskonsulentid { get; set; }
        public DateTime KontraktDato { get; set; }
        public int Aar { get; set; }
        public int Uge { get; set; }
        public double KundePris { get; set; }
        public string UdlejningsKontraktTekst { get; set; }
        public float ElForbrug { get; set; }
    }
}
