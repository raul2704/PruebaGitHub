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
        List<Ciudades> ListaCiudades = null;
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
            Cargar_Datos();                    
        }

        private void Cargar_Datos()
        {
            if (aVuelo != null)
            {
               aCiudad = ListaCiudades.FirstOrDefault(c=>c.id==aVuelo.idCiudad);
               txtnumerovuelo.Text = aVuelo.NoVuelo;
               dtfecha.Value = aVuelo.Fecha;
            }
            else
            {
               aCiudad = ListaCiudades.FirstOrDefault();               
            }

            if (aCiudad != null)
                cbciudades.SelectedItem = aCiudad;
        }

        private void Cargar_Ciudades()
        {
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                ListaCiudades = db.Ciudades.OrderBy(c => c.Nombre).ToList();               
                cbciudades.DataSource = ListaCiudades;              
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
    }
}
