using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace H1_Case1
{
    public class DBConnectionTest
    {

        public string connectionString { get; set; }
        string username { get; set; }
        string password { get; set; }

        public DBConnectionTest()
        {
            Console.WriteLine("Write username");
            username = Console.ReadLine();
            Console.WriteLine("Write password");

            password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
                Console.Write("*");
            }
            //connectionStringUse(username, password);


        }

        public static void connectionStringUse(string userName, string userPass)
        {
            string connectionString = null;
            SqlConnection connect;
            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + userName + "; Password =" + userPass;
            connect = new SqlConnection(connectionString);
            string query1;
            Console.WriteLine("\nIndtast Sql Statement: ");
            query1 = Console.ReadLine();
            string query2 = "Select* from [Address]";


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
                    while (sqlReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", sqlReader.GetInt32(0),
                            sqlReader.GetString(1));
                        Console.WriteLine(sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1) + " - " + sqlReader.GetValue(0));

                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                sqlReader.Close();





                connect.Close();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Can not open connection ! ");
                Console.ReadKey();
                Console.Clear();
                DBConnectionTest newConnect = new DBConnectionTest();

            }
            connect.Close();

        }
        
    }


   
    }
