
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
     class Danie 
    {

        public static string[] pozycjeMenu = { "1. Dodaj danie", "2. Usun danie", "3. Wroc" };
        public static int aktywnaPozycjaMenu = 0;
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public int Id { get; set; }


        public Kategoria xd;

        public Danie(int id, string nazwa, string opis, double cena, Kategoria k)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Id = id;
            xd = k;

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
                case 0: Console.Clear();
                    Functions.DodawanieDan();
                    break;
                case 1: Console.Clear();
                    Functions.UsuwanieDan();
                    break;
                case 2:
                    Console.Clear();
                    GUI.StartOpcje();
                    break;

            }


        }
    }




}

