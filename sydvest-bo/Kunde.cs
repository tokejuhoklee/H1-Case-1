using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Kunde : Person
    {
        public int Kundeid { get; set; }
        // public int Personid { get; set; }
        public string Noter { get; set; } = "Noter:";

        public Kunde(int kundeid, string noter, int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) :
            base(personid, fornavn, efternavn, email, tlf, password, adresseid, adressestring, postnr, bynavn)
        {
            Kundeid = kundeid;
            // Personid = personid;
            Noter = noter;
        }

        public bool dbSelectKunde()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertKunde()
        {
            bool result = false;
            result = dbInsertPerson();
            return result;
        }

        public bool dbUpdateKunde()
        {
            bool result = false;
            result = dbUpdatePerson();
            return result;
        }

        public bool dbDeleteKunde()
        {
            bool result = false;
            result = dbDeletePerson();
            return result;
        }

    }
}
