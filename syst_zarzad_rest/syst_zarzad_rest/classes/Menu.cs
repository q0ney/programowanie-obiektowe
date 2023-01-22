using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    class Menu
    {
        public List<Kategoria> Kategoria { get; set; }

        public Menu()
        {
            Kategoria = new List<Kategoria>();
        }

        // Metoda pozwalająca dodać kategorie do menu
        public void DodajKategorie(Kategoria k)
        {
            Kategoria.Add(k);
        }

        // Metoda pozwalająca usunąć kategorie z menu
        public void UsunKategorie(Kategoria k)
        {
            Kategoria.Remove(k);
        }

    }
}
