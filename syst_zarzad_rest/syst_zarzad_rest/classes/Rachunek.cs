using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class Rachunek
    {
        public Zamowienie Zamowienie { get; set; }
        public double Kwota { get; set; }
        public DateTime DataWystawienia { get; set; }
        public Rachunek(Zamowienie zamowienie)
        {
            Zamowienie = zamowienie;
            Kwota = zamowienie.ObliczKwote();
            DataWystawienia = DateTime.Now;
        }

    }
}
