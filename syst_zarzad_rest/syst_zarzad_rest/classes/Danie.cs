
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    public class Danie
    {
        private string v1;
        private double v2;

        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }

        public Danie(string nazwa, string opis, double cena)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;

        }

        public Danie(string v1, double v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public override string ToString()
        {
            return $"Nazwa: {Nazwa}, Opis: {Opis}, Cena: {Cena}";
        }

    }
}
