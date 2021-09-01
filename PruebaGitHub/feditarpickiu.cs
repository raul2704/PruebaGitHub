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
           aVuelo = pVuelo;
           ListaCiudades = new List<Ciudades>();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void feditarpickiu_Load(object sender, EventArgs e)
        {
            Cargar_Ciudades();
            if (aVuelo != null)
            {

            }
            else
            {
                aCiudad = ListaCiudades.FirstOrDefault();
                if (aCiudad != null)
                    cbciudades.SelectedItem = aCiudad;
            }
                    
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
