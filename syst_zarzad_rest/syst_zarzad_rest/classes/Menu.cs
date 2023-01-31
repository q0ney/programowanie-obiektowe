using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class Menu : MenuBase
    {
        public List<Kategoria> Kategoria { get; set; }

        public Menu()
        {
            Kategoria = new List<Kategoria>();
        }

        // Metoda pozwalająca usunąć kategorie z menu
        public void UsunKategorie(Kategoria k)
        {
            Kategoria.Remove(k);
        }
    }
}
