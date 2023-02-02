using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class Rachunek
    {
        public Zamowienie Zamowienie { get; set; }
        public double Kwota { get; set; }
        public DateTime DataWystawienia { get; set; }
        public int IdRach { get; set;}
        public static string[] pozycjeMenu = { "1. Wygeneruj rachunek dla zamowien", "2. Zapisz do pliku", "3. Odczytaj z pliku", "4. Wyszukaj rachunek po id", "5. Wroc" };
        public static int aktywnaPozycjaMenu = 0;

        public Rachunek(Zamowienie zamowienie)
        {
            Zamowienie = zamowienie;
            Kwota = zamowienie.ObliczKwote();
            DataWystawienia = DateTime.Now;
            IdRach = zamowienie.IdZam;
        }


        public static void StartOpcje()
        {
            while (true)
            {
                PokazOpcje();
                WybieranieOpcji();
                UruchomOpcje();
            }
        }

        public static void PokazOpcje()
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < pozycjeMenu.Length; i++)
            {
                if (i == aktywnaPozycjaMenu)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0, -35}", pozycjeMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;



                }
                else
                {
                    Console.WriteLine(pozycjeMenu[i]);
                }
            }
        }

        public static void WybieranieOpcji()
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : pozycjeMenu.Length - 1;

                    PokazOpcje();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu + 1) % pozycjeMenu.Length;

                    PokazOpcje();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    aktywnaPozycjaMenu = pozycjeMenu.Length - 1;

                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                    break;



            } while (true);
        }

        public static void UruchomOpcje()
        {
            switch (aktywnaPozycjaMenu)
            {
                case 0:
                    Console.Clear();
                    Aplikacja.WygenerujRachunek();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Pomyslnie zapisano do pliku");
                    Aplikacja.ZapiszDoPliku();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Aplikacja.OdczytajzPliku();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Podaj id rachunku ktory chcesz wyszukac");
                    int idRachunku = Convert.ToInt32(Console.ReadLine());
                    Aplikacja.WyszukajRachunkiPoID(idRachunku);
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    GUI.StartOpcje();
                    break;
            }


        }


    }
}
