using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applikacja2;

namespace syst_zarzad_rest
{
    internal class Rachunek : IOpcje 
    {
        
        public Zamowienie Zamowienie { get; set; }
        public double Kwota { get; set; }
        public DateTime DataWystawienia { get; set; }

        static string[] pozycjeRachunki = { "1. Wyswietl wszystkie rachunki", "2. Zpisz rachunki do pliku", "3. Odczytaj rachunki z pliku", "4. Wroc" };
        static int aktywnaPozycjaMenu = 0;

        //public Rachunek()


       

        public void StartOpcje()
        {
            while (true)
            {
                PokazOpcje();
                WybieranieOpcji();
                UruchomOpcje();
            }
        }

        public void PokazOpcje()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to continue");
            Console.WriteLine();
            for (int i = 0; i < pozycjeRachunki.Length; i++)
            {
                if (i == aktywnaPozycjaMenu)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0, -35}", pozycjeRachunki[i]);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;



                }
                else
                {
                    Console.WriteLine(pozycjeRachunki[i]);
                }
            }
        }

        public void WybieranieOpcji()
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {

                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : pozycjeRachunki.Length - 1;
                    StartOpcje();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {

                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu + 1) % pozycjeRachunki.Length;
                    StartOpcje();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {

                    aktywnaPozycjaMenu = pozycjeRachunki.Length - 1;
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                    break;



            } while (true);
        }

        public void UruchomOpcje()
        {
            switch (aktywnaPozycjaMenu)
            {
                case 0: Console.Clear(); Aplikacja.WyswietlRachunki(); break;
                case 1: Console.Clear(); Aplikacja.WyswietlWszystkieDania(); break;
                case 2: Console.Clear(); Aplikacja.WyswietlWszystkieDania(); break;
                case 3: Console.Clear(); Aplikacja.StartOpcje(); break;
                case 4: Environment.Exit(0); break;
            }
        }
    

    }
}
