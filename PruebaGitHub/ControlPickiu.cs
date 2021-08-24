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
    public partial class ControlPickiu : UserControl
    {
        string aNoVuelo = "";
        DateTime aFechaVuelo = DateTime.Today;
        Ciudades aCiudad = null;

        public ControlPickiu()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void ControlPickiu_Load(object sender, EventArgs e)
        {
           Cargar_Ciudades();
           Cargar_Datos();
        }
        private void Cargar_Ciudades()
        {
          using (DBPickiuEntities db = new DBPickiuEntities())
          {
            var lstciudades= db.Ciudades.ToList();
            lstciudades.Add(new Ciudades { id = 0, Nombre = "- TODAS -" });
            cbciudad.DataSource = lstciudades.OrderBy(c=>c.Nombre).ToList();
            aCiudad = lstciudades.Find(c=>c.id==0); 
            if(aCiudad!=null)
               cbciudad.SelectedItem = aCiudad;
          }
        }

        private void Cargar_Datos()
        {
            using(DBPickiuEntities db=new DBPickiuEntities())
            {
                List<cgestionarpickiu> milista= db.Lista_Pickiu();
                milista = milista.Where(c => c.FechaVuelo.ToShortDateString().Equals(aFechaVuelo.ToShortDateString())).ToList();
                
                if (aNoVuelo != "")
                    milista = milista.Where(l => l.NoVuelo.Equals(aNoVuelo)).ToList();
                if (aCiudad.id != 0)
                    milista = milista.Where(l => l.Ciudad.Equals(aCiudad.Nombre)).ToList();

                dgpickiu.DataSource = milista;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                aNoVuelo = textBox2.Text;
                Cargar_Datos();
            }                
        }

        private void cbciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCiudad =cbciudad.SelectedItem as Ciudades;
            Cargar_Datos();
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            aFechaVuelo = dateTimePicker1.Value;
            Cargar_Datos();
        }
    }
}
