﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.UI.Login
{
    public partial class frmSeleccionRol : Form
    {
        public frmSeleccionRol()
        {
            InitializeComponent();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdministrador frmAdmin = new frmAdministrador();
            frmAdmin.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCliente frmCliente = new frmCliente();
            frmCliente.Show();
        }


    }
}
