using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace syst_zarzad_rest
{
    internal class Aplikacja
    {
        private const string V = "WriteText.txt";
        private Menu _menu;
        private List<Zamowienie> _zamowienia;
        private List<Kategoria> _kategoria;
        private List<Rachunek> _rachunki;

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


        public void WyswietlWszystkieDania()
        {
            foreach (Kategoria k in _menu.Kategoria)
            {
                Console.WriteLine(k.NazwaKategoria);
                foreach (Danie d in k.Dania)
                {
                    Console.WriteLine(" - " + d.Nazwa + ": " + d.Opis + " (" + d.Cena + " zł )");
                }
            }
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

        public List<Zamowienie> WyszukajZamowieniePoDacie(DateTime data)
        {
            return _zamowienia.Where(z => z.DataZamowienia.Date == data.Date).ToList();
        }

        public void WygenerujRachunek(Zamowienie z)
        {
            _rachunki.Add(new Rachunek(z));
        }

        public void ZapiszDoPliku(Zamowienie z)
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
                        sw.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                    }
                    sw.WriteLine("Kwota: {0} zl", rachunek.Kwota);
                    sw.WriteLine(" ");
                    i++;
                }
            }
        }

        public void WyswietlRachunki()
        {
            foreach (var rachunek in _rachunki)
            {
                Console.WriteLine("Data zamowienia: {0}", rachunek.Zamowienie.DataZamowienia);
                Console.WriteLine("Dania: ");
                foreach (var d in rachunek.Zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", rachunek.Zamowienie.ObliczKwote());
                Console.WriteLine();
            }
        }

        public List<Rachunek> WyszukajRachunkiPoDacie(DateTime data)
        {
            return _rachunki.Where(r => r.Zamowienie.DataZamowienia.Date == data.Date).ToList();
        }
    


    }
}
