using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;

namespace PagoElectronico.UI.Depositos
{
    public partial class FrmDepositos : Form
    {
        public FrmDepositos()
        {
            InitializeComponent();
        }

        private void FrmDepositos_Load(object sender, EventArgs e)
        {

        }

        private void CargarGrilla()
        {
            CuentaBusinessRule oCuentaBR = new CuentaBusinessRule();
            dgvCuentas.DataSource = oCuentaBR.ObtenerCuentas();
        }

        private void InicializarGrilla()
        {
            dgvCuentas.ReadOnly = true;
            dgvCuentas.AllowUserToAddRows = false;
            dgvCuentas.AllowUserToResizeRows = false;
            dgvCuentas.AllowUserToOrderColumns = false;
            dgvCuentas.AllowUserToDeleteRows = false;
            dgvCuentas.MultiSelect = false;
            dgvCuentas.RowStateChanged += SeleccionCuenta;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SeleccionCuenta(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count > 0)
            {
                grpDeposito.Enabled = true; 
            }
            if (dgvCuentas.SelectedRows.Count == 0)
            {
                grpDeposito.Enabled = false;
            }
        }
    }
}
