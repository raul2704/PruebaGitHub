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
        public ControlPickiu()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void ControlPickiu_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
        private void Cargar_Datos()
        {
            using(DBPickiuEntities db=new DBPickiuEntities())
            {
                dgpickiu.DataSource = db.Lista_Pickiu();
            }
        }
    }
}
