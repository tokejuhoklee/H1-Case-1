﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Opsynsmand : Person
    {
        public int Opsynsmandid { get; set; }
        // public int Personid { get; set; }
        public int Distriktid { get; set; }
        public string Noter { get; set; } = "Noter:";

        public Opsynsmand(int opsynsmandid, int distriktid, string noter, int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) :
            base(personid, fornavn, efternavn, email, tlf, password, adresseid, adressestring, postnr, bynavn)
        {
            Opsynsmandid = opsynsmandid;
            // Personid = personid;
            Distriktid = distriktid;
            Noter = noter;
        }

        public bool dbSelectOpsynsmand()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertOpsynsmand()
        {
            bool result = false;
            result = dbInsertPerson();
            return result;
        }

        public bool dbUpdateOpsynsmand()
        {
            bool result = false;
            result = dbUpdatePerson();
            return result;
        }

        public bool dbDeleteOpsynsmand()
        {
            bool result = false;
            result = dbDeletePerson();
            return result;
        }

    }// END public class Opsynsmand : Person
}
