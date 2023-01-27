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
            var PieczywoCzosnkowe = new DanieVege("Pieczywo czosnkowe", "dddddddd", 13);

            aplikacja.DodajDanieDoKategorii(rosol, zupy);
            aplikacja.DodajDanieDoKategorii(kremZPomidorow, zupy);
            aplikacja.DodajDanieDoKategorii(DorszFrytki, daniaGlowne);
            aplikacja.DodajDanieDoKategorii(PieczywoCzosnkowe, przystawki);



            //wyswietlanie menu
            aplikacja.WyswietlWszystkieDania();

            Console.WriteLine(" ");

         //nowe zamowienie 1
        var zamowienie1 = new Zamowienie();
        zamowienie1.DataZamowienia = DateTime.Now;
        zamowienie1.DodajDanie(kremZPomidorow);
        zamowienie1.DodajDanie(rosol);

        aplikacja.DodajZamowienie(zamowienie1);


            aplikacja.UsunDanieZKategorii(rosol, zupy);

        aplikacja.WyswietlWszystkieDania();

        Console.WriteLine(" ");
        Console.WriteLine(" ");    
        Console.WriteLine(" ");
        Console.WriteLine(" ");


            //nowe zamowienie 2
            var zamowienie2 = new Zamowienie();
        zamowienie2.DataZamowienia = DateTime.Now.AddDays(1);
        zamowienie2.DodajDanie(rosol);

        aplikacja.DodajZamowienie(zamowienie2);



         Console.WriteLine(" ");

        //tworzenie rachunku dla z1
        aplikacja.WygenerujRachunek(zamowienie1);
        aplikacja.ZapiszDoPliku(zamowienie1);
        aplikacja.WygenerujRachunek(zamowienie2);
        aplikacja.ZapiszDoPliku(zamowienie2);
        aplikacja.WyswietlRachunki();



        Console.ReadKey();


        }
    }
}
