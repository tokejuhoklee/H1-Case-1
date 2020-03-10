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

        string connectionString { get; set; }
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
            connectionStringUse(username, password);

        }

        public static void connectionStringUse(string userName,string userPass)
        {
            string connectionString = null;
            SqlConnection connect;
            connectionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = "+userName +"; Password ="+userPass;
            connect = new SqlConnection(connectionString);
            try
            {
                connect.Open();
                Console.WriteLine("Connection Open ! ");
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            connect.Close();

            Console.Read();
        }

        



    }
}
