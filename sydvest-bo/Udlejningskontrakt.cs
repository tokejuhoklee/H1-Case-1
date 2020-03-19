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
        Udlejningskontrakt(int Ferieboligid)
        {

            //Lejekontrakt mellem udlejer og sydvest - bo vedr.boligen[Ferieboligid].[Adresse]
            //Ansvarlig udlejningskonsulent: [Udlejningskonsulentid] string variabel = "SELECT () Udlejningskonsulentid

            //Ejer af boligen: [Ejer]

            //perioden for udlejning:KontraktDato.aar,uge [aar],[uge] + mængden af uge(eller ugenumre).

            //Pris for udlejning:[Pris]


            //pris = if statement på hvilket uger 


        }

    }
}
