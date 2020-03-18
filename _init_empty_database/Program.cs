using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Set console window to max size
using System.Runtime.InteropServices;

// Read from file Specifik
using System.IO;

// SQL Server Specifik
using System.ComponentModel;
using System.Data;
// using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
// using System.Configuration;


namespace _init_empty_database
{
    class Program
    {
        // Figure out window max size
        // https://www.c-sharpcorner.com/code/448/code-to-auto-maximize-console-application-according-to-screen-width-in-c-sharp.aspx

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            string m1 = "The current window width is {0}, and \n" +
                "the current window height is {1}.";
            Console.WriteLine(m1, Console.WindowWidth,
                                  Console.WindowHeight);

            string dbHostName = "W2K19SQL.hq.gollomotors.dk";
            string dbNavn = "Sydvest-Bo";
            string dbUsername = "tec";
            // string dbUsername = "sa";
            string dbTable = "PostnrBy";

            // test if we have a password as an argument
            string dbPassword = "";
            try
            {
                dbPassword = args[0];
            }
            catch
            {
                dbPassword = "";
            }
            finally
            {
                if (String.IsNullOrEmpty(dbPassword))
                {
                    Console.WriteLine("\nMissing password as argument 1:\nUsages:\n\t_init_empty_database.exe [DP password]\n");
                    Console.ReadKey(true);
                    System.Environment.Exit(0);
                }
            }

            string connetionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", dbHostName, dbNavn, dbUsername, dbPassword);
            // Init PostnrBy Table from File
            List<PostnrBy> PostnrByList = new List<PostnrBy>() { };
            // Læs fra en fil
            string path = @"..\..\..\Resources\PostnrBy.csv";
            Console.Write($"Reading from file: {path}\n");
            int i = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                string readLineFromFile = "";
                while (true)
                {
                    readLineFromFile = sr.ReadLine();
                    if (readLineFromFile == null) // Close I/O StreamReader at eof or error;
                    {
                        Console.WriteLine(i-1);
                        sr.Close();
                        sr.Dispose();
                        break;
                    }
                    // 
                    if (i > 0) // skip first header line of the file
                    {
                        readLineFromFile = String.Format("{0}", readLineFromFile);
                        string[] tempTextLine = readLineFromFile.Split(';');
                        // Check that we dont have Null (or other stuff)
                        for (int j = 0; j < tempTextLine.Length; j++)
                        {
                            if (String.IsNullOrEmpty(tempTextLine[j])) tempTextLine[j] = "";
                        }
                        PostnrByList.Add(new PostnrBy(tempTextLine[0], tempTextLine[1]));
                        Console.Write(".");
                    }
                    i++;
                }
            } // end read from file

            // DB tupel: Postnr,Bynavn
            dbTable = "PostnrBy";

            SqlConnection SydvestBoDb = new SqlConnection(connetionString);
            SydvestBoDb.Open();
            SqlCommand command; //       This class is used to perform operations of reading and writing into the database. Hence, the first step is to make sure that we create a variable type of this class. This variable will then be used in subsequent steps of reading data from our database.
            SqlDataAdapter adapter = new SqlDataAdapter(); // The DataAdapter object is used to perform specific SQL operations such as insert, delete and update commands.
            string sql = ""; //         Hold our SQL command string.

            // DELETE FROM [PostnrBy]

            Console.WriteLine($"Remove tupels form Table {dbNavn}[{dbTable}]");
            sql = $"DELETE FROM [{dbTable}]";
            command = new SqlCommand(sql, SydvestBoDb);
            adapter.InsertCommand = new SqlCommand(sql, SydvestBoDb);
            adapter.InsertCommand.ExecuteNonQuery();
            //SydvestBoDb.Close();
            //SydvestBoDb.Open();

            // INSERT INTO [Postnr]

            Console.Write($"Insert tupels into Table {dbNavn}[{dbTable}]\n");
            // Define sql insert statement
            i = 0;
            foreach (PostnrBy tupel in PostnrByList)
            {
                sql = $"INSERT INTO [{dbTable}]([Postnr],[Bynavn])" + 
                    $"values('{tupel.Postnr}','{tupel.Bynavn}')";
                command = new SqlCommand(sql, SydvestBoDb);
                adapter.InsertCommand = new SqlCommand(sql, SydvestBoDb);
                adapter.InsertCommand.ExecuteNonQuery();
                Console.Write(".");
                i++;
            }
            SydvestBoDb.Close();
            Console.WriteLine(i);

            Console.WriteLine("\nPress any key to exit -\n\t\t\t Where's the Anykey ?");
            Console.ReadKey(true);
        }// END static void Main(string[] args)
    }// END class Program
}// END namespace _init_empty_database
