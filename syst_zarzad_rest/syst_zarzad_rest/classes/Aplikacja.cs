using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    internal class Aplikacja
    {
        private Menu _menu;
        private List<Zamowienie> _zamowienia;
        private List<Rachunek> _rachunki;

        public Aplikacja()
        {
            _menu = new Menu();
            _zamowienia = new List<Zamowienie>();
            _rachunki = new List<Rachunek>();
        }

        public void DodajKategorieDoMenu(Kategoria k)
        {
            _menu.DodajKategorie(k);
        }

        public void UsunKategorieDoMenu(Kategoria k)
        {
            _menu.UsunKategorie(k);
        }

        public void DodajDanieDoKategorii(Danie d, Kategoria k)
        {
            k.DodajDanie(d);
        }

        public void UsunDanieZKategorii(Danie d, Kategoria k)
        {
            k.UsunDanie(d);
        }

        public void DodajZamowienie(Zamowienie z)
        {
            _zamowienia.Add(z);
        }

        public void UsunZamowienie(Zamowienie z)
        {
            _zamowienia.Remove(z);
        }

        public void WyswietlZamowienia()
        {
            foreach (var zamowienie in _zamowienia)
            {

                Console.WriteLine("Data zamowienia: {0}", zamowienie.DataZamowienia);
                Console.WriteLine("Dania: ");
                foreach (var d in zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", zamowienie.ObliczKwote());
                Console.WriteLine();
            }


        }



    }
}
