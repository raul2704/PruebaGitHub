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
            cliente = db.Clientes.Find(idcliente);

            if (!string.IsNullOrEmpty(cliente.urlfoto))
                phfoto.Image = System.Drawing.Image.FromFile(cliente.urlfoto);

        }
      
           
    }
}