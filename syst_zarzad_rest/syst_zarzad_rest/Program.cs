using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace syst_zarzad_rest
{




    class Program
    {
        static void Main(string[] args)
        {
            //nowa aplikacja
            var aplikacja = new Aplikacja();

             


            //nowe kategorie
            var przystawki = new Kategoria("Przystawki");
            var zupy = new Kategoria("Zupy");
            var daniaGlowne = new Kategoria("Dania główne");

            aplikacja.DodajKategorieDoMenu(przystawki);
            aplikacja.DodajKategorieDoMenu(zupy);
            aplikacja.DodajKategorieDoMenu(daniaGlowne);

            //nowe dania
            var kremZPomidorow = new DanieVege("Krem z pomidorów", "Krem z pomidorów z dodatkiem śmietany", 15);
            var rosol = new DanieMiesne("Rosół", "Tradycyjny rosół z kury", 45);
            var DorszFrytki = new DanieRybne("Dorsz z frytkami", "Dorsz 300g z frytkami i suruwka", 50);
            var PieczywoCzosnkowe = new DanieVege("Pieczywo czosnkowe", "Pieczywo z maslem czosnkowym", 13);

            aplikacja.DodajDanieDoKategorii(rosol, zupy);
            aplikacja.DodajDanieDoKategorii(kremZPomidorow, zupy);
            aplikacja.DodajDanieDoKategorii(DorszFrytki, daniaGlowne);
            aplikacja.DodajDanieDoKategorii(PieczywoCzosnkowe, przystawki);



            //wyswietlanie menu
            //aplikacja.WyswietlWszystkieDania();


            //nowe zamowienie 1



            //aplikacja.WyswietlWszystkieDania();

 


            //nowe zamowienie 2





        //tworzenie rachunku dla z1

        //aplikacja.ZapiszDoPliku(zamowienie1);
        //aplikacja.WygenerujRachunek(zamowienie2);
        //aplikacja.ZapiszDoPliku(zamowienie2);
        //aplikacja.WyswietlRachunki();

            while (true)
            {
                
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("1. Wyswietl menu");
                Console.WriteLine("2. Wyswietl rachunki i zapisz do pliku");
                Console.WriteLine("3. Zrob nowe zamowienie");
                Console.WriteLine("4. Odczyt rachunku");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        aplikacja.WyswietlWszystkieDania();
                        break;

                    case 2:
                        Console.Clear();
                        aplikacja.WyswietlRachunki();
                        break;
                    case 3:
                        Console.Clear();
                        var zamowienie1 = new Zamowienie();
                        zamowienie1.DataZamowienia = DateTime.Now;
                        zamowienie1.DodajDanie(kremZPomidorow);
                        zamowienie1.DodajDanie(rosol);

                        aplikacja.DodajZamowienie(zamowienie1);
                        aplikacja.WygenerujRachunek(zamowienie1);
                        aplikacja.ZapiszDoPliku(zamowienie1);


                        break;

                    case 4:
                        Console.Clear();
                        aplikacja.OdczytajzPliku();
                        break;
                        
                    case 5:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                        Console.WriteLine(" ");
                        break;
                }




            }

            


        }
    }
}
