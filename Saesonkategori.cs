using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sydvest_bo
{
    public class Saesonkategori
    {
        public int Ugeid { get; set; }
        public int Kategori { get; set; }
        public string KategroiNavn { get; set; }
        public decimal Prismodifikator { get; set; }

        public Saesonkategori(int ugeid, int kategori, string kategroiNavn, decimal prismodifikator)
        {
            Ugeid = ugeid;
            Kategori = kategori;
            KategroiNavn = kategroiNavn;
            Prismodifikator = prismodifikator;
        }

        public Saesonkategori(List<object> tupel)
        {
            int i = 0;
            foreach (object item in tupel)
            {
                switch (i)
                {
                    case 0:
                        Ugeid = (int)item;
                        break;
                    case 1:
                        Kategori = (int)item;
                        break;
                    case 2:
                        KategroiNavn = (string)item;
                        break;
                    case 3:
                        Prismodifikator = (decimal)item;
                        break;
                }
                i++;
            }
        }

        public void UpdateUge(List<object> tupel)
        {
            int i = 0;
            foreach (object item in tupel)
            {
                switch (i)
                {
                    case 0:
                        Ugeid = (int)item;
                        break;
                    case 1:
                        Kategori = (int)item;
                        break;
                    case 2:
                        KategroiNavn = (string)item;
                        break;
                    case 3:
                        Prismodifikator = (decimal)item;
                        break;
                }
                i++;
            }
        }

        public string Print()
        {
            string result = "";
            result += $"Uge {Ugeid.ToString("#0")}\n";
            result += $"Kategori {Kategori.ToString()}\n";
            result += $" {KategroiNavn.ToString()}\n";
            result += $"% {Prismodifikator.ToString("0.##")}\n";
            return result;
        }
        public string[] GetArray()
        {
            string[] result = new string[4];
            result[0] = $"Uge {Ugeid.ToString("#0")}";
            result[1] = $"Kategori {Kategori.ToString()}\n";
            result[2] = $" {KategroiNavn.ToString()}\n";
            result[3] = $"% {Prismodifikator.ToString("0.##")}\n";
            return result;
        }
    }// END public class Saesonkategori
    public class SaesonkategoriList
    {
        public Saesonkategori[] Uge { get; set; } = new Saesonkategori[52];

        public Window[] Kalender = new Window[52];

        public int SelectUge { get; set; } = 0;
        // SelectUge = 0 ( Nothing selected )
        // SelectUge = [1-52] ( A weeke is selected, this way only one kan be selected at the time )

        public ConsoleColor TxtColor { get; set; } = ConsoleColor.White;
        public ConsoleColor BgColor { get; set; } = ConsoleColor.DarkBlue;
        public ConsoleColor ShadowColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor HighlightedColor{ get; set; } = ConsoleColor.Blue;


        public SaesonkategoriList()
        {
            SelectUge = 0;
            string query;
            List<object> selection = new List<object>();
            query = "SELECT * FROM Saesonkategori " +
                "ORDER BY Ugeid;";

            selection = DB.Select(query);
            foreach (List<object> tupel in selection)
            {
                Uge[SelectUge] = new Saesonkategori(tupel);
                SelectUge++;
            }
            SelectUge = 0;
        }

        public SaesonkategoriList(int Xr, int Yr, int Wr, int Hr, ConsoleColor txtColor, ConsoleColor bgColor, ConsoleColor shadowColor, ConsoleColor highlightedColor)
        {
            // Initialize Uge[] from database
            SelectUge = 0;
            string query;
            List<object> selection = new List<object>();
            query = "SELECT * FROM Saesonkategori " +
                "ORDER BY Ugeid;";

            selection = DB.Select(query);
            foreach (List<object> tupel in selection)
            {
                Uge[SelectUge] = new Saesonkategori(tupel);
                SelectUge++;
            }
            SelectUge = 0;
            // Initialize Kalender Winduer

            TxtColor = txtColor;
            BgColor = bgColor;
            ShadowColor = shadowColor;
            HighlightedColor = highlightedColor;

            // Windows positioning
            // 52 uger = 13 Collumns * 4 rows.
            //  Dirtribute 13 new windowes within Wrange
            int Wn = (Wr - 2) / 13;
            int Hn = (Hr - 2) / 4;
            int spaceLeft = (Wr - 2) % 13;
            //  Initial start (Xrange, Yrange) + (2,2)
            int Xn = Xr + 2 + (spaceLeft / 2);
            int Yn = Yr + 2;
            int x = Xn;
            int y = Yn;
            for (SelectUge = 1; SelectUge < 53; SelectUge++)
            {
                // Check if there is a row shift"
                if (SelectUge > 1 && (SelectUge - 1) % 13 == 0)
                {
                    x = Xn;
                    y += Hn;
                }
                // Make and out put a new window;
                Kalender[SelectUge - 1] = new Window(
                    x,
                    y,
                    Wn - 2,
                    4,// Hn - 2, 
                    0,
                    TxtColor,
                    BgColor,
                    ShadowColor,
                    false,
                    $"Uge {String.Format("{0,2}", Uge[SelectUge - 1].Ugeid.ToString())}"
                );
                Kalender[SelectUge - 1].MarginX = 1;
                Kalender[SelectUge - 1].MarginY = 1;
                // incriment windowd distance
                x += Wn;
            }
            SelectUge = 0;
        }

        //public void UpdateKalender()
        //{
        //    // 
        //    if (SelectUge != 0)
        //    {

        //    }
            
        //    SelectUge = 0;
        //}

        public string FetchUge(int index, int windowRangeX, int windowRangeY, int windowRangeW, int windowRangeH)
        {
            string result = "";
            if (index > 0 & index < 53)
            {
                result = Uge[index - 1].Print();
            }
            return result;
        }

        public void DrawKalender()
        {
            string temp;
            int tmp;
            for (int i = 1; i < 53; i++)
            {
                tmp = 0;
                temp = "";
                Kalender[i - 1].Visible = true;
                Kalender[i - 1].Draw();
                tmp += Uge[i - 1].KategroiNavn.ToString().Length + String.Format($"{Uge[i - 1].Kategori.ToString()}").Length;
                for (int n = 0; n < Kalender[i - 1].W - (tmp + (Kalender[i - 1].MarginX * 2) + 4); n++)
                {
                    temp += " ";
                }
                Kalender[i - 1].Print(
                    Uge[i - 1].KategroiNavn.ToString() + temp +
                    $"{Uge[i - 1].Kategori.ToString()}" + " " +
                    Uge[i - 1].Prismodifikator.ToString("0.##") + "%");
            }
        }//END public void DrawKalender()

        public void DrawKalenderSelectUge(int uge)
        {
            string temp;
            int tmp;
            SelectUge = uge;

            Kalender[SelectUge - 1].BgColor = HighlightedColor;

            tmp = 0;
            temp = "";
            Kalender[SelectUge - 1].Visible = true;
            Kalender[SelectUge - 1].Draw();
            tmp += Uge[SelectUge - 1].KategroiNavn.ToString().Length + String.Format($"{Uge[SelectUge - 1].Kategori.ToString()}").Length;
            for (int n = 0; n < Kalender[SelectUge - 1].W - (tmp + (Kalender[SelectUge - 1].MarginX * 2) + 4); n++)
            {
                temp += " ";
            }
            Kalender[SelectUge - 1].Print(
                Uge[SelectUge - 1].KategroiNavn.ToString() + temp +
                $"{Uge[SelectUge - 1].Kategori.ToString()}" + " " +
                Uge[SelectUge - 1].Prismodifikator.ToString("0.##") + "%");
            SelectUge = uge;
        }//END public void DrawKalenderSelectUge(int uge)

        public void DrawKalenderDeselectUge(int uge)
        {
            string temp;
            int tmp;
            SelectUge = uge;

            Kalender[SelectUge - 1].BgColor = BgColor;

            tmp = 0;
            temp = "";
            Kalender[SelectUge - 1].Visible = true;
            Kalender[SelectUge - 1].Draw();
            tmp += Uge[SelectUge - 1].KategroiNavn.ToString().Length + String.Format($"{Uge[SelectUge - 1].Kategori.ToString()}").Length;
            for (int n = 0; n < Kalender[SelectUge - 1].W - (tmp + (Kalender[SelectUge - 1].MarginX * 2) + 4); n++)
            {
                temp += " ";
            }
            Kalender[SelectUge - 1].Print(
                Uge[SelectUge - 1].KategroiNavn.ToString() + temp +
                $"{Uge[SelectUge - 1].Kategori.ToString()}" + " " +
                Uge[SelectUge - 1].Prismodifikator.ToString("0.##") + "%");
            SelectUge = 0;
        }// public void DrawKalenderDeselectUge(int uge)
    }// End public class SaesonkategoriList

}//END namespace
