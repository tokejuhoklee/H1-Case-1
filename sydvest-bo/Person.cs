using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Person
    {
        public int Personid { get; set; }
        public int Adresseid { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Password { get; set; }
    }
}
