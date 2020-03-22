using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sydvest_bo
{
    public static class DB
    {
        static SqlConnection _dbConnection;
        static SqlDataReader _sqlReader = null;
        static SqlDataAdapter _adapter = null;

        static public string query { get; set; } = "";

        private static string _dbUser = "tec";

        public static string DbUser
        {
            get { return "nix"; }
            set { _dbUser = value; }
        }

        private static string _dbPassword = "OsteFis";
        public static string DbPassword
        {
            get { return "SpassW0rd"; }
            set { _dbPassword = value; }
        }

        private static string _dbConnectionionString = "Data Source = W2K19SQL.hq.gollomotors.dk; Initial Catalog = Sydvest-Bo; User ID = " + _dbUser + "; Password =" + _dbPassword;

        //static DB(string dbUserName, string dbUserPassword)
        //{
        //    _dbUserName = dbUserName;
        //    _dbUserPassword = dbUserPassword;
        //}
        public static void Open()
        {
            bool status = true;
            try
            {
                _dbConnection = new SqlConnection(_dbConnectionionString);
                _dbConnection.Open();
            }
            catch
            {
                status = false;
            }
            // return status;

        }

        public static void Close()
        {
            bool status = true;
            try
            {
                _sqlReader.Dispose();
                if (_dbConnection != null) // close the connection
                {
                    _dbConnection.Close();
                }
                _dbConnection.Dispose();
            }
            catch
            {
                status = false;
            }
            //return status;
        }// END public static void Close()

        public static List<object> Select(string query)
        {
            List<object> selection = new List<object>();
            List<object> tupel = new List<object>();
            // List<object> dataTypes = new List<object>(); // Not in use
            try
            {
                SqlCommand command = new SqlCommand(query, _dbConnection);
                _sqlReader = command.ExecuteReader();
                //// Add Collumn names as first tuple - only for testing
                //for (int t = 0; t < _sqlReader.FieldCount; t++)
                //{
                //    tupel.Add(_sqlReader.GetName(t));
                //}
                //selection.Add(tupel);
                while (_sqlReader.Read())
                {
                    tupel = new List<object>();
                    // dataTypes = new List<object>();
                    for (int t = 0; t < _sqlReader.FieldCount; t++)
                    {
                        tupel.Add(_sqlReader[t]);
                        // dataTypes.Add(_sqlReader[t].GetType());
                    }
                    selection.Add(tupel);
                }
            }
            finally
            {
                if (_sqlReader != null) // close this reader
                {
                    _sqlReader.Close();
                }
            }
            return selection;
        }// END public static List<object> Select(string query)

        public static bool Insert(string query)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(query, _dbConnection);
                SqlDataAdapter _adapter = new SqlDataAdapter();
                command = new SqlCommand(query, _dbConnection);
                _adapter.InsertCommand = new SqlCommand(query, _dbConnection);
                _adapter.InsertCommand.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (_adapter != null) // close this reader
                {
                    _adapter.Dispose();
                }
            }
            return result;
        }// END public static bool Insert(string query)

        //public static bool InsertMultiLine(string query, List<object> insert)
        public static bool InsertMultiLine(string query)
        {
            bool result = false;
            // List<object> tupel = new List<object>();
            // string temp = "";
            try
            {
                //// Hs nothing to do with insert
                SqlCommand command = new SqlCommand(query, _dbConnection);
                SqlDataAdapter _adapter = new SqlDataAdapter();
                //_sqlReader = command.ExecuteReader();

                //foreach (PostnrBy tupel in PostnrByList)
                //{

                command = new SqlCommand(query, _dbConnection);
                _adapter.InsertCommand = new SqlCommand(query, _dbConnection);
                _adapter.InsertCommand.ExecuteNonQuery();
                Console.Write(".");
                //}
                //while (_sqlReader.Read())
                //{
                //    tupel = new List<object>();
                //    for (int t = 0; t < _sqlReader.FieldCount; t++)
                //    {
                //        tupel.Add(_sqlReader[t]);
                //    }
                //    insert.Add(tupel);
                //}
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (_adapter != null) // close this reader
                {
                    _adapter.Dispose();
                }
            }
            return result;
        }

        public static bool Update(string query)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(query, _dbConnection);
                SqlDataAdapter _adapter = new SqlDataAdapter();
                command = new SqlCommand(query, _dbConnection);
                _adapter.UpdateCommand = new SqlCommand(query, _dbConnection);
                _adapter.UpdateCommand.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (_adapter != null) // close this reader
                {
                    _adapter.Dispose();
                }
            }
            return result;
        }// END public static bool Update(string query)

        public static bool Delete(string query)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(query, _dbConnection);
                SqlDataAdapter _adapter = new SqlDataAdapter();
                command = new SqlCommand(query, _dbConnection);
                _adapter.DeleteCommand = new SqlCommand(query, _dbConnection);
                _adapter.DeleteCommand.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (_adapter != null) // close this reader
                {
                    _adapter.Dispose();
                }
            }
            return result;
        }// END public static bool Delete(string query)
    }// END public static class DB
}
