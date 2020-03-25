using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Kundekonsulent : Person
    {
        public int Kundekonsulentid { get; set; }
        // public int Personid { get; set; }
        public string Noter { get; set; } = "Noter:";

        public Kundekonsulent(int kundekonsulentid, string noter, int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) :
            base(personid, fornavn, efternavn, email, tlf, password, adresseid, adressestring, postnr, bynavn)
        {
            Kundekonsulentid = kundekonsulentid;
            // Personid = personid;
            Noter = noter;
        }
    }
}
