﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Ejer : Person
    {
        public int Ejerid { get; set; }
        public string Ejertype { get; set; }
        public string Noter { get; set; } = "Noter:";
        // public int Personid { get; set; }
        public Ejer(int ejerid, string ejertype, string noter, int personid, string fornavn, string efternavn, string email, string tlf, string password, int adresseid, string adressestring, int postnr, string bynavn) :
            base(personid, fornavn, efternavn, email, tlf, password, adresseid, adressestring, postnr, bynavn)
        {
            Ejerid = ejerid;
            Ejertype = ejertype;
            Noter = noter;
            // Personid = personid;
        }
        public bool dbSelectEjer()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertEjer()
        {
            bool result = false;
            result = dbInsertPerson();
            return result;
        }

        public bool dbUpdateEjer()
        {
            bool result = false;
            result = dbUpdatePerson();
            return result;
        }

        public bool dbDeleteEjer()
        {
            bool result = false;
            result = dbDeletePerson();
            return result;
        }
    }
}
