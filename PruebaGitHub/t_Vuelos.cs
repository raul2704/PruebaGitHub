using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public partial class Vuelos
    {
        public string Mes
        {
           get { return string.Format("{0:MMMM}", Fecha); }
        }
    }
}
