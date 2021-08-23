using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public partial class Origenes
    {
       //Al fin aqui estoy yo
       public string GetOrigen
       {
            get 
            {
                string sigla =Siglas != null ? Siglas.Sigla : "";
                return Paises.Nombre + "/ " + Ciudades.Nombre + "/ " + Fincas.Nombre+"/ "+sigla; 
            }  
       }           

    }
}
