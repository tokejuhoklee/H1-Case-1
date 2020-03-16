﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Frame
    {
        public const string _solid = " ";
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; } // Width
        public int H { get; set; } // Heigth
        public int Z { get; set; } // Z index
        public int Margin { get; set; } = 2; // margin default
        public ConsoleColor TxtColor { get; set; }
        public ConsoleColor BgColor { get; set; }
        public ConsoleColor ShadowColor { get; set; }
        public bool Visible { get; set; }

        public Frame() : this(0) { }
        public Frame(int x) : this(x, 0) { }
        public Frame(int x, int y) : this(x, y, 10) { }
        public Frame(int x, int y, int w) : this(x, y, w, 10){ }
        public Frame(int x, int y, int w, int h) : this(x, y, w, h, 0){ }
        public Frame(int x, int y, int w, int h, int z) : this(x, y, w, h, z, ConsoleColor.White) { }
        public Frame(int x, int y, int w, int h, int z, ConsoleColor txtColor) : this(x, y, w, h, z, txtColor, ConsoleColor.Blue) { }
        public Frame(int x, int y, int w, int h, int z, ConsoleColor txtColor, ConsoleColor bgColor) : this(x, y, w, h, z, txtColor, bgColor, ConsoleColor.Black) { }
        public Frame(int x, int y, int w, int h, int z, ConsoleColor txtColor, ConsoleColor bgColor, ConsoleColor shadowColor) : this(x, y, w, h, z, txtColor, bgColor, ConsoleColor.Black, true) { }
        public Frame(int x, int y, int w, int h, int z, ConsoleColor txtColor, ConsoleColor bgColor, ConsoleColor shadowColor, bool visible)
        { 
            X = x;
            Y = y;
            W = w;
            H = h;
            Z = z;
            TxtColor = txtColor;
            BgColor = bgColor;
            ShadowColor = shadowColor;
            Visible = visible;
            if (Visible) this.Print("");
        }

        public virtual void Print(string textblob)
        {
            // Draws the the inside of the regtangle - the margins

            // Store the current condition of the cursor: location and colors
            ConsoleColor _storedForegroundColor = Console.ForegroundColor;
            ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
            int _storedCursorX = Console.CursorLeft;
            int _storedCursorY = Console.CursorTop;
            
            //
            Console.ForegroundColor = TxtColor;
            Console.BackgroundColor = BgColor;
            // lineWidth defineds as how many chars there should be in a line.
            int lineWidth = W - (2 * Margin);
            /* emptyLine, a string with length lineWidth full of spaces. Out-
             * put this line whit a background color draws the frame content
             * of a null string we get, when we split on \n. */
            string emptyLine = "";
            for (int m = 0; m < lineWidth; m++)
                emptyLine += _solid;
            /* break up the textblob at newline chars. This gives us the
             * paragraphs of the textblob. If thise are Null we replace null
             * with the emptyLine */
            StringBuilder newLine = new StringBuilder();
            string[] paragraphs = textblob.Split('\n');
            string[] words;
            int i, j;
            int linecounter = 0;
            foreach (string paragraph in paragraphs)
            {
                i =  0; // reset counter
                if (paragraph == null) //empty line
                {
                    newLine.AppendLine(emptyLine);
                    linecounter++;
                }
                else // ther is some text in this paragraph
                {
                    words = textblob.Split(' ');
                    foreach (string word in words)
                    {
                        if (!String.IsNullOrEmpty(word)) // this is something
                        {
                            j = word.Length;
                            if (i + j + 1 <= lineWidth) // ther is room for it
                            {
                                if (i == 0) // beginning of the line, no space
                                {
                                    newLine.Append(word);
                                    i += j;
                                }
                                else // insert a space char and count it too
                                {
                                    newLine.Append($" {word}");
                                    i += j + 1;
                                }
                            }
                            else // No room for it, fill the line with spaces
                            {
                                newLine.Append(' ', lineWidth - i);
                                i = 0; // reset counter
                                linecounter++;
                                newLine.AppendLine(); // and a new line
                            }
                        }
                    }// End of words in this paragraph.
                    if ( i < lineWidth) // file this line with spaces
                    {
                        newLine.Append(' ', lineWidth - i);
                        if (linecounter < H)
                        {
                            linecounter++;
                            newLine.AppendLine(); // and a new line
                        }
                        
                    }
                }
            }// end of paragraphs
            while (linecounter < H)
            {
                newLine.AppendLine(emptyLine);
                linecounter++;
            }
            newLine.Append(emptyLine); // End the StringBuilder blob w/o a
            // newline char

            textblob = newLine.ToString(); // convert to string
            paragraphs = textblob.Split('\n');

            // Generate a horizontal line the size of width of the frame 

            for (int n = 0; n <= H - (2 * Margin); n++)
            {
                Console.SetCursorPosition(X + Margin, (Y + Margin + n));

                Console.Write(paragraphs[n]);
            }
            // return cursor to its posistion
            Console.ForegroundColor = _storedForegroundColor;
            Console.BackgroundColor = _storedBackgroundColor;
            Console.CursorLeft = _storedCursorX;
            Console.CursorTop = _storedCursorY;
        }

    } // public class Frame

    public class Window : Frame
    {
        // Const for window frames
        protected const string _cornerX1Y1 = "╔";
        protected const string _cornerX2Y1 = "╗";
        protected const string _cornerX1Y2 = "╚";
        protected const string _cornerX2Y2 = "╝";
        protected const string _linjeX = "═";
        protected const string _linjeXminus3 = "╣";
        protected const string _linjeXminus2 = "¤";
        protected const string _linjeXminus1 = "╠";
        protected const string _linjeY = "║";
        protected const string _shadow = " ";
        // protected const string _shadowCornerX2Y1 = " ";
        // protected const string _shadowCornerX1Y2 = " ";

        private string _header;

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        //public override void Draw()
        public void Draw()
        {
            ConsoleColor _storedForegroundColor = Console.ForegroundColor;
            ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
            int _storedCursorX = Console.CursorLeft;
            int _storedCursorY = Console.CursorTop;
            Console.ForegroundColor = TxtColor;
            Console.BackgroundColor = BgColor;
            string line;
            for (int n = Y; n < (Y + H); n++)
            {
                line = "";
                Console.SetCursorPosition(X, n);
                for (int m = X; m < (X + W - 2); m++)
                {
                    line += _solid;
                }
                Console.Write(line);
                if (n > Y) // shadow vertical
                {
                    Console.BackgroundColor = ShadowColor;
                    Console.Write(_solid);
                    Console.Write(_solid);
                    Console.BackgroundColor = BgColor;
                }
            }
            Console.SetCursorPosition(X + 2, Y + H);
            line = "";
            Console.BackgroundColor = ShadowColor;
            for (int m = X + 2; m < (X + W); m++)
            {
                line += _solid;
            }
            Console.Write(line);
            // return cursor to its posistion
            Console.ForegroundColor = _storedForegroundColor;
            Console.BackgroundColor = _storedBackgroundColor;
            Console.SetCursorPosition(_storedCursorX, _storedCursorY);
        }

    }//END public class Window
}