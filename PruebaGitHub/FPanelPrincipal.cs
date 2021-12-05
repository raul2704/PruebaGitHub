﻿using System;
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
    public partial class FPanelPrincipal : Form
    {
        ControlPickiu cpickiu = null;
        ControlOrigenes corigenes = null;
        GestionarClientes cgestionarclientes = null;
        public FPanelPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btngestionarorigen_Click(object sender, EventArgs e)
        {
          Mostrar_Gestionar_Origen();
        }

        private void Mostrar_Gestionar_Origen()
        {
            foreach(Control c in panelcontenedor.Controls)
                    c.Hide();
            corigenes = panelcontenedor.Controls.OfType<ControlOrigenes>().FirstOrDefault();
            if (corigenes == null)
            {
              corigenes = new ControlOrigenes();
              corigenes.Dock = DockStyle.Left;
              panelcontenedor.Controls.Add(corigenes);
            }
            corigenes.Show();
            corigenes.BringToFront();            
        }

        private void btngestionarpickiu_Click(object sender, EventArgs e)
        {
          Mostra_Gestionar_Pickiu();
        }

        private void Mostra_Gestionar_Pickiu()
        {
            foreach (Control c in panelcontenedor.Controls)
                c.Hide();
            cpickiu = panelcontenedor.Controls.OfType<ControlPickiu>().FirstOrDefault();
            if (cpickiu == null)
            {
                cpickiu = new ControlPickiu();
                cpickiu.Dock = DockStyle.Fill;
                panelcontenedor.Controls.Add(cpickiu);
            }
            cpickiu.Show(); 
            cpickiu.BringToFront();
        }

        private void btngestionarcliente_Click(object sender, EventArgs e)
        {
            Mostra_Gestionar_Clientes();
        }

        private void Mostra_Gestionar_Clientes()
        {
            foreach (Control c in panelcontenedor.Controls)
                c.Hide();
            cgestionarclientes = panelcontenedor.Controls.OfType<GestionarClientes>().FirstOrDefault();
            if (cgestionarclientes == null)
            {
                cgestionarclientes = new GestionarClientes();
                cgestionarclientes.Dock = DockStyle.Fill;
                panelcontenedor.Controls.Add(cgestionarclientes);
            }
            cgestionarclientes.Show();
            cgestionarclientes.BringToFront();
        }
    }
}
