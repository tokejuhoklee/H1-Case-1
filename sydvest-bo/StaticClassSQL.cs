﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace sydvest_bo
{
   public  class StaticClassSQL
    {
        public StaticClassSQL()
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
                StaticClassSQL newConnect = new StaticClassSQL();

            }
            connect.Close();

        }
        public static void checkArea(int houseId)
        {
           
        }
    }
    