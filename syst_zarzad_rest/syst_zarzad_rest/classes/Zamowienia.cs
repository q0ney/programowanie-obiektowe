using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applikacja2;


namespace syst_zarzad_rest
{
    internal class Zamowienie
    {
        static int aktywnaPozycjaMenu = 0;
        static string[] pozycjeMenu = { "1. Dodaj Zamowienie", "2.Usun Zamowienie", "3. Wyswietl zamowienia", "4. Wroc" };
        static public List<Danie> Dania { get; set; }
        static public double Kwota { get; set; }
        static public DateTime DataZamowienia { get; set; }


        public Zamowienie()
        {
            Dania = new List<Danie>();
            Kwota = 0;
            DataZamowienia = DateTime.Now;
        }

        public void DodajDanie(Danie d)
        {
            Dania.Add(d);
        }

        public double ObliczKwote()
        {
            return Dania.Sum(idDania => Danie.Cena);
        }



        public class OpcjeZamowienia : IOpcje, IAddRemove
        {
            public void DodajPozycje()
            {
                Console.WriteLine("essa");
            }
            public void UsunPozycje()
            {
                Console.WriteLine("essa");
            }

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



        public void WybieranieOpcji()
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

        public void UruchomOpcje()
        {
            switch (aktywnaPozycjaMenu)
            {
                case 0: Console.Clear(); DodajPozycje(); break;
                case 1: Console.Clear(); UsunPozycje(); break;
                case 3: Console.Clear(); Aplikacja.WyswietlZamowienia(); break;
                case 4:
                    Console.Clear();
                    Aplikacja.StartOpcje();
                    break;

            }
        }
        }
    }
}
