using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;// console screen controle
using System.Threading.Tasks;
using System.Runtime.InteropServices;// console screen controle
using System.IO;// console screen controle, file I/O
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

        static void Main(string[] args)
        {
            // init windows size
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            // Determine common values for windows sizes and positioning
            int currentConsoleWindowWidth = Console.WindowWidth;
            int currentConsoleWindowHeight = Console.WindowHeight;

            int standardWindowX = 25;
            int standardWindowY = 25;
            int standardWindowWidth = currentConsoleWindowWidth - (standardWindowX + 3);
            int standardWindowHeight = currentConsoleWindowHeight - (standardWindowY + 3);

            // Color abbreviation
            ConsoleColor blaaM = ConsoleColor.DarkBlue;
            ConsoleColor blaa = ConsoleColor.Blue;
            ConsoleColor cyanM = ConsoleColor.DarkCyan;
            ConsoleColor cyan = ConsoleColor.Cyan;
            ConsoleColor groenM = ConsoleColor.DarkGreen;
            ConsoleColor groen = ConsoleColor.Green;
            ConsoleColor gulM = ConsoleColor.DarkYellow;
            ConsoleColor gul = ConsoleColor.Yellow;
            ConsoleColor roedM = ConsoleColor.DarkRed;
            ConsoleColor roed = ConsoleColor.Red;
            ConsoleColor magentaM = ConsoleColor.DarkMagenta;
            ConsoleColor Magenta = ConsoleColor.Magenta;
            ConsoleColor sort = ConsoleColor.Black;
            ConsoleColor graaM = ConsoleColor.DarkGray;
            ConsoleColor graa = ConsoleColor.Gray;
            ConsoleColor hvid = ConsoleColor.White;

            // Call Test environment : TestProgram.Test()

            TestProgram.Test();
            // StaticClassSQL loginTest = new StaticClassSQL();

            // Return from Test environment

            // Sample Text
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tellus velit, aliquam quis eros vel, malesuada bibendum mi. Mauris non ultricies mauris, at accumsan tellus. Etiam tincidunt venenatis nisl in molestie.Nunc quis.";

            string loginWindowText1Welcome = String.Format($"Velkommen til Sydvest-Bo\n\nDu skal logge ind for at kunne bruge programmet.\n\nEt blankt password vil afslutte programmet.");
            string loginWindowText2user = String.Format($"Brugernavn :");
            string loginWindowText3password = String.Format($"Password   :");
            
            Window LoginWindow = new Window(standardWindowX, standardWindowY, 50, 24, 0, hvid, graaM, sort, false, "Login");
            Frame LoginWindow1user = new Frame(standardWindowX, standardWindowY + 8, LoginWindow.W, 6, 0, sort, graa, sort, false);
            Frame LoginWindow2password = new Frame(standardWindowX, standardWindowY + 10, LoginWindow.W, 6, 0, sort, graa, sort, false);
            LoginWindow.Visible = true;
            LoginWindow1user.Visible = true;
            LoginWindow2password.Visible = true;
            LoginWindow.Draw();
            LoginWindow.Print(loginWindowText1Welcome);

            // LoginWindow1user.Print(loginWindowText2user);
            bool userValidated = false;
            string username = LoginWindow1user.ReadInput(loginWindowText2user);
            string password = LoginWindow2password.ReadInput(loginWindowText3password);

            // validat user: Get user type
            if (username != "" || password != "")
            {
                userValidated = true;
            }
            
            while (userValidated)
            {
                Window MainHead = new Window(1, 1, currentConsoleWindowWidth - 3, 4, 0, hvid, blaaM, sort, true, "Main Head");
                MainHead.Draw();
                MainHead.Print("");

                Window MainMenu = new Window(1, 6, 25, currentConsoleWindowHeight - 8, 0, hvid, blaaM, sort, true, "Menu");
                MainMenu.Draw();
                MainMenu.Print("");

                Window MainWindow = new Window(standardWindowX + 27, standardWindowY + 4, standardWindowWidth - (27 + 4), standardWindowHeight - (4 + 4), 0, hvid, blaaM, sort, true, "Hoved Vindue");
                string mainWindowText1 = String.Format($"Du er nu logget ind {username} og kan bruge programmet\n\nPisse fedt for det afsluttes nu, hvis du trykker på en tast.");
                MainWindow.Draw();
                MainWindow.Print(mainWindowText1);

                Console.ReadKey(true);
                userValidated = false;
            }// End while (userValidated)  *********** user loged out
             // exit program propperly : cloes files ect.

            // calling testProgram calss
        }//END static void Main(string[] args)
    }
}
