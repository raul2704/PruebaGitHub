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
        int idvuelo = 0;
        Vuelos aVuelo = null;
        Ciudades aCiudad = null;
        Guias aGuia = null;                
        List<Ciudades> ListaCiudades = null;
        List<Origenes> ListaOrigenes = null;
        List<Pickiu> ListaDistribucion = null;
        List<Guias> ListaGuias = null;
        public feditarpickiu(int pidvuelo=0)
        {
           InitializeComponent();
            idvuelo = pidvuelo;
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
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                ListaGuias = new List<Guias>();
                ListaDistribucion = new List<Pickiu>();
                if (idvuelo == 0) 
                {
                    aVuelo = new Vuelos { id = 0, NoVuelo = "", Fecha = DateTime.Today }; 
                    if (aCiudad != null)
                        aVuelo.Ciudades = aCiudad;                   
                }
                else
                    aVuelo = db.Vuelos.FirstOrDefault(v => v.id == idvuelo);

                Limpiar();
                txtnumerovuelo.Text = aVuelo.NoVuelo;
                dtfecha.Value = aVuelo.Fecha;
                aCiudad = ListaCiudades.FirstOrDefault(c => c.id == aVuelo.idCiudad);
                if (aCiudad != null)
                    cbciudades.SelectedItem = aCiudad;
                
                Cargar_Guias();
            }
        }

        public void Limpiar()
        {
            txtnumerovuelo.Text = "";
            dtfecha.Value = DateTime.Today;
            dgguias.DataSource = null;
            dgdistribucion.DataSource = null;
        }

        private void Cargar_Ciudades()
        {
            ListaCiudades = null;
            aCiudad = null;
           using (DBPickiuEntities db = new DBPickiuEntities())
           {
              ListaCiudades = db.Ciudades.OrderBy(c => c.Nombre).ToList();               
              cbciudades.DataSource = ListaCiudades;
              if (ListaCiudades.Count != 0)
              {
                 aCiudad = ListaCiudades.FirstOrDefault();
                 if(aCiudad!=null) 
                    cbciudades.SelectedItem = aCiudad;
              }
           }
        }

        private void Cargar_Guias()
        {
            dgguias.AutoGenerateColumns = false;
            ListaGuias = new List<Guias>();
            using (DBPickiuEntities db = new DBPickiuEntities()) 
            {
                cbCliente.DataSource = db.Clientes.ToList();
                if (aVuelo != null)
                {
                    ListaGuias = db.Guias.Where(g => g.idVuelo == aVuelo.id).OrderBy(g=>g.numero).ToList();
                    dgguias.DataSource =new BindingList<Guias>(ListaGuias);                    
                }               
                
                Cargar_Distribucion(); 
            }
        }       

        private void Cargar_Distribucion()
        {
            dgdistribucion.AutoGenerateColumns = false;
            ListaDistribucion = new List<Pickiu>();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                cbflores.DataSource = db.Flores.ToList();
                Cargar_Origenes();
                if (aGuia != null)
                {
                    ListaDistribucion = db.Pickiu.Where(p => p.idGuia == aGuia.id).ToList();
                    dgdistribucion.DataSource = new BindingList<Pickiu>(ListaDistribucion);
                }
            }
            //using()
                      
        }

        private void Cargar_Origenes()
        { 
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                if (aCiudad != null)
                    cborigen.DataSource = db.Origenes.Where(o => o.idCiudad == aCiudad.id).ToList();                 
            }
        }

        private void cbciudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCiudad = cbciudades.SelectedItem as Ciudades;
            Cargar_Origenes();
        }
    }
}
