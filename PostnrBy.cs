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
    }// END public class PostnrBy
}
