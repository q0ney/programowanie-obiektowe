
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applikacja2;


namespace syst_zarzad_rest
{
    internal class Danie 
    {

        public static int IDDania { get; set; }
        public static string Nazwa { get; set; }
        public static string Opis { get; set; }
        public static double Cena { get; set; }
        public static int Rodzaj { get; set; }
        static int aktywnaPozycjaMenu = 0;
        static string[] pozycjeMenu = { "1. Dodaj danie", "2.Usun danie", "3. Wroc" };

        
        public Danie(int idDania, string nazwa, string opis, double cena)
        {
            IDDania = idDania;
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            

        }

        public class Opcje : IOpcje
        {

            public void UsunPozycje()
        {
            Console.WriteLine("essa");
        }
        public void DodajPozycje()
        {
                while (true)
                {
                    
                    Console.WriteLine("Podaj nazwe:");
                    Nazwa = Console.ReadLine();
                    Console.WriteLine("Podaj opis:");
                    Opis = Console.ReadLine();
                    Console.WriteLine("Podaj Cene:");
                    Cena = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Podaj ID:");
                    IDDania = Convert.ToInt32(Console.ReadLine());

                    //d = new Danie(IDDania, Nazwa, Opis, Cena);
                    //k = new Kategoria("Zupy");
                    //Aplikacja.DodajDanieDoKategorii(d, k);




                    Console.WriteLine("Chcesz kon 1-tak 2-nie");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        return;
                       
                    }
                    else if (choice == 2)
                    {
                        IDDania++;
                        StartOpcje();
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny wybor");
                    }
                    
                }
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
                case 2:
                    Console.Clear();
                    Aplikacja.StartOpcje();
                    break;

            }
        }


        }

        public override string ToString()
        {
            return $"Nazwa: {IDDania}, Nazwa: {Nazwa}, Opis: {Opis}, Cena: {Cena}, Cena: {Rodzaj}";
        }

    }
}
