using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public partial class Origenes
    {
        string aorigen = "";
        public string Origen
        {
            set
            { 
                aorigen = value;
            }                
            get
            {
                string pais = idPais != 0 ? Paises.Nombre + "/ " : "";
                string ciudad = idCiudad != 0 ? Ciudades.Nombre + "/ " : "";
                string finca = idFinca != 0 ? Fincas.Nombre + "/ " : "";
                string sigla = Siglas != null ? Siglas.Sigla : "";
                return aorigen+pais+ciudad+finca+sigla;
            }
        }

        public override string ToString()
        {
            return aorigen;
        }
        //Al fin aqui estoy yo
        //public string GetOrigen
        //{
        //     get 
        //     {
        //         string sigla =Siglas != null ? Siglas.Sigla : "";
        //         return Paises.Nombre + "/ " + Ciudades.Nombre + "/ " + Fincas.Nombre+"/ "+sigla; 
        //     }  
        //}           

    }
}
