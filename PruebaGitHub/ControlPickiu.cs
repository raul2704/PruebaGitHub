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
        Origenes aOrigen=null;
        int idvuelo = 0;

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
            dgpickiu.AutoGenerateColumns = false;
            
            using(DBPickiuEntities db=new DBPickiuEntities())
            {
                origenesBindingSource1.DataSource = db.Origenes.ToList();
                List<cgestionarpickiu> milista= db.Lista_Pickiu();
                milista = milista.Where(c => c.FechaVuelo <= aFechaVuelo).ToList();
                if (aNoVuelo != "")
                    milista = milista.Where(l => l.NoVuelo.Equals(aNoVuelo)).ToList();
                if (aCiudad!=null && aCiudad.id != 0)                  
                    milista = milista.Where(l => l.Ciudad.Equals(aCiudad.Nombre)).ToList();               

                dgpickiu.DataSource = milista;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            aNoVuelo = "";
            if (textBox2.Text != "")
              aNoVuelo = textBox2.Text;            
            Cargar_Datos();                
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

        private void cborigen_SelectedIndexChanged(object sender, EventArgs e)
        {
           Cargar_Datos();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            feditarpickiu formedit = new feditarpickiu();
            formedit.Text = "";
            formedit.Cargar_Datos();
            formedit.ShowDialog();
            Cargar_Datos();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            feditarpickiu formedit = new feditarpickiu();
            formedit.Cargar_Datos(idvuelo);
            formedit.ShowDialog();
            Cargar_Datos();
        }

        private void dgpickiu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           idvuelo =Convert.ToInt32(dgpickiu.Rows[e.RowIndex].Cells[0].Value);           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnreportedistribucion_Click(object sender, EventArgs e)
        {
            FReportes freportes = new FReportes();
            freportes.Cargar_Reporte_Distribucion();
            freportes.Show();
        }
    }
}
