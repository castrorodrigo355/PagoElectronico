using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;

namespace PagoElectronico.UI.ABM_Cuenta
{
    public partial class FrmABMCuenta : Form
    {
        public FrmABMCuenta()
        {
            InitializeComponent();
        }

        private void FrmABMCuenta_Load(object sender, EventArgs e)
        {
            InicializarGrilla();
            CargarGrilla();
            dgvCuentas.ClearSelection();
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
                btnModificarCuenta.Enabled = true;
                btnDarBajaCuenta.Enabled = true;
            }
            if (dgvCuentas.SelectedRows.Count == 0)
            {
                btnModificarCuenta.Enabled = false;
                btnDarBajaCuenta.Enabled = false;
            }
        }


    }
}
