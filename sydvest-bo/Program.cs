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

            Console.WriteLine();
            string m00 = $"Console_Screen_max_test2\n www.c-sharpcorner.com/code/448/code-to-auto-maximize-console-application-according-to-screen-width-in-c-sharp.aspx";
            string m0 = $"The current window width is {Console.WindowWidth}, and\nthe current window height is {Console.WindowHeight}.";
            var wzx = Console.WindowWidth;
            var wzy = Console.WindowHeight;

            Frame box0 = new Frame(5, 16, 145, 10, 0, ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Black, true);
            Window box1 = new Window(30, 10, 40, 10, 0, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Black, true, "Box1");
            Window box2 = new Window(16, 2, 50, 14, 0, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Black, true, "Box2");
            box1.Draw();
            box1.Print("");
            box0.Print(m00);
            box2.Draw();
            box2.Print(m0);

            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tellus velit, aliquam quis eros vel, malesuada bibendum mi. Mauris non ultricies mauris, at accumsan tellus. Etiam tincidunt venenatis nisl in molestie.Nunc quis.";

            Console.ReadKey(true);
            // Srolle setup
            string m1 = "1) Press the cursor keys to move the console window.\n2) Press any key to begin. When you're finished...\n3) Press the Escape key to quit.";
            string g1 = "+---------";
            string g2 = "|         ";
            //          "| uge: 52 "
            string grid1;
            string grid2;
            string grid3;
            StringBuilder sbG1 = new StringBuilder();
            StringBuilder sbG2 = new StringBuilder();
            StringBuilder sbG3 = new StringBuilder();
            ConsoleKeyInfo cki;

            int y;
            //
            try
            {
                saveBufferWidth = Console.BufferWidth;
                saveBufferHeight = Console.BufferHeight;
                saveWindowHeight = Console.WindowHeight;
                saveWindowWidth = Console.WindowWidth;
                saveCursorVisible = Console.CursorVisible;
                //
                Console.Clear();
                //Console.WriteLine(m1);
                box1.Draw();
                box1.Print(loremIpsum);
                box2.Draw();
                box2.Print(m1);
                Console.ReadKey(true);

                // Set the smallest possible window size before setting the buffer size.
                Console.SetWindowSize(1, 1);
                // Console.SetBufferSize((wzx * 2), wzy * 2);
                Console.SetBufferSize(521, (wzy * 2) + 5);
                Console.SetWindowSize(wzx, wzy);

                // Create grid lines to fit the buffer. (The buffer width is was 80, but
                // this same technique could be used with an arbitrary buffer width.)
                for (y = 0; y < Console.BufferWidth / g1.Length; y++)
                {
                    sbG1.Append(g1);
                    sbG2.Append(g2);
                    sbG3.Append($"| uge: {y+1:d2} ");
                }
                sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
                sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
                sbG3.Append(g2, 0, Console.BufferWidth % g2.Length);
                grid1 = sbG1.ToString();
                grid2 = sbG2.ToString();
                grid3 = sbG3.ToString();

                Console.CursorVisible = false;
                Console.Clear();
                for (y = 0; y < Console.BufferHeight - 1; y++)
                {
                    if (y % 3 == 0)
                        Console.Write(grid1);
                    if (y % 3 == 1)
                        Console.Write(grid3);
                    else
                        Console.Write(grid2);
                }
                box1.X += wzx / 2;
                box1.Y += wzy / 2;
                box2.X += wzx / 2;
                box2.Y += wzy / 2;
                box1.Draw();
                box1.Print(loremIpsum);
                box2.Draw();
                box2.Print(loremIpsum);
                Console.SetWindowPosition(0, 0);
                do
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (Console.WindowLeft > 0)
                            {
                                Console.SetWindowPosition( Console.WindowLeft - 1, Console.WindowTop);
                                //if ((box1.X + box1.W + 2) < (Console.BufferWidth - Console.WindowWidth))
                                //{
                                //    box1.X++;
                                //}
                                //if ((box2.X + box2.W + 2) < (Console.BufferWidth - Console.WindowWidth))
                                //{
                                //    box2.X++;
                                //}
                                //box1.Print(loremIpsum);
                                //box2.Print(loremIpsum);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Console.WindowTop > 0)
                            {
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                                //if ((box1.Y + box1.H + 2) < (Console.BufferHeight - Console.WindowHeight))
                                //{
                                //    box1.Y++;
                                //}
                                //if ((box2.Y + box2.H + 2) < (Console.BufferHeight - Console.WindowHeight))
                                //{
                                //    box2.Y++;
                                //}
                                //box1.Print(loremIpsum);
                                //box2.Print(loremIpsum);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                            {
                                Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                                //if (box1.X > 0)
                                //{
                                //    box1.X--;
                                //}
                                    
                                //if (box2.X > 0)
                                //{
                                //    box2.X--;
                                //}
                                //box1.Print(loremIpsum);
                                //box2.Print(loremIpsum);
                            } 
                            break;
                        case ConsoleKey.DownArrow:
                            if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                            {
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                                //if ( box1.Y > 0)
                                //{
                                //    box1.Y--;
                                //}
                                //if (box2.Y > 0)
                                //{
                                //    box2.Y--;
                                //}
                                //box1.Print(loremIpsum);
                                //box2.Print(loremIpsum);
                            }
                            break;
                    }
                }
                while (cki.Key != ConsoleKey.Escape);  // end do-while
            } // end try
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Clear();
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
                Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
                Console.CursorVisible = saveCursorVisible;
            }

            // Srolle setup end
        }
    }
}
