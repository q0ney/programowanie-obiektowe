using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{

    public interface IDisplayable
    {

        void  Display();
        
        void WyszukajPoID(int idZam);
    }
}
