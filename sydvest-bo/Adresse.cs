using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Adresse : PostnrBy
    {
        public int Adresseid { get; set; }
        public string Adressestring { get; set; }
        // public int Postnr { get; set; }
        public Adresse(int adresseid, string adressestring, int postnr, string bynavn) : base (postnr, bynavn)
        {
            Adresseid = adresseid;
            Adressestring = adressestring;
        }

        public bool dbSelectAdresse()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertAdresse()
        {
            bool result = false;
            result = dbInsertPostnrBy();
            return result;
        }

        public bool dbUpdateAdresse()
        {
            bool result = false;
            //result = dbUpdatePostnrBy();
            return result;
        }

        public bool dbDeleteAdresse()
        {
            bool result = false;
            //result = dbDeletePostnrBy();
            return result;
        }
    }// END public class Adresse : PostnrBy
}
