using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public enum estado
    {
       normal=1,
       agregado,
       modificado
    }
    public partial class Guias
    {
        public estado Estado { set; get; } = estado.normal;
        
    }
}
