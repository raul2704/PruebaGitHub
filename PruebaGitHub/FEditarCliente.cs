using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaGitHub
{
    public partial class FEditarCliente : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DBPickiuEntities db = null;
        Clientes cliente = null;
        public FEditarCliente()
        {
           InitializeComponent();           
        } 

        public void Cargar_Datos(int idcliente)
        {
            db = new DBPickiuEntities();
            cliente = db.Clientes.FirstOrDefault(c=>c.id==idcliente);
            if (cliente != null)
            {
                phfoto.Image = cliente.Foto;
                //...
            }            
        }

        private void tablePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phfoto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phfoto_DoubleClick(object sender, EventArgs e)
        {
            if (ofdfoto.ShowDialog() == DialogResult.OK)
            {
                db.Modificar_Foto_Cliente(cliente, ofdfoto.FileName);
                phfoto.Image = cliente.Foto;               
            }
        }
    }
}