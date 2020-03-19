using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace sydvest_bo
{
    public class StaticClassSQL
    {

        public string connectionString { get; set; }
        string username { get; set; }
        string password { get; set; }
        public StaticClassSQL()
        {
            Console.WriteLine("Write username");
            username = Console.ReadLine();
            Console.WriteLine("Write password");

            password = Console.ReadLine();
            //  while (true)
            //  {
            //      var key = System.Console.ReadKey(true);
            //      if (key.Key == ConsoleKey.Enter)
            //          break;
            //      password += key.KeyChar;
            //      Console.Write("*");
            //}
            test(username,password);
        }
        public static void test(string username,string userpass)
        {
            string userName= username;
            string userPass= userpass;
            string connectionString = null;
            SqlConnection connect;
            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + userName + "; Password =" + userPass;
            connect = new SqlConnection(connectionString);
            string query1;
            Console.WriteLine("\nIndtast Sql Statement: ");
            query1 = Console.ReadLine();
            string query2 = "SELECT TOP (1000)    [Personid]      , [Adresseid]      , [Fornavn]      , [Efternavn]      , [Email]      , [Tlf]      , [Password]FROM [Sydvest-Bo].[dbo].[Person]go";

            try
            {
                SqlCommand command1;
                SqlCommand command2;
                SqlDataReader sqlReader = null;



                connect.Open();
                Console.WriteLine("Connection Open ! ");
                command2 = new SqlCommand(query2, connect);
                command1 = new SqlCommand(query1, connect);

                sqlReader = command2.ExecuteReader();


                 if (sqlReader.HasRows)
            {
                 while (sqlReader.HasRows)
                 {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", sqlReader.GetName(0),
                        sqlReader.GetName(1), sqlReader.GetName(2), sqlReader.GetName(3));

                    while (sqlReader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", sqlReader.GetInt32(0),
                            sqlReader.GetValue(1), sqlReader.GetValue(2),sqlReader.GetValue(3));
                    }
                    sqlReader.NextResult();
                 }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }





                connect.Close();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Can not open connection ! ");
                Console.ReadKey();
                Console.Clear();
                StaticClassSQL newConnect = new StaticClassSQL();

            }
            connect.Close();

        }
        public static void checkArea(int houseId,string userName, string userPass)
        {

            string vestEllerSyd;
            int postNr=0;

            SqlDataReader sqlReader = null;
            string connectionString = null;
            SqlConnection connect;
            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + userName + "; Password =" + userPass;
            connect = new SqlConnection(connectionString);
            string query1;
            // Console.WriteLine("\nIndtast Sql Statement: ");
            query1 = Console.ReadLine();
            string query2 = $"Select adresseid from sommerhus where ";


            SqlCommand command2 = new SqlCommand(query2, connect);

            sqlReader = command2.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", sqlReader.GetName(0),
                        sqlReader.GetName(1));

                    while (sqlReader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", sqlReader.GetInt32(0),
                            sqlReader.GetString(1));
                    }
                    sqlReader.NextResult();
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            sqlReader.Close();

            if (postNr > 4000)
            {
                vestEllerSyd = "øst";
            }
            else vestEllerSyd = "vest";




        }
    }
}