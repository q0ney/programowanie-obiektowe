using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class DanieVege : Danie
    {
       public DanieVege(int idDania, string nazwa, string opis, double cena)
            : base(idDania, nazwa, opis, cena)
        {

        }
    }
}
