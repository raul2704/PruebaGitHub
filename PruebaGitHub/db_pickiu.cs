﻿using System;
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
            foreach(Vuelos v in Vuelos.ToList())
            {                
                lista.Add(new cgestionarpickiu { idvuelo = v.id, NoVuelo = v.NoVuelo.ToString(), FechaVuelo = v.Fecha, Ciudad = v.Ciudades.Nombre });                
            }
            return lista;
        }

        internal int Agregar_Vuelo(string pnumero_vuelo, DateTime pfecha, Ciudades pciudad)
        {
            Vuelos vuelo = new Vuelos { NoVuelo=pnumero_vuelo,Fecha=pfecha, idCiudad=pciudad.id };
            Vuelos.Add(vuelo);
            SaveChanges();
            return vuelo.id;
        }

        internal void Modificar_Vuelo(int pid, string pnumero_vuelo, DateTime pfecha, Ciudades pciudad)
        {
            Vuelos vuelo = Vuelos.FirstOrDefault(v => v.id == pid);
            if(vuelo!=null)
            {
               vuelo.NoVuelo = pnumero_vuelo;
               vuelo.Fecha = pfecha;
               vuelo.idCiudad= pciudad.id;
               SaveChanges();
            }
        }

        internal void Agregar_Guia(int pnumero, int pidcliente, int pidvuelo)
        {
            Guias guia = new Guias { numero = pnumero, idCliente = pidcliente, idVuelo = pidvuelo };
            Guias.Add(guia);
            SaveChanges();
        }

        internal void Modificar_Guia(int pidguia, int pnumero, int pidcliente)
        {
            Guias guia = Guias.FirstOrDefault(g => g.id == pidguia);
            if (guia != null)
            {
                guia.numero = pnumero;
                guia.idCliente = pidcliente;                
                SaveChanges();
            }
        }
    }
}
