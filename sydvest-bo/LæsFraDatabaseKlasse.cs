using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sydvest_bo
{
    public class LæsFraDatabaseKlasse
    {
        string username{get;set;}
        string password { get; set; }
        string table { get; set; }
        int row { get; set; }
        string query { get; set; }
        public static void ReadAllFromTable(string selectTable, int selectRow, int selectColumns, string userName, string userPass)
        {
            var stringBuilderForMultipleColumns = new StringBuilder();
            SqlDataReader sqlReader = null;
            string connectionString = null;
            SqlConnection connect;
            string query;
            string columntamount = "";

            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + userName + "; Password =" + userPass;
            connect = new SqlConnection(connectionString);
            
            // query = "SELECT * FROM [Person]";

            // Join person, adresse, postnr
            // query = "SELECT * FROM [Person] JOIN [Adresse] ON [Person].Adresseid = [Adresse].Adresseid JOIN [PostnrBy] ON [Adresse].Postnr = [PostnrBy].Postnr";

            // Kunde - udvælg og specifik data -
            query = "SELECT Kunde.Kundeid, Person.Fornavn, Person.Efternavn, Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Kunde.Noter FROM [Kunde] JOIN [Person] ON [Kunde].Personid = [Person].Personid JOIN [Adresse] ON [Person].Adresseid = [Adresse].Adresseid JOIN [PostnrBy] ON [Adresse].Postnr = [PostnrBy].Postnr";
            // query = "SELECT * FROM [Kunde] JOIN [Person] ON [Kunde].Personid = [Person].Personid JOIN [Adresse] ON [Person].Adresseid = [Adresse].Adresseid JOIN [PostnrBy] ON [Adresse].Postnr = [PostnrBy].Postnr";
            connect.Open();

            SqlCommand command = new SqlCommand(query, connect);
            sqlReader = command.ExecuteReader();
            for (int x = 0; x < sqlReader.FieldCount; x++)
            {
                Console.Write(sqlReader.GetName(x) + "\t");
            }
            Console.Clear();
            Console.WriteLine(query + "\n");
            while (sqlReader.Read())
            {

                for (int i = 0; i < sqlReader.FieldCount; i++)
                {
                    Console.Write(sqlReader[i] + ",\t");
                }
                Console.WriteLine();
            }
            sqlReader.Close();
            Console.WriteLine("- Press a Key");
            Console.ReadKey(true);


            // -----------------

            query = "SELECT * FROM [Person] JOIN [Adresse] ON [Person].Adresseid = [Adresse].Adresseid JOIN [PostnrBy] ON [Adresse].Postnr = [PostnrBy].Postnr";

            sqlReader = command.ExecuteReader();
            for (int x = 0; x < sqlReader.FieldCount; x++)
            {
                Console.Write(sqlReader.GetName(x) + "\t");
            }
            Console.Clear();
            Console.WriteLine(query + "\n");
            while (sqlReader.Read())
            {

                for (int i = 0; i < sqlReader.FieldCount; i++)
                {
                    Console.Write(sqlReader[i] + ",\t");
                }
                Console.WriteLine();
            }
            sqlReader.Close();
            Console.WriteLine("- Press a Key");
            Console.ReadKey(true);

            connect.Close();
        }
        public static void SelectFrom(string selectTable,int selectRow,int selectColumns,string userName,string userPass)//testfunktion for at oprette læse metoder
        {
            var stringBuilderForMultipleColumns = new StringBuilder();
            SqlDataReader sqlReader = null;
            string connectionString = null;
            SqlConnection connect;
            string query;
            string columntamount = "";

            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + userName + "; Password =" + userPass;
            connect = new SqlConnection(connectionString);
            query = "SELECT TOP(5)[Personid], [Adresseid], [Fornavn], [Efternavn], [Email], [Tlf], [Password] FROM [Person] go";

            connect.Open();

            SqlCommand command = new SqlCommand(query, connect);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                for (int i = 0; i < sqlReader.FieldCount; i++)
                {
                    Console.Write(sqlReader[i] + ",");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            sqlReader.Close();

            //for (int i = 0; i < selectColumns; i++)
            //{
            //    columntamount+="\t{"+i+"}";

            //}


            //if (sqlReader.HasRows)
            //{
            //    while (sqlReader.HasRows)
            //    {
            //        Console.WriteLine("\t{0}\t{1}", sqlReader.GetName(0),
            //            sqlReader.GetName(1));

            //        while (sqlReader.Read())
            //        {
            //            Console.WriteLine("\t{0}\t{1}", sqlReader.GetInt32(0),
            //                sqlReader.GetString(1));
            //        }
            //        sqlReader.NextResult();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No rows found.");
            //}
            sqlReader.Close();

            //if (postNr > 4000)
            //{
            //    vestEllerSyd = "øst";
            //}
            //else vestEllerSyd = "vest";


        }
    }
   
}
