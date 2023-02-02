using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    abstract class Menu
    {
        
        public static List<Danie> danie = new List<Danie>();


        // Metoda pozwalająca dodać kategorie do menu
        public void DodajDanie(Danie d)
        {
            
            danie.Add(d);
        }

        // Metoda pozwalająca usunąć kategorie z menu
        public static void UsunDanie(int idD)
        {
            var danie22 = Menu.danie.FirstOrDefault(danie => danie.Id == idD);
            if (danie22 != null)
            {
                danie.Remove(danie22);
            }
        }

    }
}
