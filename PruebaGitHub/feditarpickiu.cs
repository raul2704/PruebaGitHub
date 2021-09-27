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
            Limpiar();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                if (idvuelo == 0) 
                {
                   aVuelo = new Vuelos { id = 0, NoVuelo = "", Fecha = DateTime.Today }; 
                   if (aCiudad != null)
                      aVuelo.Ciudades = aCiudad;                   
                }
                else
                    aVuelo = db.Vuelos.FirstOrDefault(v => v.id == idvuelo);
                                
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
                 //if(aCiudad!=null) 
                 //  cbciudades.SelectedItem = aCiudad;
              }
           }
        }

        private void Cargar_Guias()
        {
            aGuia = null;
            dgguias.AutoGenerateColumns = false;
            ListaGuias = new List<Guias>();
            using (DBPickiuEntities db = new DBPickiuEntities()) 
            {
                cbCliente.DataSource = db.Clientes.ToList();
                if (aVuelo != null)
                {
                    ListaGuias = db.Guias.Where(g => g.idVuelo == aVuelo.id).OrderBy(g=>g.numero).ToList();
                    dgguias.DataSource =new BindingList<Guias>(ListaGuias);
                    if (ListaGuias.Count > 0)
                        aGuia = ListaGuias.FirstOrDefault();
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
            ListaOrigenes = new List<Origenes>();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                if (aCiudad != null)
                    ListaOrigenes= db.Origenes.Where(o => o.idCiudad == aCiudad.id).ToList();
                cborigen.DataSource = ListaOrigenes;                 
            }
        }

        private void cbciudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCiudad = cbciudades.SelectedItem as Ciudades;
            if(aVuelo!=null && aCiudad!=null)
               aVuelo.Ciudades = aCiudad;
            Cargar_Origenes();
        }

        private void dgguias_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idg =Convert.ToInt32(dgguias.Rows[e.RowIndex].Cells[0].Value);
            aGuia = ListaGuias.FirstOrDefault(g => g.id == idg);
            Cargar_Distribucion();

        }

        private void dgguias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Display)
            {
               MessageBox.Show("");
            }
        }

        private void dgdistribucion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Display)
            {
               MessageBox.Show("");
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
              Guardar();
              DialogResult result=MessageBox.Show("Los valores se guardaron correctamente, Desea Continuar Modificando", "Mensaje de Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (result == DialogResult.No)
                 this.Close();
            }
            else
                MessageBox.Show("Antes de Guardar debe entrar un Número de Vuelo", "Error de Validación en la Acción Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private bool Validar()
        {
           return txtnumerovuelo.Text != "";
        }

        private void Guardar()
        {
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
               if (aVuelo.id == 0)
                  db.Agregar_Vuelo(txtnumerovuelo.Text, dtfecha.Value, aCiudad);
               else
                  db.Modificar_Vuelo(aVuelo.id, txtnumerovuelo.Text, dtfecha.Value, aCiudad);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgguias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgguias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(aGuia.id!=0)
               aGuia.Modificado = true;
        }

        private void dgguias_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void Guardar_Guia()
        {
            //if (aGuia.id == 0)
            //    ListaGuias.Add(aGuia);
            //else
                      
        }

        private void txtnumerovuelo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dtfecha_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
