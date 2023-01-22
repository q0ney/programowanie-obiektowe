﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class Danie
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }

        public Danie(string nazwa, string opis, double cena)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;

        }
        public override string ToString()
        {
            return $"Nazwa: {Nazwa}, Opis: {Opis}, Cena: {Cena}";
        }

    }
}
