using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace syst_zarzad_rest
{
    class Zamowienie
    {
        public List<Danie> Dania { get; set; }
        public double Kwota { get; set; }
        public DateTime DataZamowienia { get; set; }
        public int IdZam { get; set; }
        public static string[] pozycjeMenu = { "1. Stworz zamowienie", "2. Usun zamowienie", "3. Wyswietl zamowienia" , "4. Wroc" };
        public static int aktywnaPozycjaMenu = 0;


        public Zamowienie(int idZam)
        {
            Dania = new List<Danie>();
            Kwota = 0;
            DataZamowienia = DateTime.Now;
            IdZam = idZam;
        }



        public void DodajDanie(int idD)
        {
            var danie22 = Menu.danie.FirstOrDefault(danie => danie.Id == idD);
            if (danie22 != null)
            {
                Dania.Add(danie22);
            }
        }


        public double ObliczKwote()
        {
            return Dania.Sum(d => d.Cena);
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
                    Functions.TworzenieZamowien();
                    break;
                case 1: Console.Clear();
                    Functions.UsuwanieZamowien();
                    break;
                case 2:
                    Console.Clear();
                    Aplikacja.WyswietlZamowienia();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    GUI.StartOpcje();
                    break;
            }


        }
    }
}

    

