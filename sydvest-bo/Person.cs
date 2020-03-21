using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Person : Adresse
    {
        public int Personid { get; set; }
        // public int Adresseid { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Password { get; set; }

        public Person (int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) : base (adresseid, adressestring, postnr, bynavn)
        {
            Personid = personid;

            // Adresseid = adresseid;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Email = email;
            Tlf = tlf;
            Password = password;
        }
    }// ENd public class Person : Adresse
}
