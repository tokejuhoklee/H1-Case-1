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
    }// END public class Adresse : PostnrBy
}
