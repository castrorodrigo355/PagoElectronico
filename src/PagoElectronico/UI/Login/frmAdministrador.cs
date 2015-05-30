using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.UI.ABM_Cliente;

namespace PagoElectronico.UI.Login
{
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            EditarCliente frmEditarCliente = new EditarCliente();
            frmEditarCliente.Show();
        }

    }
}
