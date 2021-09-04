using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaGitHub
{
    public partial class feditarpickiu : Form
    {
        Vuelos aVuelo = null;
        Ciudades aCiudad = null;
        Origenes aOrigen=null;
        Clientes aCliente=null;
        List<Clientes> ListaClientes = null;
        List<Ciudades> ListaCiudades = null;
        List<Origenes> ListaOrigenes = null;
        

        public feditarpickiu(Vuelos pVuelo=null)
        {
           InitializeComponent();
           ListaCiudades = new List<Ciudades>();
           if (pVuelo != null)
           {
               using (DBPickiuEntities db = new DBPickiuEntities())
               {
                   aVuelo = db.Vuelos.FirstOrDefault(v => v.NoVuelo == pVuelo.NoVuelo && v.Fecha == pVuelo.Fecha);
               }
           }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void feditarpickiu_Load(object sender, EventArgs e)
        {
            Cargar_Ciudades();
            Cargar_Origenes();
            Cargar_Clientes();
            Cargar_Datos();                    
        }

        private void Cargar_Clientes()
        {
            ListaClientes = null;
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                ListaClientes = db.Clientes.OrderBy(c => c.Nombre).ToList();
                cbcliente.DataSource = ListaCiudades;
                if (ListaClientes.Count != 0)
                    aCliente = ListaClientes.FirstOrDefault();
            }
        }

        private void Cargar_Origenes()
        {
            ListaOrigenes = null;
            if (aCiudad != null)
            {
                using (DBPickiuEntities db = new DBPickiuEntities())
                {
                    ListaOrigenes = db.Origenes.Where(o => o.idCiudad == aCiudad.id).OrderBy(o => o.Fincas.Nombre).ToList();
                    cborigen.DataSource = ListaOrigenes;
                    if (ListaOrigenes.Count != 0)
                        aOrigen = ListaOrigenes.FirstOrDefault();
                }
            }
        }

        private void Cargar_Datos()
        {
            if (aVuelo != null)
            {
               
               txtnumerovuelo.Text = aVuelo.NoVuelo;
               dtfecha.Value = aVuelo.Fecha;
               aCiudad = aVuelo.Ciudades;
                if (aCiudad != null)
                {
                    cbciudades.SelectedItem = aCiudad;
                    Cargar_Origenes();
                }

            }
            else
            {
               
               
            }

            
        }

        private void Cargar_Ciudades()
        {
           using (DBPickiuEntities db = new DBPickiuEntities())
           {
              ListaCiudades = db.Ciudades.OrderBy(c => c.Nombre).ToList();               
              cbciudades.DataSource = ListaCiudades;
              if(ListaCiudades.Count!=0)
                 aCiudad = ListaCiudades.FirstOrDefault();
           }
        }

        private void Cargar_Vuelo()
        {

        }

        private void Cargar_Guias()
        {

        }

        private void Cargar_Pickiu()
        {

        }

        private void cbciudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCiudad = cbciudades.SelectedItem as Ciudades;
            Cargar_Origenes();
        }
    }
}
