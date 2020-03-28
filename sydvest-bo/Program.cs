using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;// console screen controle
using System.Threading.Tasks;
using System.Runtime.InteropServices;// console screen controle
using System.IO;// console screen controle, file I/O
//using System.Globalization;

namespace sydvest_bo
{
    class Program
    {
        // Console windowd controle
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        // Scroll vars
        public static int saveBufferWidth;
        public static int saveBufferHeight;
        public static int saveWindowHeight;
        public static int saveWindowWidth;
        public static bool saveCursorVisible;

        // Color abbreviation
        static public ConsoleColor blaaM = ConsoleColor.DarkBlue;
        static public ConsoleColor cyanM = ConsoleColor.DarkCyan;
        static public ConsoleColor cyan = ConsoleColor.Cyan;
        static public ConsoleColor groenM = ConsoleColor.DarkGreen;
        static public ConsoleColor blaa = ConsoleColor.Blue;
        static public ConsoleColor groen = ConsoleColor.Green;
        static public ConsoleColor gulM = ConsoleColor.DarkYellow;
        static public ConsoleColor gul = ConsoleColor.Yellow;
        static public ConsoleColor roedM = ConsoleColor.DarkRed;
        static public ConsoleColor roed = ConsoleColor.Red;
        static public ConsoleColor magentaM = ConsoleColor.DarkMagenta;
        static public ConsoleColor Magenta = ConsoleColor.Magenta;
        static public ConsoleColor sort = ConsoleColor.Black;
        static public ConsoleColor graaM = ConsoleColor.DarkGray;
        static public ConsoleColor graa = ConsoleColor.Gray;
        static public ConsoleColor hvid = ConsoleColor.White;

        static void Main(string[] args)
        {
            // init windows size
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            // Determine common values for windows sizes and positioning
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            /* **************************************************************************************
             * 
             * Call Test environment : TestProgram.Test(), if some start up arg is: test
             */

            try
            {
                foreach (string item in args)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (item == "test")
                        {
                            //Continue to test environemnt
                            TestProgram.Test();
                        }
                    }
                }
            }
            catch
            {
                // nothing to do
            }
            /* **************************************************************************************
             * Return from Test environment
             * 
             * Start actual program
             */

            // Should use some program commandline args to give DP login credietials

            DB.Open(); // Open database connection
            string query;
            List<object> LoginSelection = new List<object>();
            int loginPersonid = 0;
            string loginType = "";
            string loginEmail = "";
            string loginPassword;
            int loginAttemptsLeft = 3;
            bool userValidated = false;
            

            // Sample Text
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tellus velit, aliquam quis eros vel, malesuada bibendum mi. Mauris non ultricies mauris, at accumsan tellus. Etiam tincidunt venenatis nisl in molestie.Nunc quis.";

            // Window contentTak Jan
            string loginWindowText1Welcome = String.Format($"Velkommen til Sydvest-Bo\n\nDu skal logge ind for at kunne bruge programmet.\n\nEt blankt password vil afslutte programmet.");
            string loginWindowText2user =     String.Format($"E-mail  : ");
            string loginWindowText3password = String.Format($"Password: ");
            string helpWwindowText1dokuwiki = String.Format($"Du kan få hjælp på Sydvest-Bo´s DokuWiki\n http://wiki.w2k19sql.hq.gollomotors.dk/");

            Window LoginWindow = new Window(standardWindowX, standardWindowY, 60, 24, 0, hvid, graaM, sort, false, "Login");
            Frame LoginWindow1user = new Frame(standardWindowX, standardWindowY + 8, LoginWindow.W, 6, 0, sort, graa, sort, false);
            Frame LoginWindow2password = new Frame(standardWindowX, standardWindowY + 10, LoginWindow.W, 6, 0, sort, graa, sort, false);
            Window HelpWindow = new Window(standardWindowX, 3, 60, 8, 0, hvid, graaM, sort, false, "Help");

