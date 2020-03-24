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

        public SaesonkategoriList()
        {
            int i = 0;
            string query;
            List<object> selection = new List<object>();
            query = "SELECT * FROM Saesonkategori " +
                "ORDER BY Ugeid;";

            selection = DB.Select(query);
            foreach (List<object> tupel in selection)
            {
                Uge[i] = new Saesonkategori(tupel);
                i++;
            }
        }

        public string FetchUge(int index, int windowRangeX, int windowRangeY, int windowRangeW, int windowRangeH)
        {
            string result = "";
            if (index > 0 & index < 53)
            {
                result = Uge[index - 1].Print();
            }
            return result;
        }

        public void DrawKalender(int Xr, int Yr, int Wr, int Hr, ConsoleColor TxtColor, ConsoleColor BgColor, ConsoleColor ShadowColor)
        {
            // 52 uger = 13 Collumns * 4 rows.
            //  Dirtribute 13 new windowes within Wrange
            int Wn = (Wr - 2) / 13;
            int Hn = (Hr - 2) / 4;
            int spaceLeft = (Wr - 2) % 13;
            //  Initial start (Xrange, Yrange) + (2,2)
            int Xn = Xr + 2 + (spaceLeft / 2);
            int Yn = Yr + 2;
            Window[] kalender = new Window[52];
            int x = Xn;
            int y = Yn;
            int temp = 0;
            string tempString = "";
            for (int i = 1; i < 53; i++)
            {
                // Fetch window content
                // Check if there is a row shift"
                if (i >1 && (i-1) % 13 == 0)
                {
                    x = Xn;
                    y += Hn;
                }
                // Make and out put a new window;
                tempString = "";
                kalender[i - 1] = new Window(
                    x,
                    y,
                    Wn - 2,
                    4,// Hn - 2, 
                    0,
                    TxtColor,
                    BgColor,
                    ShadowColor,
                    true,
                    $"Uge {Uge[i - 1].Ugeid.ToString("#0")}"
                );
                kalender[i - 1].MarginX = 1;
                kalender[i - 1].MarginY = 1;
                kalender[i - 1].Draw();
                temp = Uge[i - 1].KategroiNavn.ToString().Length + String.Format($"{Uge[i - 1].Kategori.ToString()}").Length;
                for (int n = 0; n < Wn - (temp + (kalender[i - 1].MarginX * 2) + 4); n++)
                {
                    tempString += " ";
                }
                kalender[i - 1].Print(
                    Uge[i - 1].KategroiNavn.ToString() + tempString +
                    $"{Uge[i - 1].Kategori.ToString()}" + " " +
                    Uge[i - 1].Prismodifikator.ToString("0.##") + "%");
                // incriment windowd distance
                x += Wn;
            }
        }//END public void DrawKalender(int Xr, int Yr, int Wr, int Hr, ConsoleColor TxtColor, ConsoleColor BgColor, ConsoleColor ShadowColor)

        public void DrawKalenderSelectUge(int uge, int Xr, int Yr, int Wr, int Hr, ConsoleColor TxtColor, ConsoleColor BgColor, ConsoleColor ShadowColor)
        {
            // 52 uger = 13 Collumns * 4 rows.
            //  Dirtribute 13 new windowes within Wrange
            int Wn = (Wr - 2) / 13;
            int Hn = (Hr - 2) / 4;
            int spaceLeft = (Wr - 2) % 13;
            //  Initial start (Xrange, Yrange) + (2,2)
            int Xn = Xr + 2 + (spaceLeft / 2);
            int Yn = Yr + 2;
            Window[] kalender = new Window[52];
            int x = Xn;
            int y = Yn;
            int temp = 0;
            string tempString = "";
            for (int i = 1; i < 53; i++)
            {
                // Fetch window content
                // Check if there is a row shift"
                if (i > 1 && (i - 1) % 13 == 0)
                {
                    x = Xn;
                    y += Hn;
                }
                // Make and out put a new window;
                if (uge == i)
                { 
                    tempString = "";
                    kalender[i - 1] = new Window(
                        x,
                        y,
                        Wn - 2,
                        4,// Hn - 2, 
                        0,
                        TxtColor,
                        BgColor,
                        ShadowColor,
                        true,
                        $"Uge {Uge[i - 1].Ugeid.ToString("#0")}"
                    );
                    kalender[i - 1].MarginX = 1;
                    kalender[i - 1].MarginY = 1;
                
                    kalender[i - 1].Draw();
                    temp = Uge[i - 1].KategroiNavn.ToString().Length + String.Format($"{Uge[i - 1].Kategori.ToString()}").Length;
                    for (int n = 0; n < Wn - (temp + (kalender[i - 1].MarginX * 2) + 4); n++)
                    {
                        tempString += " ";
                    }
                    kalender[i - 1].Print(
                        Uge[i - 1].KategroiNavn.ToString() + tempString +
                        $"{Uge[i - 1].Kategori.ToString()}" + " " +
                        Uge[i - 1].Prismodifikator.ToString("0.##") + "%");
                    // incriment windowd distance
                    x += Wn;
                }
            }
        }//END public void DrawKalender(int Xr, int Yr, int Wr, int Hr, ConsoleColor TxtColor, ConsoleColor BgColor, ConsoleColor ShadowColor)
    }// End public class SaesonkategoriList

}//END namespace
