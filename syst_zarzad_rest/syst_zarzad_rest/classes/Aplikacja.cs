using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using syst_zarzad_rest;
using static syst_zarzad_rest.Danie;

namespace Applikacja2
{
    internal class Aplikacja 
    {
        private const string V = "WriteText.txt";
        private static Menu _menu;
        private static List<Zamowienie> _zamowienia;
        private static List<Kategoria> _kategoria;
        private static List<Rachunek> _rachunki;
        static string[] pozycjeMenu = { "1. Wyswietl menu", "2. Wyswietl zamowienia", "3. Rachunki",
         "4. Dania", "5. Kategorie", "6. Zrob nowe zamowienie", "7. Usun zamowienie", "8. Odczyt rachunku", "9. Exit"};
        static string[] pozycjeRachunki = { "1. Wyswietl wszystkie rachunki", "2. Zpisz rachunki do pliku", "3. Odczytaj rachunki z pliku", "4. Wroc" };
        static int aktywnaPozycjaMenu = 0;


        public Aplikacja()
        {
            _menu = new Menu();
            _zamowienia = new List<Zamowienie>();
            _rachunki = new List<Rachunek>();
            _kategoria = new List<Kategoria>();
        }

        public void DodajKategorieDoMenu(Kategoria k)
        {
            _menu.DodajKategorie(k);
        }

        public void UsunKategorieDoMenu(Kategoria k)
        {
            _menu.UsunKategorie(k);
        }

        public static void DodajDanieDoKategorii(Danie d, Kategoria k)
        {
            k.UsunPozycje(d);
        }

        public void UsunDanieZKategorii(Danie d, Kategoria k)
        {
            k.DodajPozycje(d);
        }

        public void DodajZamowienie(Zamowienie z)
        {
            _zamowienia.Add(z);
        }

        public void UsunZamowienie(Zamowienie z)
        {
            _zamowienia.Remove(z);
        }


        public static void WyswietlWszystkieDania()
        {
            foreach (Kategoria k in _menu.Kategoria)
            {
                Console.WriteLine(k.NazwaKategoria);
                foreach (Danie d in k.Dania)
                {
                    Console.WriteLine(" - " + Danie.Nazwa + ": " + Danie.Opis + " (" + Danie.Cena + " zł )");
                }
            }
            Console.ReadKey();
        }

        public static void WyswietlZamowienia()
        {
            foreach (var zamowienie in _zamowienia)
            {

                Console.WriteLine("Data zamowienia: {0}", zamowienie.DataZamowienia);
                Console.WriteLine("Dania: ");
                foreach (var d in zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", Danie.Nazwa, Danie.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", zamowienie.ObliczKwote());
                Console.WriteLine();
            }


        }

        public List<Zamowienie> WyszukajZamowieniePoDacie(DateTime data)
        {
            return _zamowienia.Where(z => z.DataZamowienia.Date == data.Date).ToList();
        }

        public void WygenerujRachunek(Zamowienie z)
        {
            _rachunki.Add(new Rachunek());
        }


        public static void OdczytajzPliku()
        {
            using (StreamReader sr = new StreamReader($"C:\\Users\\propa\\source\\repos\\syst_zarzad_rest\\rachunki.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void ZapiszDoPliku()
        {
            // tworzenie txt
            int i = 1;

            using (StreamWriter sw = new StreamWriter($"C:\\Users\\propa\\source\\repos\\syst_zarzad_rest\\rachunki.txt"))
            {
                foreach (var rachunek in _rachunki)
                {
                    sw.WriteLine(i + ". Data zamowienia: {0}", rachunek.Zamowienie.DataZamowienia);
                    foreach (var d in rachunek.Zamowienie.Dania)
                    {
                        sw.WriteLine(" - {0} ({1} zl)", Danie.Nazwa, Danie.Cena);
                    }
                    sw.WriteLine("Kwota: {0} zl", rachunek.Kwota);
                    sw.WriteLine(" ");
                    i++;
                }
            }
        }




        public static void WyswietlRachunki()
        {
            foreach (var rachunek in _rachunki)
            {
                Console.WriteLine("Data zamowienia: {0}", rachunek.Zamowienie.DataZamowienia);
                Console.WriteLine("Dania: ");
                foreach (var d in rachunek.Zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", Danie.Nazwa, Danie.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", rachunek.Zamowienie.ObliczKwote());
                Console.WriteLine();
            }
        }

        public List<Rachunek> WyszukajRachunkiPoDacie(DateTime data)
        {
            return _rachunki.Where(r => r.Zamowienie.DataZamowienia.Date == data.Date).ToList();
        }




        /// <summary>
        /// OPCJE MENU
        /// </summary>
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
            Console.Write("Press any key to continue");
            Console.WriteLine();
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
                case 0: Console.Clear(); WyswietlWszystkieDania(); break;
                case 1: Console.Clear(); WyswietlZamowienia(); break;
                case 2:
                    Console.Clear();
                    Rachunek[] tabrachunek = new Rachunek[2];
                    tabrachunek[0] = new Rachunek();
                    tabrachunek[0].StartOpcje();
                    break;
                case 3: Console.Clear();
                    Opcje[] tabrachunek1 = new Opcje[2];
                    tabrachunek1[0] = new Opcje();
                    tabrachunek1[0].StartOpcje();
                    break;
                case 4: Console.Clear(); WyswietlWszystkieDania(); break;
                case 5: Console.Clear(); WyswietlWszystkieDania(); break;
                case 6: Console.Clear(); WyswietlWszystkieDania(); break;
                case 7: Console.Clear(); WyswietlWszystkieDania(); break;
                case 8: Console.Clear(); WyswietlWszystkieDania(); break;
                case 9: Environment.Exit(0); break;
            }








        }
    }
}
