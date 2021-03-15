using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio
{
    class Propiedad
    {
        string noCasa;
        string dpi;
        double cuota;

        public string NoCasa { get => noCasa; set => noCasa = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public double Cuota { get => cuota; set => cuota = value; }
    }
}
