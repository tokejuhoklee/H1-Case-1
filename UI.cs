using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Case1
{
    class UI
    {

        string[] actionName {get;set;}
        object[] selectionObject{get;set;}
        int selection{get;set;}
        int cursorCoordinateY {get;set;}
        

        public UI(){
            selectionObject=new object[2];
            actionName = new string[3];
            selection=0;
            actionName[0]="Log ind";actionName[1]="test ind";actionName[2]="fuck af";
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;//den røde farve indikerer det valgte emne
            Console.WriteLine(actionName[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 10);

            Console.Write("Du bevæger dig i menuen med ↑-↓ tasterne, og Backspace for at gå tilbage. \nFor at lukke programmet skal du trykke på ESC knappen når du er tilbage i denne menu. ");


            for (int i = 0; i < actionName.Length; i++)//et for loop der udskriver overemnerne i menuen
            {
                Console.WriteLine(actionName[i] + "\t");
                Console.WriteLine();

            }
            Console.SetCursorPosition(0, 0);

            menuKeyWatch();



            
        }
        public void menuKeyWatch(){
            ConsoleKey key;
            do//et do loop der kører indtil at det bliver kastet ud ved brugerens interregering
            {
                while (!Console.KeyAvailable)//do loopet kører "ingenting" så længe der ikke er tastet noget her
                {
                    
                }

                key = Console.ReadKey(true).Key;//lokalvariabel der giver sand hvis der tastes på en knap

                if (key == ConsoleKey.DownArrow && selection < 3)//hvis knappen der bliver tastet er lig med ned piltasten sker denne
                {
                    selection = selection + 1;//selectionet inkrementeres med 1, og er værdien i arrayet når der tastes enter
                    cursorCoordinateY = cursorCoordinateY + 2;//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.SetCursorPosition(0, cursorCoordinateY);//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.ForegroundColor = ConsoleColor.Red;//den røde farve indikere brugerens valg
                    Console.WriteLine(actionName[selection - 1]);//selection-1 er det felt man er går fra og er den værdi i arrayet som stemmer overens med hvad der skal stå


                    Console.SetCursorPosition(0, cursorCoordinateY - 2);//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.ForegroundColor = ConsoleColor.White;//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.WriteLine(actionName[selection - 1]);//her skrives der igen det overemne man lige er går fra, men i hvis så det "hviskes ud"
                    Console.SetCursorPosition(20, cursorCoordinateY);



                }
                else if (key == ConsoleKey.UpArrow && cursorCoordinateY > 0)//hvis knappen der bliver tastet er lig med ned piltasten sker denne
                {
                    selection = selection - 1;//selectionet inkrementeres med 1, og er værdien i arrayet når der tastes enter
                    cursorCoordinateY = cursorCoordinateY - 2;

                    Console.SetCursorPosition(0, cursorCoordinateY);//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.ForegroundColor = ConsoleColor.Red;//den røde farve indikere brugerens valg
                    Console.WriteLine(actionName[selection - 1]);//selection-1 er det felt man er går fra og er den værdi i arrayet som stemmer overens med hvad der skal stå


                    Console.SetCursorPosition(0, cursorCoordinateY + 2);//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.ForegroundColor = ConsoleColor.White;//valgkordinatet inkrementeres med to, og sætter cursorposition, da hver overemne er adskildt med en tom linje
                    Console.WriteLine(actionName[selection]);//her skrives der igen det overemne man lige er går fra, men i hvis så det "hviskes ud"
                    Console.SetCursorPosition(20, cursorCoordinateY);

                }



                else if (key == ConsoleKey.Escape)//hvis knappen der bliver tastet er lig med med escape returnerer der false som stopper loopet, og programmet kan køre videre i main(dvs lukke)
                {
                    this.Equals(null);

                }




            } while (key != ConsoleKey.Enter);//loopet kommer ud ved at taste enter, og selection værdien er så sat til det felt man er på. Det vil så sige at når man kommer ud af loopet fortsætter den til menu der så er valgt, hvorefter denne menu konstruktion gentager sig i en af de andre klasser. 
            selectionObject[selection]=new DBConnectionTest();

        }
    }
}
