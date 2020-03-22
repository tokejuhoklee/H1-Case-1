using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class TestProgram
    {
        public static void Test()
        {
            Console.Clear();
            Console.WriteLine(" ---- TestProgram, Test Metode --- ");

            string query;
            string ConsoleQueryTitle;
            string result;
            List<object> selection = new List<object>();
            // List<object> tupel = new List<object>();

            DB.Open();

            ConsoleQueryTitle = "1 Sommerhusejer";
            query = "SELECT Ejer.Ejerid, Ejer.Ejertype, Person.Fornavn, Person.Efternavn, " +
                "Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Ejer.Noter " +
                "FROM Ejer " +
                "JOIN Person ON Ejer.Personid = Person.Personid " +
                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                "WHERE Ejer.Ejertype = 'Sommerhusejer' " +
                "ORDER BY Person.Fornavn";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------
            ConsoleQueryTitle = "2 Sommerhuse *";
            query = "SELECT * FROM Feriebolig " +
                "JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid " +
                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                "ORDER BY Feriebolig.FeriboligType";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------

            ConsoleQueryTitle = "3 Kunde - udvælg specifikke data fra samlingen - ikke alle";
            query = "SELECT Kunde.Kundeid, Person.Fornavn, Person.Efternavn, Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Kunde.Noter " +
                "FROM Kunde JOIN Person ON Kunde.Personid = Person.Personid " +
                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------
            ConsoleQueryTitle = "8 Inspektører";
            query = "SELECT Ejer.Ejerid, Ejer.Ejertype, Person.Fornavn, Person.Efternavn, " +
                "Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Ejer.Noter " +
                "FROM Ejer " +
                "JOIN Person ON Ejer.Personid = Person.Personid " +
                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                "WHERE Ejer.Ejertype = 'Lejligheds inspektør' " +
                "ORDER BY Person.Fornavn";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Insert -------------------------------------------
            ConsoleQueryTitle = " Insert into Sandbox";
           
            query = $"INSERT INTO Sandbox (Id, Navn, Heltal, Penge) VALUES" +
                $"(6,'nisser',32,32.50)";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";
            if (DB.Insert(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------
            ConsoleQueryTitle = "Slecet Sandbox efter 1. insert";
            query = "SELECT *" +
                "FROM Sandbox";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Insert -------------------------------------------
            ConsoleQueryTitle = " Insert into Sandbox 2";
            query = $"INSERT INTO Sandbox (Id, Navn, Heltal, Penge) VALUES" +
                $"(7,'Tosser',64,100), " +
                $"(8,'Pangel',128,17.00)";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";

            if (DB.Insert(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Insert -------------------------------------------

            ConsoleQueryTitle = " Insert into Sandbox 3";
            query = $"INSERT INTO Sandbox (Id, Navn, Heltal, Penge) VALUES" +
                $"(9,'hestegaloscher',512,100), " +
                $"(8,'Pramgods',1024,17.01)";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";

            if (DB.Insert(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Update -------------------------------------------

            ConsoleQueryTitle = " Update into Sandbox 3";
            query = $"UPDATE Sandbox SET " +
                "Navn = 'Updateret' " +
                "WHERE ID = 8";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";

            if (DB.Update(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Update -------------------------------------------

            ConsoleQueryTitle = " Insert into Sandbox 3";
            query = $"UPDATE Sandbox SET " +
                "Navn = 'Updateret', Heltal = 6 " +
                "WHERE ID = 6";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";

            if (DB.Update(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------
            ConsoleQueryTitle = "Slecet Sandbox efter 2. insert";
            query = "SELECT *" +
                "FROM Sandbox";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL Delete -------------------------------------------

            ConsoleQueryTitle = " Delete from Sandbox";
            query = $"DELETE Sandbox " +
                "WHERE ID = 6 OR ID = 7 OR ID = 8 OR Id = 9";

            result = "";
            result += ConsoleQueryTitle + "\n";
            result += query + "\n";

            if (DB.Delete(query))
            {
                result += "det gik godt\n";
            }
            else
            {
                result += "det gik ikke godt - fyha\n";
            }

            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // ----------- Ny SQL forespørgsel -------------------------------------------
            ConsoleQueryTitle = "Slecet Sandbox efter 2. insert";
            query = "SELECT *" +
                "FROM Sandbox";

            Console.Clear();
            Console.WriteLine(ConsoleQueryTitle);
            Console.WriteLine(query + "\n");
            selection = DB.Select(query);
            result = "";
            foreach (List<object> tupel in selection)
            {
                foreach (object item in tupel)
                {
                    result += ($"{item} ");
                }
                result += ("\n");
            }
            result += $"\n ---- Press a Key ------------";
            Console.WriteLine(result);
            Console.ReadKey(true);

            // --------------------------
            DB.Close();

            //Console.WriteLine("\n\n press any key to exit.");
            //Console.ReadKey(true);
        }
    }
}
