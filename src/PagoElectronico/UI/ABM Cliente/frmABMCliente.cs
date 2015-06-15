using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;
using PagoElectronico.DALC;

namespace PagoElectronico.UI.ABM_Cliente
{
    public partial class FrmABMCliente : Form
    {
        #region Constructor
 
        public FrmABMCliente()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos privados

        private void CargarGrilla()
        {
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToOrderColumns = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClienteBusinessRule oClienteBR = new ClienteBusinessRule();
            dgvClientes.DataSource = oClienteBR.ObtenerClientes();
        }

        #endregion

        #region Eventos

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente frmAlta = new FrmAltaCliente();
            frmAlta.Show();
        }

        #endregion

    }
}
