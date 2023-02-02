using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace syst_zarzad_rest
{
    class Kategoria
    {
        public string NazwaKategoria { get; set; }


        public Kategoria(string nazwaKategoria)
        {
            NazwaKategoria = nazwaKategoria;
        }

        public static List<Kategoria> kategoria = new List<Kategoria>()
        {
            new Kategoria("Przystawki"),
            new Kategoria("Zupy"),
            new Kategoria("Glowne")
        };

 
        public override string ToString()
         {
             return $"Kategoria: {NazwaKategoria}";
         }
      
    }
}
