﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Udlejningskonsulent : Person
    {
        public int Udlejningskonsulentid { get; set; }
        // public int Personid { get; set; }
        public int Distriktid { get; set; }
        public string Noter { get; set; } = "Noter:";

        public Udlejningskonsulent(int udlejningskonsulentid, int distriktid, string noter, int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) :
            base(personid, fornavn, efternavn, email, tlf, password, adresseid, adressestring, postnr, bynavn)
        {
            Udlejningskonsulentid = udlejningskonsulentid;
            // Personid = personid;
            Distriktid = distriktid;
            Noter = noter;
        }
        
    }//END public class Udlejningskonsulent : Person
}
