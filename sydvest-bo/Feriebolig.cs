using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    
    public class Feriebolig : Adresse
    {
        //public enum FeriboligTyper
        //{
        //    Sommerhus,
        //    Ferielejlighed
        //}
        public int Ferieboligid { get; set; }
        public int Distriktid { get; set; }
        //public int Adresseid { get; set; } //  Originates from and lives in Adresse
        public int Ejerid { get; set; }
        public int Opsynsmandid { get; set; }
        public int Stoerrelse { get; set; }
        public int Rum { get; set; }
        public int Senge { get; set; }
        public string Kvalitet { get; set; }
        public double Pris { get; set; }
        // public FeriboligTyper FeriboligType { get; set; } = FeriboligTyper.Sommerhus; // [Sommerhus|Ferielejlighed]
        public string FeriboligType { get; set; } = "Sommerhus"; // ["Sommerhus"|"Ferielejlighed"]
        public string Noter { get; set; } = "Noter:";
        //public string Adressestring { get; set; } // Originates from and lives in Adresse
        //protected int Postnr { get; set; } //  Originates from and lives in Adresse : PostnrBy
        //protected string Bynavn { get; set; } // Originates from and lives in Adresse : PostnrBy

        public Feriebolig(int ferieboligid, int distriktid, int adresseid, int ejerid, int opsynsmandid, int stoerrelse, int rum, int senge, string kvalitet, double pris, string feriboligType, string noter, string adressestring, int postnr, string bynavn) :
           base(adresseid, adressestring, postnr, bynavn)
        {
            Ferieboligid = ferieboligid;
            Distriktid = distriktid;
            Ejerid = ejerid;
            Opsynsmandid = opsynsmandid;
            Stoerrelse = stoerrelse;
            Rum = rum;
            Senge = senge;
            Kvalitet = kvalitet;
            Pris = pris;
            if (feriboligType != "Sommerhus" | feriboligType != "Ferielejlighed")
                feriboligType = "Sommerhus";
            FeriboligType = feriboligType;
            Noter = noter;
        }

        public bool dbSelectFeriebolig()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertFeriebolig()
        {
            bool result = false;
            result = dbInsertAdresse();

            return result;
        }

        public bool dbUpdateFeriebolig()
        {
            bool result = false;
            result = dbUpdateAdresse();
            return result;
        }

        public bool dbDeleteFeriebolig()
        {
            bool result = false;
            result = dbDeleteAdresse();
            return result;
        }
    }
}
