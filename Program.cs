using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region opgavebeskrivelse
//1. Man skal kunne oprette, rette og slette en sommerhusejere
//2. Man skal kunne oprette, rette og slette en sommerhusejere
//3. Man skal kunne oprette, rette og slette en sommerhusejere
//4.Man skal kunne få listet et sommerhus reservationer, samt få vist en specifikation af den eneklte udlejning
//5. En ejer kan godt have glere sommerhuse
//6.Man skal kunnne administrere områder
//7.Man skal kunne administrere "sæsonkategori og tilhørende priser
//8.Man skal kunne administrere Inspektiører
#endregion


namespace H1_Case1
{
    class Program
    {
        static void Main(string[] args)
        {
            UI UserInterface = new UI();
            DBConnectionTest connectTest = new DBConnectionTest();
        }
    }
}
