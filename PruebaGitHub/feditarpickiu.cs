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
        Guias aGuia = null;                
        List<Ciudades> ListaCiudades = null;
        List<Clientes> ListaClientes = null;
        List<Flores> ListaFlores = null;
        List<Origenes> ListaOrigenes = null;
        List<Pickiu> ListaDistribucion = null;
        List<Guias> ListaGuias = null;
        public feditarpickiu()
        {
           InitializeComponent();          
        }
       
        private void feditarpickiu_Load(object sender, EventArgs e)
        {
                      
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
                    if (aCiudad != null)
                        cbciudades.SelectedItem = aCiudad;
                }
            }
        }  
        
        private void Cargar_Clientes()
        {
            ListaClientes = new List<Clientes>();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
              ListaClientes = db.Clientes.ToList(); 
              cbCliente.DataSource = ListaClientes;               
            }
        }

        private void Cargar_Flores()
        {
            ListaFlores = new List<Flores>();
            using(DBPickiuEntities db=new DBPickiuEntities())
            {
              ListaFlores=db.Flores.ToList();
              cbflores.DataSource = ListaFlores;                
            }
        }

        private void Cargar_Origenes()
        {
            ListaOrigenes = new List<Origenes>();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                if (aCiudad != null)
                    ListaOrigenes = db.Origenes.Where(o => o.idCiudad == aCiudad.id).ToList();
                cborigen.DataSource = ListaOrigenes;
            }
        }

        public void Cargar_Datos(int idvuelo=0)
        {
            Cargar_Ciudades();
            Cargar_Clientes();
            Cargar_Flores();
            Cargar_Origenes();
            Limpiar();
            using (DBPickiuEntities db = new DBPickiuEntities())
            {
                if (idvuelo == 0)
                {
                    aVuelo = new Vuelos { id = 0, NoVuelo = "", Fecha = DateTime.Today };
                    if (aCiudad != null)
                        aVuelo.idCiudad = aCiudad.id;
                }
                else
                    aVuelo = db.Vuelos.FirstOrDefault(v => v.id == idvuelo);
                                
                txtnumerovuelo.Text = aVuelo.NoVuelo;
                dtfecha.Value = aVuelo.Fecha;
                cbciudades.SelectedValue =aVuelo.idCiudad;
                //if (aCiudad != null)
                //    cbciudades.SelectedItem = aCiudad;
                
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

        private void Cargar_Guias()
        {
            aGuia = null;
            dgguias.AutoGenerateColumns = false;
            ListaGuias = new List<Guias>();
            using (DBPickiuEntities db = new DBPickiuEntities()) 
            {
                if (aVuelo != null)
                {
                    ListaGuias = db.Guias.Where(g => g.idVuelo == aVuelo.id).OrderBy(g=>g.id).ToList();
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
                if (aGuia != null)
                {
                   ListaDistribucion = db.Pickiu.Where(p => p.idGuia == aGuia.id).ToList();
                   dgdistribucion.DataSource = new BindingList<Pickiu>(ListaDistribucion);
                }
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
                   aVuelo.id=db.Agregar_Vuelo(txtnumerovuelo.Text, dtfecha.Value, aCiudad);
               else
                  db.Modificar_Vuelo(aVuelo.id, txtnumerovuelo.Text, dtfecha.Value, aCiudad);
            
               //Guias------------------------------------------------------
               foreach(Guias g in ListaGuias)
               {
                  if (g.Estado == estado.agregado)
                      db.Agregar_Guia(g.numero, g.idCliente, aVuelo.id);
                  if (g.Estado == estado.modificado)
                      db.Modificar_Guia(g.id, g.numero, g.idCliente);
               }            
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgguias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (aGuia != null)
            {
               if(aGuia.id == 0)
                  aGuia.Estado = estado.agregado;
               else
                  aGuia.Estado = estado.modificado;               
            }
        }

        private void dgguias_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if(Validate())
               Guardar_Guia_Local();
        }
        private void Guardar_Guia_Local()
        {
               if (aGuia != null && aGuia.Estado==estado.agregado && aGuia.id==0)
               {
                  int idg = 1;
                  if (ListaGuias != null)
                  {
                     Guias guiatemp = ListaGuias.LastOrDefault(g => g.id != 0);
                     if (guiatemp != null)
                         idg = guiatemp.id + 1;
                  }
                  aGuia.id = idg;                                 
               }                   
           
        }

        private void dgdistribucion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Exception!=null && e.Context == DataGridViewDataErrorContexts.Display)
            {
               e.Cancel = true;
            }
        }

        private void dgguias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Display)
            {
                e.Cancel = true;
            }
        }
    }
}
