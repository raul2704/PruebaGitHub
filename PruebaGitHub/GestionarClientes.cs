using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace PruebaGitHub
{
    public partial class GestionarClientes : DevExpress.XtraEditors.XtraUserControl
    {
        DBPickiuEntities db = null;
        Clientes cliente = null;

        public GestionarClientes()
        {
           InitializeComponent();
          
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }  
        
        public void Cargar_Datos()
        {
            db = new DBPickiuEntities();
            db.Clientes.Load();
            var lstclientes = db.Clientes.ToList();
            gcclientes.DataSource = new BindingList<Clientes>(lstclientes.ToList());

        }

        private void gvclientes_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
           if (cliente != null)
           {
             if (cliente.id == 0)
                 db.Clientes.Add(cliente);
             db.SaveChanges();
           }           
        }

        private void gvclientes_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            cliente = gvclientes.GetFocusedRow() as Clientes;
        }

        private void gvclientes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            cliente = gvclientes.GetFocusedRow() as Clientes;
        }
    }
}
