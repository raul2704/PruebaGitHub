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
            //db.Clientes.Load();
            var lstclientes = db.Clientes.ToList();
            gcclientes.DataSource = new BindingList<Clientes>(lstclientes);

        }

        private void gvclientes_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                if (cliente != null)
                    db.Guardar_Cliente(cliente);
            }catch(Exception ex)
            {
                MessageBox.Show("No fue posible guardar los datos actuales, error: " + ex.Message);
            }
                      
        }

        private void gvclientes_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           cliente = gvclientes.GetFocusedRow() as Clientes;
           cliente.fecha_Update = DateTime.Now;
           //gvclientes.SetFocusedRowCellValue("fecha_Update", DateTime.Now);
        }

        private void gvclientes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           cliente = gvclientes.GetFocusedRow() as Clientes;
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void baredit_ItemClick(object sender, ItemClickEventArgs e)
        {
            FEditarCliente feditar = new FEditarCliente();
            feditar.Cargar_Datos(cliente.id);
            feditar.Show();

        }

        private void gvclientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Eliminar_Cliente();
                gvclientes.RefreshData();
            }
        }

        private void Eliminar_Cliente()
        {
            if (cliente != null)
            {
                DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el Cliente actual", "Mensaje de Interrogación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (db.Eliminar_Cliente(cliente.id))
                    {
                        MessageBox.Show("Se eliminó el Cliente correctamente", "Confirmación de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No se puedo eliminar el Cliente actual", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gvclientes_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gvclientes.PostEditor();
            gvclientes.UpdateCurrentRow();
        }

        private void gvclientes_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            cliente.fecha_Update = DateTime.Now;
        }

        private void gcclientes_Click(object sender, EventArgs e)
        {

        }
    }
}
