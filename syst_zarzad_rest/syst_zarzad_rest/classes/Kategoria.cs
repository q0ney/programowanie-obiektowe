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
        public List<Danie> IDDania { get; set; }


        public Kategoria(string nazwaKategoria)
        {
            NazwaKategoria = nazwaKategoria;
            IDDania = new List<Danie>();
        }

        
        // Metoda pozwalająca dodać danie do kategorii




        public void UsunPozycje(Danie d)
        {
            IDDania.Remove(d);
        }
        public void DodajPozycje(Danie d)
        {
            IDDania.Add(d);
        }


        public override string ToString()
        {
            return $"Kategoria: {NazwaKategoria}";
        }
    }
}
