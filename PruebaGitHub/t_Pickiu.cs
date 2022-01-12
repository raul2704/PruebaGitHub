using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public partial class Pickiu
    {
        public estado Estado { set; get; } = estado.normal;

        public string Mes
        {
          get { return string.Format("{0:MMMM}", Guias.Vuelos.Fecha); }
        }
    }
}