            while (loginAttemptsLeft > 0 & !userValidated)
            {
                Console.Clear();
                LoginWindow.Visible = true;
                LoginWindow1user.Visible = true;
                LoginWindow2password.Visible = true;
                LoginWindow.Draw();
                LoginWindow.Print(loginWindowText1Welcome);

                if (loginAttemptsLeft < 3) // Draw Help window;
                {
                    HelpWindow.Visible = true;
                    HelpWindow.Draw();
                    HelpWindow.Print(helpWwindowText1dokuwiki);
                }

                userValidated = false;
                loginEmail = LoginWindow1user.ReadInput(loginWindowText2user);
                loginPassword = LoginWindow2password.ReadInput(loginWindowText3password);

                // validat user: Get user type
                if (loginEmail == "" | loginPassword == "")
                {
                    userValidated = true;
                    // set loginType for quick access
                    //loginPersonid = 1;
                    //loginType = "Udlejningskonsulent";

                    loginPersonid = 4;
                    loginType = "Kundekonsulent";

                    // loginPersonid = 33;
                    // loginType = "Kunde";

                    // loginPersonid = 7;
                    // loginType = "Sommerhus Ejer";

                    // loginPersonid = 29;
                    // loginType = "Lejligheds inspektør";

                    // loginPersonid = 14;
                    // loginType = "Opsynsmand";
                }
                else if (loginEmail == "")
                {
                    // No black email
                    helpWwindowText1dokuwiki += "\n - Du kan ikke bruge en blank email....";
                }
                else if (loginEmail != "" | loginPassword != "")
                {
                    query = "SELECT Person.Password FROM Person " +
                        $"WHERE Email = '{loginEmail}'";
                    LoginSelection = DB.Select(query);
                    foreach (List<object> tupel in LoginSelection)
                    {
                        foreach (object item in tupel)
                        {
                            if (loginPassword == (string)item)
                            {
                                userValidated = true;
                            }
                        }
                    }
                    // Check if user is validated
                
                    if (userValidated) // fetch loginPersonid og loginType
                    {
                        bool found = false;
                        // Get this users loginPersonid
                        query = "SELECT Person.Personid FROM Person " +
                            $"WHERE Email = '{loginEmail}'";
                        LoginSelection = DB.Select(query);
                        foreach (List<object> tupel in LoginSelection)
                        {
                            foreach (object item in tupel)
                            {
                                if (item != null)
                                {
                                    loginPersonid = (int)item;
                                }
                            }
                        }
                        // Search each loginType to see what usertype this login is
                        // Udlejningskonsulent
                        query = "SELECT Personid FROM Udlejningskonsulent " +
                            $"WHERE Personid = {loginPersonid}";
                        LoginSelection = DB.Select(query);
                        foreach (List<object> tupel in LoginSelection)
                        {
                            foreach (object item in tupel)
                            {
                                if (item != null)
                                {
                                    found = true;
                                    loginType = "Udlejningskonsulent";
                                }
                            }
                        }
                        // Kundekonsulent
                        if (!found)
                        {
                            query = "SELECT Personid FROM Kundekonsulent " +
                            $"WHERE Personid = {loginPersonid}";
                            LoginSelection = DB.Select(query);
                            foreach (List<object> tupel in LoginSelection)
                            {
                                foreach (object item in tupel)
                                {
                                    if (item != null)
                                    {
                                        found = true;
                                        loginType = "Kundekonsulent";
                                    }
                                }
                            }
                        }
                        // Ejer
                        if (!found)
                        {
                            query = "SELECT Personid FROM Ejer " +
                            $"WHERE Personid = {loginPersonid} AND Ejertype = 'Sommerhusejer'";
                            LoginSelection = DB.Select(query);
                            foreach (List<object> tupel in LoginSelection)
                            {
                                foreach (object item in tupel)
                                {
                                    if (item != null)
                                    {
                                        found = true;
                                        loginType = "Ejer";
                                    }
                                }
                            }
                        }
                        // Lejligheds inspektør
                        if (!found)
                        {
                            query = "SELECT Personid FROM Ejer " +
                            $"WHERE Personid = {loginPersonid} AND Ejertype = 'Lejligheds inspektør'";
                            LoginSelection = DB.Select(query);
                            foreach (List<object> tupel in LoginSelection)
                            {
                                foreach (object item in tupel)
                                {
                                    if (item != null)
                                    {
                                        found = true;
                                        loginType = "Lejligheds inspektør";
                                    }
                                }
                            }
                        }
                        // Opsynsmand
                        if (!found)
                        {
                            query = "SELECT Personid FROM Opsynsmand " +
                            $"WHERE Personid = {loginPersonid}";
                            LoginSelection = DB.Select(query);
                            foreach (List<object> tupel in LoginSelection)
                            {
                                foreach (object item in tupel)
                                {
                                    if (item != null)
                                    {
                                        found = true;
                                        loginType = "Opsynsmand";
                                    }
                                }
                            }
                        }
                        // Kunde
                        if (!found)
                        {
                            query = "SELECT Personid FROM Kunde " +
                            $"WHERE Personid = {loginPersonid}";
                            LoginSelection = DB.Select(query);
                            foreach (List<object> tupel in LoginSelection)
                            {
                                foreach (object item in tupel)
                                {
                                    if (item != null)
                                    {
                                        found = true;
                                        loginType = "Kunde";
                                    }
                                }
                            }
                        }
                    }// END else if (loginEmail != "" || loginPassword != "")
                }// END if (userValidated) // fetch loginPersonid og loginType
                loginAttemptsLeft--;
            }// while (loginAttemptsLeft > 0)

