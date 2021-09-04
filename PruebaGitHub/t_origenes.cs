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
                using (DBPickiuEntities db = new DBPickiuEntities())
                {
                    string pais = idPais != 0 ? db.Paises.Find(idPais).Nombre + "/ " : "";
                    string ciudad = idCiudad != 0 ?db.Ciudades.Find(idCiudad).Nombre + "/ " : "";
                    string finca = idFinca != 0 ?db.Fincas.Find(idFinca).Nombre + "/ " : "";
                    string sigla = idSigla != null ? db.Siglas.Find(idSigla).Sigla : "";

                    return aorigen + pais + ciudad + finca + sigla;
                }
            }
        }

        public string OrigenCorto
        {
            get
            {
                using (DBPickiuEntities db = new DBPickiuEntities())
                {
                    string finca = idFinca != 0 ? db.Fincas.Find(idFinca).Nombre + "/ " : "";
                    string sigla = idSigla != null ? db.Siglas.Find(idSigla).Sigla : "";
                    return finca + sigla;
                }
            }
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
