using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Feriebolig
    {
        public int Ferieboligid { get; set; }
        public int Distriktid { get; set; }
        public int Adresseid { get; set; }
        public int Ejerid { get; set; }
        public int Opsynsmandid { get; set; }
        public int Stoerrelse { get; set; }
        public int Rum { get; set; }
        public int Senge { get; set; }
        public string Kvalitet { get; set; }
        public double Pris { get; set; }
        public string FeriboligType { get; set; }
        public string Noter { get; set; }
    }
}
