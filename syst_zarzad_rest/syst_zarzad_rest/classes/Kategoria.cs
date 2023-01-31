using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Applikacja2;

namespace syst_zarzad_rest
{
    class Kategoria 
    {
        public string NazwaKategoria { get; set; }
        public List<Danie> Dania { get; set; }


        public Kategoria(string nazwaKategoria)
        {
            NazwaKategoria = nazwaKategoria;
            Dania = new List<Danie>();
        }

        
        // Metoda pozwalająca dodać danie do kategorii




        public void UsunPozycje(Danie d)
        {
            Dania.Remove(d);
        }
        public void DodajPozycje(Danie d)
        {
            Dania.Add(d);
        }


        public override string ToString()
        {
            return $"Kategoria: {NazwaKategoria}";
        }
    }
}
