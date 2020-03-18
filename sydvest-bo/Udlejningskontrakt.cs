using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Udlejningskontrakt
    {
        public int Udlejningskontraktid { get; set; }
        public int Ferieboligid { get; set; }
        public int Udlejningskonsulentid { get; set; }
        public DateTime KontraktDato { get; set; }
        public int Aar { get; set; }
        public int Uge { get; set; }
        public double PrisEjer { get; set; }
        public string UdlejningsKontraktTekst { get; set; }
    }
}
