using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class PostnrBy
    {
        protected int Postnr { get; set; }
        protected string Bynavn { get; set; }

        public PostnrBy (int postnr, string bynavn)
        {
            //if (Postnr > 99 & Postnr < 10000)
            //{
                Postnr = postnr;
                Bynavn = bynavn;
            //}
        }

        public bool dbSelectPostnrBy()
        {
            bool result = false;
            return result;
        }

        public bool dbInsertPostnrBy()
        {
            bool result = false;
            return result;
        }

        public bool dbUpdatePostnrBy()
        {
            bool result = false;
            return result;
        }

        public bool dbDeletePostnrBy()
        {
            bool result = false;
            return result;
        }
    }// END public class PostnrBy
}
