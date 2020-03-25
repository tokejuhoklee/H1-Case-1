using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Frame
    {
        protected const int _sLX = 2; // _shadowLengthX
        protected const int _sLY = 1; // _shadowLengthY
        protected const string _solid = " ";
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; } // Width
        public int H { get; set; } // Heigth
        public int Z { get; set; } // Z index
        protected int _marginX;
        protected int _marginY;

        public int Margin
        {
            get { return _marginY; }
            set
            { 
                _marginY = value;
                _marginX = 2 * value;
            }
        }

        public int MarginX
        {
            get { return _marginX; }
            set { _marginX = value; }
        }

        public int MarginY
        {
            get { return _marginY; }
            set { _marginY = value; }
        }

        //public int _marginY { get; set; } = 1; // margin default
        //public int _marginX { get; set; } = 2; // margin default
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
            Margin = 2;
            // if (Visible) this.Print("");
        }

        public virtual void Print(string textblob)
        {
            /* Print the inside of a regtangular frame together with some
             * text content if pressent ther also will be formatet to fit it */

            // if the frame is Visible draw it, else dont
            if (Visible)
            {
                // Store the current condition of the cursor: location and colors
                ConsoleColor _storedForegroundColor = Console.ForegroundColor;
                ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
                int _storedCursorX = Console.CursorLeft;
                int _storedCursorY = Console.CursorTop;

                //
                Console.ForegroundColor = TxtColor;
                Console.BackgroundColor = BgColor;
                // lineWidth defineds as how many chars there should be in a line.
                // Wide of the frame W - (2_margin + _shadowLengthX + 2vertical_lines)
                int lineWidth = W - ((2 * _marginX) + _sLX);
                /* emptyLine, a string with length lineWidth full of spaces. Out-
                 * put this line whit a background color draws the frame content
                 * of a null string we get, when we split on \n. */
                string emptyLine = "";
                for (int m = 0; m < lineWidth; m++)
                    emptyLine += _solid;
                /* break up the textblob at newline chars. This gives us the
                 * paragraphs of the textblob. If thise are Null we replace null
                 * with the emptyLine */
                StringBuilder newBlob = new StringBuilder();
                string[] paragraphs = textblob.Split('\n');
                for (int t = 0; t < paragraphs.Length; t++)
                {
                    paragraphs[t] = paragraphs[t].Replace("\n", "").Replace("\r", "").Replace("\r\n", "");
                }
                /* to handle tab \t - not jet fontional */
                //for (int t = 0; t < paragraphs.Length; t++)
                //{
                //    paragraphs[t] = paragraphs[t].Replace("\t", "    ");
                //}
                string[] words = { };
                int i, j = 0;
                int linecounter = 0;
                foreach (string paragraph in paragraphs)
                {

                    if (paragraph == null) //empty line
                    {
                        newBlob.AppendLine(emptyLine);
                        i = lineWidth;
                        linecounter++;
                    }
                    else // there is some text in this paragraph
                    {
                        i = 0; // reset counter
                        words = paragraph.Split(' ');
                        foreach (string word in words)
                        {
                            //if (!String.IsNullOrEmpty(word)) // this is something
                            //{
                            j = word.Length;
                            if (i + j + 1 <= lineWidth) // ther is room for it
                            {
                                if (i == 0) // beginning of the line, no space
                                {
                                    newBlob.Append(word);
                                    i += j;
                                }
                                else // insert a space char and count it too
                                {
                                    newBlob.Append(String.Format($" {word}"));
                                    i += j + 1;
                                }
                            }
                            // No room for it, fill the line with spaces and
                            // newline
                            else
                            {
                                newBlob.Append(' ', (lineWidth - i));
                                i = 0; // reset counter
                                linecounter++;
                                newBlob.AppendLine(); // and a new line
                                newBlob.Append(word);
                                i = j;
                            }
                            //}
                        }// End of words in this paragraph.

                        if (i <= lineWidth) // file this line with spaces
                        {
                            newBlob.Append(' ', lineWidth - i);
                            i = 0;
                            if (linecounter <= (H - ((2 * _marginY) + _sLY))) // changed < to <= w/o realy checking it
                            {
                                linecounter++;
                                newBlob.AppendLine(); // and a new line
                            }
                        }
                    }
                }// end of paragraphs
                 // Add extra line to fill the frame;
                while (linecounter <= (H - ((2 * _marginY) + _sLY))) // changed < to <= w/o realy checking it
                {
                    newBlob.AppendLine(emptyLine);
                    linecounter++;
                }
                // End the StringBuilder blob w/o a newline char
                newBlob.Append(emptyLine);

                // convert the stringbuilder object to string
                textblob = newBlob.ToString();

                // convert the stringbuilder object to string
                string[] formatedLines = textblob.Split('\n');

                // Print horizontal lines the size of width of the frame 
                for (int n = 0; n <= (H - ((2 * _marginY) + _sLY)); n++) // changed < to <= w/o realy checking it
                {
                    // removes extra auto implanted occurense of newlines reminisenses
                    formatedLines[n] = formatedLines[n].Replace("\r", "").Replace("\r\n", "");
                    Console.SetCursorPosition(X + _marginX, (Y + _marginY + n));
                    Console.Write(formatedLines[n]);
                }

                // return cursor to its posistion
                Console.ForegroundColor = _storedForegroundColor;
                Console.BackgroundColor = _storedBackgroundColor;
                Console.CursorLeft = _storedCursorX;
                Console.CursorTop = _storedCursorY;
            }// END if (Visible)
        }// END method: public virtual void Print(string textblob)
        
        public virtual string ReadInput(string textblob)
        {
            /* Print the inside of a regtangular frame together with some
             * text content if pressent ther also will be formatet to fit it.
             * Then Present the user with a propt to type in and return his input */
            string _readInput = "";
            int endOfTextblobLocationX = X + _marginX;
            int endOfTextblobLocationY = Y + _marginY;
            // if the frame is Visible draw it, else dont
            if (Visible)
            {
                // Store the current condition of the cursor: location and colors
                ConsoleColor _storedForegroundColor = Console.ForegroundColor;
                ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
                int _storedCursorX = Console.CursorLeft;
                int _storedCursorY = Console.CursorTop;

                //
                Console.ForegroundColor = TxtColor;
                Console.BackgroundColor = BgColor;
                
                // lineWidth defineds as how many chars there should be in a line.
                // Wide of the frame W - (2_margin + _shadowLengthX + 2vertical_lines)
                int lineWidth = W - ((2 * _marginX) + _sLX);
                /* emptyLine, a string with length lineWidth full of spaces. Out-
                 * put this line whit a background color draws the frame content
                 * of a null string we get, when we split on \n. */
                string emptyLine = "";
                for (int m = 0; m < lineWidth; m++)
                    emptyLine += _solid;
                /* break up the textblob at newline chars. This gives us the
                 * paragraphs of the textblob. If thise are Null we replace null
                 * with the emptyLine */
                StringBuilder newBlob = new StringBuilder();
                string[] paragraphs = textblob.Split('\n');
                for (int t = 0; t < paragraphs.Length; t++)
                {
                    paragraphs[t] = paragraphs[t].Replace("\n", "").Replace("\r", "").Replace("\r\n", "");
                }
                /* to handle tab \t - not jet fontional */
                //for (int t = 0; t < paragraphs.Length; t++)
                //{
                //    paragraphs[t] = paragraphs[t].Replace("\t", "    ");
                //}
                string[] words = { };
                int i, j = 0;
                int linecounter = 0;
                foreach (string paragraph in paragraphs)
                {

                    if (paragraph == null) //empty line
                    {
                        newBlob.AppendLine(emptyLine);
                        i = lineWidth;
                        linecounter++;
                    }
                    else // there is some text in this paragraph
                    {
                        i = 0; // reset counter
                        words = paragraph.Split(' ');
                        foreach (string word in words)
                        {
                            //if (!String.IsNullOrEmpty(word)) // this is something
                            //{
                            j = word.Length;
                            if (i + j + 1 <= lineWidth) // ther is room for it
                            {
                                if (i == 0) // beginning of the line, no space
                                {
                                    newBlob.Append(word);
                                    i += j;
                                }
                                else // insert a space char and count it too
                                {
                                    newBlob.Append(String.Format($" {word}"));
                                    i += j + 1;
                                }
                            }
                            // No room for it, fill the line with spaces and
                            // newline
                            else
                            {
                                newBlob.Append(' ', (lineWidth - i));
                                i = 0; // reset counter
                                linecounter++;
                                newBlob.AppendLine(); // and a new line
                                newBlob.Append(word);
                                i = j;
                            }
                            //}
                        }// End of words in this paragraph.

                        if (i <= lineWidth) // file this line with spaces
                        {
                            endOfTextblobLocationX = i;
                            endOfTextblobLocationY = linecounter;
                            newBlob.Append(' ', lineWidth - i);
                            i = 0;
                            if (linecounter < (H - ((2 * _marginY) + _sLY)))
                            {
                                linecounter++;
                                newBlob.AppendLine(); // and a new line
                            }
                        }
                    }
                }// end of paragraphs
                 // Add extra line to fill the frame;
                while (linecounter < (H - ((2 * _marginY) + _sLY)))
                {
                    newBlob.AppendLine(emptyLine);
                    linecounter++;
                }
                // End the StringBuilder blob w/o a newline char
                newBlob.Append(emptyLine);

                // convert the stringbuilder object to string
                textblob = newBlob.ToString();

                // convert the stringbuilder object to string
                string[] formatedLines = textblob.Split('\n');

                // Print horizontal lines the size of width of the frame 
                for (int n = 0; n < (H - ((2 * _marginY) + _sLY)); n++)
                {
                    // removes extra auto implanted occurense of newlines reminisenses
                    formatedLines[n] = formatedLines[n].Replace("\r", "").Replace("\r\n", "");
                    Console.SetCursorPosition(X + _marginX, (Y + _marginY + n));
                    Console.Write(formatedLines[n]);
                }

                // Read the input **************************************************
                Console.SetCursorPosition(X + _marginX + endOfTextblobLocationX, (Y + _marginY + endOfTextblobLocationY));
                _readInput = Console.ReadLine();

                // return cursor to its posistion
                Console.ForegroundColor = _storedForegroundColor;
                Console.BackgroundColor = _storedBackgroundColor;
                Console.CursorLeft = _storedCursorX;
                Console.CursorTop = _storedCursorY;
            }
            return _readInput;
        } // END public virtual string ReadInput(string textblob)
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

        public string Title { get; set; }

        public Window(int x, int y, int w, int h, int z, ConsoleColor txtColor, ConsoleColor bgColor, ConsoleColor shadowColor, bool visible, string title) : base(x, y, w, h, z, txtColor, bgColor, shadowColor, visible)
        {
            Title = title;
        }

        //public override void Draw()
        public void Draw()
        {
            /* Draw the outer frame and marginins of a regtangular windowframe
             * together with a header. */

            // Store the current condition of the cursor: location and colors
            ConsoleColor _storedForegroundColor = Console.ForegroundColor;
            ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
            int _storedCursorX = Console.CursorLeft;
            int _storedCursorY = Console.CursorTop;

            
            // Console.ForegroundColor = TxtColor;
            // Console.BackgroundColor = BgColor;
            
            // Loop vertical distance from top Y to bottom y+H - vertical shadow distance.
            for (int y = Y; y <= Y + H - _sLY; y++)
            {
                // Check if its the 2 topmost or bottommoste lines, then we draw a horizontal frame
                if (y == Y | y == Y + H - _sLY)
                {
                    // Loop horisontal distance from top X to bottom X+W - horizontal shadow distance.
                    for (int x = X; x <= X + W - _sLX; x++)
                    {
                        // color change
                        Console.ForegroundColor = TxtColor;
                        Console.BackgroundColor = BgColor;
                        Console.SetCursorPosition(x, y);

                        // Left Top corner 1, print constant for that (face inside = no shadow)
                        if (x == X & y == Y) { Console.Write(_cornerX1Y1); }
                        // Right Top corner 2, print constant for that and draw shadow
                        else if (x == X + W - _sLX & y == Y)
                        {
                            Console.Write(_cornerX2Y1);
                            // Shadow
                            Console.BackgroundColor = ShadowColor;
                            for (Byte ShadowDept = 1; ShadowDept <= _sLX; ShadowDept++)
                            {
                                Console.SetCursorPosition(x + ShadowDept, y + ShadowDept);
                                Console.Write(_shadow);
                            }
                        }
                        // Left lower corner 3, print constant for that and draw shadow
                        else if (x == X & y == Y + H - _sLY)
                        {
                            Console.Write(_cornerX1Y2);
                            // Shadow
                            Console.BackgroundColor = ShadowColor;
                            for (Byte ShadowDept = 1; ShadowDept <= _sLY; ShadowDept++)
                            {
                                Console.SetCursorPosition(x + ShadowDept, y + ShadowDept);
                                Console.Write(_shadow);
                            }
                        }

                        // Right Lower corner 4, print constant for that and draw shadow
                        else if (x == X + W - _sLX & y == Y + H - _sLY)
                        {
                            Console.Write(_cornerX2Y2);
                            // Shadow
                            Console.BackgroundColor = ShadowColor;
                            for (Byte ShadowDept = 1; ShadowDept <= _sLY; ShadowDept++)
                            {
                                Console.SetCursorPosition(x + ShadowDept, y + ShadowDept);
                                Console.Write(_shadow);
                            }
                        }
                        // top horizontal line
                        else if (y == Y)
                        {
                            // print a mark on the window frame near top right corner
                            if (x == X + W - ( 1 + _sLX))
                                Console.Write(_linjeX);
                            // Console.Write(_linjeXminus2);
                            else // draw horizontal line
                                Console.Write(_linjeX);
                            // Margin
                            for (Byte MarginDept = 1; MarginDept <= _marginY; MarginDept++)
                            {
                                Console.SetCursorPosition(x, y + MarginDept);
                                Console.Write(_solid);
                            }
                        }
                        // Lower horizontal line
                        else if (y == Y + H - _sLY)
                        { // (y == Y2)
                            Console.Write(_linjeX);
                            // Margin
                            for (Byte MarginDept = 1; MarginDept <= _marginY; MarginDept++)
                            {
                                Console.SetCursorPosition(x, y - MarginDept);
                                Console.Write(_solid);
                            }
                            // Shadow
                            Console.BackgroundColor = ShadowColor;
                            for (Byte ShadowDept = 1; ShadowDept <= _sLY; ShadowDept++)
                            {
                                Console.SetCursorPosition(x + ShadowDept, y + ShadowDept);
                                Console.Write(_shadow);
                            }
                        }
                    }
                }// END Check if its the 2 topmost or bottommoste lines, then we draw a horisontal frame
                else
                { // Vertical line S
                    Console.ForegroundColor = TxtColor;
                    Console.BackgroundColor = BgColor;
                    Console.SetCursorPosition(X, y);
                    Console.Write(_linjeY);
                    // Margin
                    for (Byte MarginDept = 1; MarginDept <= _marginX; MarginDept++)
                    {
                        Console.SetCursorPosition(X + MarginDept, y);
                        Console.Write(_solid);
                    }
                    Console.SetCursorPosition(X + W - _sLX, y);
                    Console.Write(_linjeY);
                    for (Byte MarginDept = 1; MarginDept <= _marginX; MarginDept++)
                    {
                        Console.SetCursorPosition(X + W - (_sLX + MarginDept), y);
                        Console.Write(_solid);
                    }
                    // Shadow
                    Console.BackgroundColor = ShadowColor;
                    for (Byte ShadowDept = 1; ShadowDept <= _sLX; ShadowDept++)
                    {
                        Console.SetCursorPosition(X + W - _sLX + ShadowDept, y + ShadowDept);
                        Console.Write(_shadow);
                    }
                }
            }
            // Title
            this.PrintTitle();
            // return cursor to its posistion
            Console.ForegroundColor = _storedForegroundColor;
            Console.BackgroundColor = _storedBackgroundColor;
            Console.CursorLeft = _storedCursorX;
            Console.CursorTop = _storedCursorY;
        }//END public void Draw()

        public void PrintTitle()
        {
            /* Print a windowframe title if pressent. */
            if (!String.IsNullOrEmpty(Title))
            {
                string _txt = Title;
                // Store the current condition of the cursor: location and colors
                ConsoleColor _storedForegroundColor = Console.ForegroundColor;
                ConsoleColor _storedBackgroundColor = Console.BackgroundColor;
                int _storedCursorX = Console.CursorLeft;
                int _storedCursorY = Console.CursorTop;
                Console.ForegroundColor = TxtColor;
                Console.BackgroundColor = BgColor;
                _txt = "- " + _txt + " -";
                //Console.SetCursorPosition(X + ((((W) / 2) - _sLX) - ((_txt.Length / 2) + (_txt.Length % 2))), Y);
                Console.SetCursorPosition(X + ((((W) / 2) - _sLX) - ((_txt.Length / 2) + (_txt.Length % 2))) + 2, Y);
                Console.Write(_txt);
                Console.ForegroundColor = _storedForegroundColor;
                Console.BackgroundColor = _storedBackgroundColor;
                Console.CursorLeft = _storedCursorX;
                Console.CursorTop = _storedCursorY;
            }
        }// public void DrawTitle(string txt)

    }//END public class Window

    public class Screen
    {
        private Queue<object> _windowQueue = new Queue<object>();

        public bool _visible { get; set; } = true;
        public int _elements { get; set; } = 0;

        public Screen()
        {
            _windowQueue.Clear();
            _visible = true;
            _elements = 0;
        }
        public void AddFrame(Frame frame)
        {
            _windowQueue.Enqueue(frame);
            _elements++;
            frame.Z = _elements;
            
        }

        public void AddWindow(Window window)
        {
            _windowQueue.Enqueue(window);
            _elements++;
            window.Z = _elements;
        }

        public void Refresh()
        {
            Console.Clear();
            foreach (object screenElement in _windowQueue)
            {
                if (screenElement is Frame)
                {
                    Frame frame = (Frame)screenElement;
                    if (frame.Visible)
                    {
                        frame.Print("");
                    }
                }
                else if (screenElement is Window)
                {
                    Window window = (Window)screenElement;
                    if (window.Visible)
                    {
                        window.Draw();
                    }
                }
            }
        }// End public void Refresh()
    }// END public class Screen
}