            // open main menues
            while (userValidated & loginPersonid != 0)
            {
                if (loginType == "Udlejningskonsulent")
                {
                    MenuUdlejningskonsulent(loginType, loginEmail, loginPersonid);
                }
                else if (loginType == "Kundekonsulent")
                {
                    MenuKundekonsulent(loginType, loginEmail, loginPersonid);
                }
                else if (loginType == "Ejer")
                {
                    MenuEjer(loginType, loginEmail, loginPersonid);
                }
                else if (loginType == "Lejligheds inspektør")
                {
                    MenuInspektor(loginType, loginEmail, loginPersonid);
                }
                else if (loginType == "Opsynsmand")
                {
                    MenuOpsynsmand(loginType, loginEmail, loginPersonid);
                }
                else if (loginType == "Kunde")
                {
                    MenuKunde(loginType, loginEmail, loginPersonid);
                }
                userValidated = false;
            }// End while (userValidated)  *********** user loged out

            // Exit program;
            DB.Close();

        }//END static void Main(string[] args)

        static public void MenuUdlejningskonsulent(string loginType, String loginEmail, int loginPersonid)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            //int standardWindowX = 25;
            //int standardWindowY = 25;
            //int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            //int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";
            string query;
            List<object> selection = new List<object>();

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 4, 0, hvid, blaaM, sort, true, loginType);

            Window MainMenu = new Window(1, consoleHeight - 24, 30, 20, 0, hvid, blaaM, sort, true, "Menu");
            Window MainWindow1 = new Window(consoleWidth - (60 + 3), consoleHeight - 15, 60, 12, 0, hvid, blaaM, sort, true, "Start Info");
            Window MainWindow2 = new Window(MainMenu.X + MainMenu.W + 12 + 3, consoleHeight - 20, consoleWidth - (MainMenu.X + MainMenu.W + 12 + 3 +3), 18, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow= new Window(1, HeaderWindow.Y, consoleWidth - 3, consoleHeight - (6 + 24 + 2), 0, hvid, blaaM, sort, false, "");
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();
                
                HeaderWindow.Draw();
                HeaderWindow.Print($"Du er logget ind som {loginType}");
                
                MainMenu.Draw();
                MainMenu.Print($"\n1 - Somerhus Ejere\n\n2 - Ferieboliger\n\n3 - Områder\n\n4 - Inspektøre\n\n5 - Opsynsmænd\n\n\n\n\nF5 - Afslut");
                
                MainWindow1Text1 = $"{loginEmail} er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);

                

                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: // 1 - Somerhus Ejere
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Somerhus Ejere";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            // List sommerhusejere
                            query = "SELECT Ejer.Ejerid, Ejer.Ejertype, Person.Fornavn, Person.Efternavn, " +
                                "Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email " +
                                "FROM Ejer " +
                                "JOIN Person ON Ejer.Personid = Person.Personid " +
                                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                                "WHERE Ejer.Ejertype = 'Sommerhusejer' " +
                                "ORDER BY Person.Efternavn";
                            
                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }

                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Somerhus Ejere Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D2: // 2 - Ferieboliger
                        case ConsoleKey.NumPad2:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Ferieboliger";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            // List Ferieboligerne
                            query = "SELECT * FROM Feriebolig " +
                                "JOIN Distrikt ON Feriebolig.Distriktid = Distrikt.Distriktid " +
                                "JOIN Ejer ON Feriebolig.Ejerid = Ejer.Ejerid " +
                                "JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid " +
                                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                                "WHERE FeriboligType = 'Sommerhus' " +
                                "order by Ejer.Ejerid asc; ";

                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Feriebolig Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D3: // 3 - Områder
                        case ConsoleKey.NumPad3:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Områder og Distrikter";
                            // List Distrikter
                            query = "SELECT * FROM Distrikt " +
                                "ORDER BY Omraade asc; ";

                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Område Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D4: // 4 - Inspektøre
                        case ConsoleKey.NumPad4:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Inspektører";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            // List Lejligheds inspektøre
                            query = "SELECT Ejer.Ejerid, Ejer.Ejertype, Person.Fornavn, Person.Efternavn, " +
                                "Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Ejer.Noter " +
                                "FROM Ejer " +
                                "JOIN Person ON Ejer.Personid = Person.Personid " +
                                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                                "WHERE Ejer.Ejertype = 'Lejligheds inspektør' " +
                                "ORDER BY Person.Fornavn";

                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Inspektører Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D5: // 5 - Opsynsmænd
                        case ConsoleKey.NumPad5:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Opsynsmænd";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            // List Opsynsmænd
                            query = "SELECT Opsynsmand.Opsynsmandid, Opsynsmand.Personid, Opsynsmand.Distriktid, Person.Fornavn, Person.Efternavn, " +
                                "Adresse.Adressestring, PostnrBy.Postnr, PostnrBy.Bynavn, Person.Tlf, Person.Email, Opsynsmand.Noter " +
                                "FROM Opsynsmand " +
                                "JOIN Person ON Opsynsmand.Personid = Person.Personid " +
                                "JOIN Adresse ON Person.Adresseid = Adresse.Adresseid " +
                                "JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr " +
                                "WHERE NOT Opsynsmand.Noter = 'Noter: Lejligheds inspektør' OR NOT Opsynsmand.Noter = 'Noter: Test Lejligheds inspektør'" +
                                "ORDER BY Person.Efternavn";

                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Opsynsmænd Lister";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        //case ConsoleKey.D6: //
                        //case ConsoleKey.NumPad6:
                        //    Console.Write("6");
                        //    break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuUdlejningskonsulent()

        
        static public void MenuKundekonsulent(string loginType, string loginEmail, int loginPersonid)
        {
            string[] temparray = new string[] { "", "", "", "" };
            int tmp1 = 0;
            int tmp2 = 0;
            int tmp3 = 0;
            int tmp4 = 0;
            int tmp5 = 0;
            decimal tmp4d = 1.0m;
            string temp1 = "";
            string temp2 = "";
            string temp3 = "";
            string temp4 = "";
            string temp5 = "";
            string temp6 = "";
            string temp7 = "";
            string temp8 = "";
            string temp9 = "";

            string query;
            List<object> selection = new List<object>();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";
            string MainMenuText1 = $"1 - List Feriebolig Reservationer\n2 - Opret Feriebolig Reservation\n3 - Ret Feriebolig Reservation\n4 - Slet Feriebolig Reservation\n\n5 - Administrer Sæsonkategorier\n\nF5 - Afslut";
            string MainMenuText2 = $"1 - List Feriebolig Reservationer\n2 - Opret Feriebolig Reservation\n3 - Ret Feriebolig Reservation\n4 - Slet Feriebolig Reservation\n\n5 - Administrer Sæsonkategorier\n6 - Ændre uge for uge\n\nF5 - Afslut";
            

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 3, 0, hvid, blaaM, sort, true, loginType);
            HeaderWindow.MarginY = 1;
            HeaderWindow.MarginX = 4;

            Window MainMenu = new Window((3 *( 2 * 4)) + 1, consoleHeight - 20, 44, 18, 0, hvid, blaaM, sort, true, "Menu");
            Window SubMenu1 = new Window((2 * (2 * 4)) + 1, consoleHeight - 20 + (1 * 4), 44, 18, 0, hvid, blaaM, sort, true, "SubMenu");
            Window SubMenu2 = new Window((1 * (2 * 4)) + 1, consoleHeight - 20 + (2 * 4), 44, 18, 0, hvid, blaaM, sort, true, "SubMenu");
            Window MainWindow1 = new Window(consoleWidth - 70, consoleHeight - 15, 68, 13, 0, hvid, blaaM, sort, true, "Start Info");
            // Window MainWindow2 = new Window(standardWindowX + 26 + 9, MainMenu.Y - 4, standardWindowWidth - (30 + 9), MainMenu.H, 0, hvid, blaaM, sort, false, "");
            Window MainWindow2 = new Window(consoleWidth - (105 + 4 + 3), MainMenu.Y - 4, 105, MainMenu.H, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow = new Window(1, HeaderWindow.Y + HeaderWindow.H + 1, consoleWidth - 3, consoleHeight - ((HeaderWindow.Y + HeaderWindow.H + 1) + MainWindow2.H + 4 + 3), 0, hvid, blaaM, sort, false, "");

            string EditFrame1Text = "";
            string EditFrame2Text = "";
            string EditFrame3Text = "";
            string EditFrame4Text = "";
            
            Frame EditFrame1 = new Frame(MainWindow2.X, MainWindow2.Y +  4, MainWindow2.W, 6, 0, sort, graa, sort, false);
            Frame EditFrame2 = new Frame(MainWindow2.X, MainWindow2.Y +  6, MainWindow2.W, 6, 0, sort, graa, sort, false);
            Frame EditFrame3 = new Frame(MainWindow2.X, MainWindow2.Y +  8, MainWindow2.W, 6, 0, sort, graa, sort, false);
            Frame EditFrame4 = new Frame(MainWindow2.X, MainWindow2.Y + 10, MainWindow2.W, 6, 0, sort, graa, sort, false);

            // Initialize Data Objects
            // 
            //SaesonkategoriList saesonkalender = new SaesonkategoriList();
            SaesonkategoriList saesonkalender = new SaesonkategoriList(OutputWindow.X, OutputWindow.Y, OutputWindow.W, OutputWindow.H, OutputWindow.TxtColor, OutputWindow.BgColor, OutputWindow.ShadowColor, blaa);
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();

                HeaderWindow.Draw();
                HeaderWindow.Print($"Bruger nr: {loginPersonid}, med email {loginEmail} er logget ind som {loginType}.");

                MainMenu.Draw();
                MainMenu.Print(MainMenuText2);

                MainWindow1Text1 = $"{loginEmail}\n er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);

                OutputWindow.Visible = true;
                OutputWindow.Draw();
                OutputWindow.Print("");

                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: //   1 - List Feriebolig Reservationer
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Feriebolig Reservationer";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            // List Feriebolig Reservationer
                            query = "SELECT * FROM Lejekontrakt";

                            selection = DB.Select(query);
                            OutputWindowText = "";
                            foreach (List<object> tupel in selection)
                            {
                                foreach (object item in tupel)
                                {
                                    OutputWindowText += ($"{item}, ");
                                }
                                OutputWindowText += ("\n");
                            }
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Feriebolig Reservationer Lister";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D2: //   2 - Opret Feriebolig Reservation
                        case ConsoleKey.NumPad2:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Feriebolig Reservationer";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Feriebolig Reservationer Lister";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D3: //   3 - Ret Feriebolig Reservation
                        case ConsoleKey.NumPad3:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Feriebolig Reservationer";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Feriebolig Reservationer Lister";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D4: //   4 - Slet Feriebolig Reservation
                        case ConsoleKey.NumPad4:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Feriebolig Reservationer";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Feriebolig Reservationer Lister";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D5: //  5 - Sæsonkategorier
                        case ConsoleKey.NumPad5:
                            MainWindow2Text1 = "Hvis du vil ændre en sæson kategori skal du først trykke 6, derpå skrive ugenumret for den uge du vil ændre";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Administrer Sæsonkategori";
                            MainMenu.Print(MainMenuText2);
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Sæsonkategori uge for uge";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            // List Sæsonkategori
                            //saesonkalender.DrawKalender(OutputWindow.X, OutputWindow.Y, OutputWindow.W, OutputWindow.H, OutputWindow.TxtColor, OutputWindow.BgColor, OutputWindow.ShadowColor);
                            saesonkalender.DrawKalender();
                            break;

                        case ConsoleKey.D6: //
                        case ConsoleKey.NumPad6:
                            EditFrame1Text = String.Format($"Uge nr: ");
                            EditFrame2Text = String.Format($"Kategori eller Kategroinavn: ");
                            EditFrame3Text = String.Format($"Prismodifikator: ");
                            MainWindow2Text1 = "1. Skriv ugenumret på den uge du vil ændre [1-52] og tryk return.";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Administrer Sæsonkategori";
                            MainMenu.Print(MainMenuText2);
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Sæsonkategori uge for uge";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            // List Sæsonkategori
                            saesonkalender.DrawKalender();
                            EditFrame1.Visible = true;
                            EditFrame2.Visible = true;
                            EditFrame3.Visible = true;
                            EditFrame4.Visible = true;
                            // Select week
                            do
                            {
                                tmp1 = 0;
                                temp1 = "";
                                temp1 = EditFrame1.ReadInput(EditFrame1Text);
                                if (int.TryParse(temp1, out tmp1))
                                {
                                    if (tmp1 > 0 & tmp1 < 53)
                                    {
                                        temp1 = tmp1.ToString();
                                        break;
                                    }
                                }
                            } while (true);
                            saesonkalender.DrawKalenderSelectUge(tmp1);

                            MainWindow2Text1 = $"1.Skriv ugenumret på den uge du vil ændre[1 - 52] og tryk return.\n" +
                                $"Uge { temp1 } ændres:\n" +
                                $"Anfør nu ændringerne, først anførese Kategori[1-4] eller Kategroinavn[Lav, Mellem, Høj, Super]"; // , Prismodifikator[1.0 betyder ingen forandreing]\n Ugenr = {temp1}
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Administrer Sæsonkategori : Kategori eller Kategroinavn";
                            MainMenu.Print(MainMenuText2);
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);

                            do
                            {
                                tmp2 = 0;
                                tmp3 = 0;
                                temp2 = "";
                                temp3 = "";
                                temp2 = EditFrame2.ReadInput(EditFrame2Text);
                                if (int.TryParse(temp2, out tmp2))
                                {
                                    if (tmp2 > 0 & tmp2 < 5)
                                    {
                                        if (tmp2 == 1)
                                        {
                                            tmp2 = 1;
                                            temp3 = "Lav";
                                            break;
                                        }
                                        if (tmp2 == 2)
                                        {
                                            tmp2 = 2;
                                            temp3 = "Mellem";
                                            break;
                                        }
                                        if (tmp2 == 3)
                                        {
                                            tmp2 = 3;
                                            temp3 = "Høj";
                                            break;
                                        }
                                        if (tmp2 == 4)
                                        {
                                            tmp2 = 4;
                                            temp3 = "Super";
                                            break;
                                        }
                                    }
                                }
                                else if (temp2 == "Lav" | temp2 == "Mellem" | temp2 == "Høj" | temp2 == "Super" | temp2 == "lav" | temp2 == "mellem" | temp2 == "høj" | temp2 == "super")
                                {
                                    if (temp2 == "Lav" | temp2 == "lav")
                                    {
                                        tmp2 = 1;
                                        temp3 = "Lav";
                                        break;
                                    }
                                    if (temp2 == "Mellem" |  temp2 == "mellem")
                                    {
                                        tmp2 = 2;
                                        temp3 = "Mellem";
                                        break;
                                    }
                                    if (temp2 == "Høj" | temp2 == "høj")
                                    {
                                        tmp2 = 3;
                                        temp3 = "Høj";
                                        break;
                                    }
                                    if (temp2 == "Super" | temp2 == "super")
                                    {
                                        tmp2 = 4;
                                        temp3 = "Super";
                                        break;
                                    }
                                }
                            } while (true);

                            MainWindow2Text1 = $"1.Skriv ugenumret på den uge du vil ændre[1 - 52] og tryk return.\n" +
                                $"Uge { temp1 } ændres:\n" +
                                $"Anfør nu ændringerne, først anførese Kategori[1-4] eller Kategroinavn[Lav, Mellem, Høj, Super]\n" +
                                $"Kategori ændret til: { tmp2 }\n" +
                                $"Kategroinavn ændres til: { temp3 }\n" +
                                $"Anfør slutteligt ændringer for Prismodifikator. 1.0 er standart for Lav. 2.0 er standart for Super.";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Administrer Sæsonkategori: Prismodifikator";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);

                            do
                            {
                                tmp4d = 0.0m;
                                temp4 = "";
                                temp4 = EditFrame3.ReadInput(EditFrame3Text);
                                // temp4 = String.Format("{0:0.00}", temp4);
                                //if (decimal.TryParse(temp4, out tmp4d))
                                //if (Decimal.TryParse(temp4, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CreateSpecificCulture("da-DK"), out tmp4d))
                                //if (decimal.TryParse(temp4, System.Globalization.NumberStyles.Currency, null, out tmp4d))
                                // CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                                //tmp4d  = decimal.Parse(temp4.Replace("m", ""));
                                //tmp4d *= 0.01m;
                                // if (decimal.TryParse(tmp4d, out tmp4d))
                                // FUCK YOU decimal.TryParse uncultural nemesis sob !!
                                temp5 = temp4.Replace(",", ".");
                                string[] crap = temp5.Split('.');
                                temp4 = "";
                                for(int count = 0; count < crap.Length; count++)
                                {
                                    temp4 +=crap[count];
                                    if (count == 0)
                                        temp4 += ".";
                                    if (crap.Length == 1)
                                        temp4 += "0";
                                    if (count == 1)
                                        break;
                                }
                                if (!string.IsNullOrEmpty(temp4))
                                {
                                    //temp4 = tmp4d.ToString("0.##");
                                    //tmp4d *= 0.01m;
                                    // temp4 = String.Format("{0:0.00}", tmp4d);
                                    break;
                                }
                            } while (true);

                            MainWindow2Text1 = $"Opdatering som følger:\n" +
                                $"Ugeid          : { temp1 }\n" +
                                $"Kategori       : { tmp2 }\n" +
                                $"Kategroinavn   : { temp3 }\n" +
                                $"Prismodifikator: {temp4.Replace(".", ",")}\n\n";
                            //$"Prismodifikator ændret til { tmp4d:0.##}\n";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Administrer Sæsonkategori: Opdateringer";
                            
                            // Update sql

                            query = $"UPDATE Saesonkategori SET " +
                                $"Kategori = {tmp2}, Kategroinavn = '{temp3}', Prismodifikator = {temp4} " +
                                $"WHERE Ugeid = {temp1}";

                            if (DB.Update(query))
                            {
                                MainWindow2Text1 += $" -- Det blev opdateret";
                            }
                            else
                            {
                                MainWindow2Text1 += $"-- Det blev ikke opdateret\n\n - Noget gik galt, du må prøve igen..";
                            }
                            query = "SELECT * FROM Saesonkategori " +
                                $"WHERE Ugeid = {temp1};";

                            selection = DB.Select(query);
                            foreach (List<object> tupel in selection)
                            {
                                saesonkalender.Uge[tmp1-1].UpdateUge(tupel);
                            }
                            OutputWindowText = "";
                            OutputWindow.Print(OutputWindowText);
                            saesonkalender.DrawKalender();
                            saesonkalender.DrawKalenderDeselectUge(tmp1);
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuKundekonsulent()

        static public void MenuEjer(string loginType, String loginEmail, int loginPersonid)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";

            string query;
            List<object> LoginSelection = new List<object>();

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 4, 0, hvid, blaaM, sort, true, loginType);

            Window MainMenu = new Window(1, consoleHeight - 24, 30, 20, 0, hvid, blaaM, sort, true, "Menu");
            Window MainWindow1 = new Window(standardWindowX + standardWindowWidth - 60, standardWindowY + standardWindowHeight - 15, 60, 15, 0, hvid, blaaM, sort, true, "Start Info");
            Window MainWindow2 = new Window(standardWindowX + 12, standardWindowY + standardWindowHeight - 20, standardWindowWidth - 16, standardWindowHeight - 18, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow = new Window(1, 6, consoleWidth - 3, consoleHeight - (6 + 24 + 2), 0, hvid, blaaM, sort, false, "");
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();

                HeaderWindow.Draw();
                HeaderWindow.Print($"Du er logget ind som {loginType}");

                MainMenu.Draw();
                MainMenu.Print($"\n\n\n\n\n\n\n\nF5 - Afslut");

                MainWindow1Text1 = $"{loginEmail} er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);



                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: // 1 - Somerhus Ejere
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Somerhus Ejere";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Somerhus Ejere Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D: // D
                            Console.Write("D");
                            break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuEjer()

        static public void MenuOpsynsmand(string loginType, String loginEmail, int loginPersonid)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";

            string query;
            List<object> selection = new List<object>();

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 4, 0, hvid, blaaM, sort, true, loginType);

            Window MainMenu = new Window(1, consoleHeight - 24, 30, 20, 0, hvid, blaaM, sort, true, "Menu");
            Window MainWindow1 = new Window(standardWindowX + standardWindowWidth - 60, standardWindowY + standardWindowHeight - 15, 60, 15, 0, hvid, blaaM, sort, true, "Start Info");
            Window MainWindow2 = new Window(standardWindowX + 12, standardWindowY + standardWindowHeight - 20, standardWindowWidth - 16, standardWindowHeight - 18, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow = new Window(1, 6, consoleWidth - 3, consoleHeight - (6 + 24 + 2), 0, hvid, blaaM, sort, false, "");
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();

                HeaderWindow.Draw();
                HeaderWindow.Print($"Du er logget ind som {loginType}");

                MainMenu.Draw();
                MainMenu.Print($"\n\n\n\n\n\n\n\nF5 - Afslut");

                MainWindow1Text1 = $"{loginEmail} er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);



                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: // 1 - Somerhus Ejere
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Somerhus Ejere";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Somerhus Ejere Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D2: //
                        case ConsoleKey.NumPad2:
                            Console.Write("2");
                            break;

                        case ConsoleKey.D3: // 
                        case ConsoleKey.NumPad3:
                            Console.Write("3");
                            break;

                        case ConsoleKey.D4: //    
                        case ConsoleKey.NumPad4:
                            Console.Write("4");
                            break;

                        case ConsoleKey.D5: // 
                        case ConsoleKey.NumPad5:
                            Console.Write("5");
                            break;

                        case ConsoleKey.D6: //
                        case ConsoleKey.NumPad6:
                            Console.Write("6");
                            break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuOpsynsmand()

        static public void MenuInspektor(string loginType, String loginEmail, int loginPersonid)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";

            string query;
            List<object> Selection = new List<object>();

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 4, 0, hvid, blaaM, sort, true, loginType);

            Window MainMenu = new Window(1, consoleHeight - 24, 30, 20, 0, hvid, blaaM, sort, true, "Menu");
            Window MainWindow1 = new Window(standardWindowX + standardWindowWidth - 60, standardWindowY + standardWindowHeight - 15, 60, 15, 0, hvid, blaaM, sort, true, "Start Info");
            Window MainWindow2 = new Window(standardWindowX + 12, standardWindowY + standardWindowHeight - 20, standardWindowWidth - 16, standardWindowHeight - 18, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow = new Window(1, 6, consoleWidth - 3, consoleHeight - (6 + 24 + 2), 0, hvid, blaaM, sort, false, "");
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();

                HeaderWindow.Draw();
                HeaderWindow.Print($"Du er logget ind som {loginType}");

                MainMenu.Draw();
                MainMenu.Print($"\n\n\n\n\n\n\n\nF5 - Afslut");

                MainWindow1Text1 = $"{loginEmail} er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);



                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: // 1 - Somerhus Ejere
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Somerhus Ejere";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Somerhus Ejere Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D2: //
                        case ConsoleKey.NumPad2:
                            Console.Write("2");
                            break;

                        case ConsoleKey.D3: // 
                        case ConsoleKey.NumPad3:
                            Console.Write("3");
                            break;

                        case ConsoleKey.D4: //    
                        case ConsoleKey.NumPad4:
                            Console.Write("4");
                            break;

                        case ConsoleKey.D5: // 
                        case ConsoleKey.NumPad5:
                            Console.Write("5");
                            break;

                        case ConsoleKey.D6: //
                        case ConsoleKey.NumPad6:
                            Console.Write("6");
                            break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuInspektor()

        static public void MenuKunde(string loginType, String loginEmail, int loginPersonid)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = consoleWidth - (standardWindowX + 3);
            int standardWindowHeight = consoleHeight - (standardWindowY + 3);

            string MainWindow1Text1;
            string MainWindow2Text1 = "";
            string OutputWindowText = "";

            string query;
            List<object> Selection = new List<object>();

            Window HeaderWindow = new Window(1, 1, consoleWidth - 3, 4, 0, hvid, blaaM, sort, true, loginType);

            Window MainMenu = new Window(1, consoleHeight - 24, 30, 20, 0, hvid, blaaM, sort, true, "Menu");
            Window MainWindow1 = new Window(standardWindowX + standardWindowWidth - 60, standardWindowY + standardWindowHeight - 15, 60, 15, 0, hvid, blaaM, sort, true, "Start Info");
            Window MainWindow2 = new Window(standardWindowX + 12, standardWindowY + standardWindowHeight - 20, standardWindowWidth - 16, standardWindowHeight - 18, 0, hvid, blaaM, sort, false, "");
            Window OutputWindow = new Window(1, 6, consoleWidth - 3, consoleHeight - (6 + 24 + 2), 0, hvid, blaaM, sort, false, "");
            // open main menues
            bool EndOfMenu = false;
            while (!EndOfMenu)
            {
                Console.Clear();

                HeaderWindow.Draw();
                HeaderWindow.Print($"Du er logget ind som {loginType}");

                MainMenu.Draw();
                MainMenu.Print($"\n\n\n\n\n\n\n\nF5 - Afslut");

                MainWindow1Text1 = $"{loginEmail} er logget ind som {loginType}\n\nDu kan vælge imellem funktioner i menuen til venstre. \nVælg den ønskede funktion ved at taste den anførte kanp ud for menupunktet.\n\nDu kan få hjælp på Sydvest-Bo DokuWiki på følgende link\nhttp://wiki.w2k19sql.hq.gollomotors.dk/";
                MainWindow1.Draw();
                MainWindow1.Print(MainWindow1Text1);



                // ReadKey Switch/Case -      Window 5 - From Dec, Bin, Hex
                Boolean EndProgramKeyPressed = false;

                Console.SetCursorPosition(0, 0);
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1: // 1 - Somerhus Ejere
                        case ConsoleKey.NumPad1:
                            MainWindow2Text1 = "";
                            MainWindow2.Visible = true;
                            MainWindow2.Title = "Somerhus Ejere";
                            MainWindow2.Draw();
                            MainWindow2.Print(MainWindow2Text1);
                            OutputWindow.Visible = true;
                            OutputWindow.Title = "Somerhus Ejere Liste";
                            OutputWindow.Draw();
                            OutputWindow.Print("");
                            OutputWindow.Print(OutputWindowText);
                            break;

                        case ConsoleKey.D2: //
                        case ConsoleKey.NumPad2:
                            Console.Write("2");
                            break;

                        case ConsoleKey.D3: // 
                        case ConsoleKey.NumPad3:
                            Console.Write("3");
                            break;

                        case ConsoleKey.D4: //    
                        case ConsoleKey.NumPad4:
                            Console.Write("4");
                            break;

                        case ConsoleKey.D5: // 
                        case ConsoleKey.NumPad5:
                            Console.Write("5");
                            break;

                        case ConsoleKey.D6: //
                        case ConsoleKey.NumPad6:
                            Console.Write("6");
                            break;

                        case ConsoleKey.F5: // [Esc] Exit Key
                            EndProgramKeyPressed = true;
                            EndOfMenu = true;
                            break;

                            //default: //Not known key pressed
                            //    Console.Write("B");
                            //    break;
                    }
                } while (!EndProgramKeyPressed); // End ReadKey Switchcase
            }// End while (EndOfMenu)
        }// END public void MenuKunde()
    }
}
