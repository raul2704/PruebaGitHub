using DevExpress.XtraEditors;
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
    public partial class FReportes : DevExpress.XtraEditors.XtraForm
    {

        public FReportes()
        {
            InitializeComponent();
        }

        public void Cargar_Reporte_Distribucion()
        {
            Report_Distribucion Reporte = new Report_Distribucion();
            documentViewer1.DocumentSource = Reporte;
            Reporte.CreateDocument();
        }
    }
}