using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{




    class Program
    {
        static void Main(string[] args)
        {



            var kremZPomidorow = new Danie("Krem z pomidorów", "Krem z pomidorów z dodatkiem śmietany", 15);
            var rosol = new Danie("Rosół", "Tradycyjny rosół z kury", 45);


            //Danie d1 = new Danie("Krem z pomidorów", "Krem z pomidorów z dodatkiem śmietany", 15);

            //Console.WriteLine(kremZPomidorow.Nazwa + "|Opis:" + kremZPomidorow.Opis + "|Cena:" + kremZPomidorow.Cena);

            Console.WriteLine(kremZPomidorow);


            Console.ReadKey();


        }
    }
}
