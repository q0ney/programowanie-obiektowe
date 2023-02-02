using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace syst_zarzad_rest
{
    abstract class Aplikacja : IDisplayable
    {
        private const string V = "WriteText.txt";

        public static List<Zamowienie> _zamowienia = new List<Zamowienie>();
        private static List<Rachunek> _rachunki = new List<Rachunek>();




        public static void DodajZamowienie(Zamowienie z)
        {

            _zamowienia.Add(z);

        }

        public static void UsunZamowienie(int idZam)
        {
            var z = _zamowienia.FirstOrDefault(zamow => zamow.IdZam == idZam);
            if (z != null)
            {
                _zamowienia.Remove(z);
            }
        }

        public static void WyswietlWszystkieDania()
        {
           
                foreach (Danie d in Menu.danie)
                {
                    Console.WriteLine(" id:" + d.Id + " | " +  d.xd +  " | " + d.Nazwa + ": " + d.Opis + " (" + d.Cena + " zł )");
                }
            
        }


        public static void WyswietlZamowienia()
        {
            foreach (var zamowienie in _zamowienia)
            {

                Console.WriteLine("Data zamowienia: {0}", zamowienie.DataZamowienia);
                Console.WriteLine("ID: {0}", zamowienie.IdZam);
                Console.WriteLine("Dania: ");
                foreach (var d in zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", zamowienie.ObliczKwote());
                Console.WriteLine();
            }


        }

        void IDisplayable.Display()
        {
            Console.WriteLine("Displeayble");
        }
        void IDisplayable.WyszukajPoID(int idZam)
        {
            foreach (var r in _rachunki.Where(r => r.Zamowienie.IdZam == idZam))
            {
                Console.WriteLine("Data zamowienia: {0}", r.Zamowienie.DataZamowienia);
                Console.WriteLine("ID: {0}", r.Zamowienie.IdZam);
                Console.WriteLine("Dania: ");
                foreach (var d in r.Zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", r.Zamowienie.ObliczKwote());
                Console.WriteLine();
            }
        }

        public static void WygenerujRachunek()
        {
            foreach (var z in _zamowienia)
            { 
            _rachunki.Add(new Rachunek(z));
            }
        }


        public static void OdczytajzPliku()
        {
            using (StreamReader sr = new StreamReader($".\\rachunki5.txt"))
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

            using (StreamWriter sw = new StreamWriter($".\\rachunki5.txt"))
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

        public static void WyswietlRachunki()
        {
            foreach (var rachunek in _rachunki)
            {
                Console.WriteLine("Data zamowienia: {0}", rachunek.Zamowienie.DataZamowienia);
                Console.WriteLine("ID: {0}", rachunek.Zamowienie.IdZam);
                Console.WriteLine("Dania: ");
                foreach (var d in rachunek.Zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", rachunek.Zamowienie.ObliczKwote());
                Console.WriteLine();
            }
        }

        public static void WyszukajRachunkiPoID(int idZam)
        {
            foreach (var r in _rachunki.Where(r => r.Zamowienie.IdZam == idZam))
            {
                Console.WriteLine("Data zamowienia: {0}", r.Zamowienie.DataZamowienia);
                Console.WriteLine("ID: {0}", r.Zamowienie.IdZam);
                Console.WriteLine("Dania: ");
                foreach (var d in r.Zamowienie.Dania)
                {
                    Console.WriteLine(" - {0} ({1} zl)", d.Nazwa, d.Cena);
                }
                Console.WriteLine("Kwota: {0} zl", r.Zamowienie.ObliczKwote());
                Console.WriteLine();
            }
        }

 
    }
}
