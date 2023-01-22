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
            return Dania.Sum(d => d.Cena);
        }



    }
}
