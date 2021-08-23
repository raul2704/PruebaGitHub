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
        string NoVuelo = "";
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
                List<cgestionarpickiu> milista= db.Lista_Pickiu();
                if (NoVuelo != "")
                    milista = milista.Where(l => l.NoVuelo.Equals(NoVuelo)).ToList();
                //Otros filtros
                dgpickiu.DataSource = milista;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                NoVuelo = textBox2.Text;
                Cargar_Datos();
            }                
        }
    }
}
