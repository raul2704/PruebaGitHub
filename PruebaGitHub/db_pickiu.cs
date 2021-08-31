using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGitHub
{
    public partial class DBPickiuEntities 
    {
        public List<cgestionarpickiu> Lista_Pickiu()
        {
            List<cgestionarpickiu> lista = new List<cgestionarpickiu>();
            foreach(Pickiu pk in Pickiu.ToList())
            {
              lista.Add(new cgestionarpickiu { NoVuelo = pk.Guias.Vuelos.NoVuelo.ToString(), FechaVuelo = pk.Guias.Vuelos.Fecha, Ciudad = pk.Guias.Vuelos.Ciudades.Nombre, NoGuia = pk.Guias.numero.ToString(), Origen=pk.Origenes.id});              
            }
            return lista;
        }
    }
}
