using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{ 
    class DanieRybne : Danie
    {
        public DanieRybne(int id, string nazwa, string opis, double cena, Kategoria k)
             : base(id, nazwa, opis, cena, k)
        {

        }
    }
}
