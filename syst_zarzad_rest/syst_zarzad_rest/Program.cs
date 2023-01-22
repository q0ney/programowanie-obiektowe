using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var kremZPomidorow = new Danie("Krem z pomidorów", "Krem z pomidorów z dodatkiem śmietany", 15);
            var rosol = new Danie("Rosół", "Tradycyjny rosół z kury", 45);

            aplikacja.DodajDanieDoKategorii(rosol, zupy);
            aplikacja.DodajDanieDoKategorii(kremZPomidorow, zupy);



            // Console.WriteLine(zupy);

            //nowe zamowienie 1
            var zamowienie1 = new Zamowienie();
            zamowienie1.DataZamowienia = DateTime.Now;
            zamowienie1.DodajDanie(kremZPomidorow);
            zamowienie1.DodajDanie(rosol);
            //dodanie do aplikacji
            aplikacja.DodajZamowienie(zamowienie1);

            //nowe zamowienie 2
            var zamowienie2 = new Zamowienie();
            zamowienie2.DataZamowienia = DateTime.Now.AddDays(1);
            zamowienie2.DodajDanie(rosol);

            aplikacja.DodajZamowienie(zamowienie2);

            aplikacja.WyswietlZamowienia();



            Console.ReadKey();


        }
    }
}
