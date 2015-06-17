using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;
using PagoElectronico.Exceptions;

namespace PagoElectronico.UI.ABM_Cuenta
{
    public partial class FrmAltaCuenta : Form
    {
        public FrmAltaCuenta()
        {
            InitializeComponent();
        }

        private void FrmAltaCuenta_Load(object sender, EventArgs e)
        {
            InicializarGrilla();
            CargarGrilla();
            CargarCombos();
        }

        private void CargarGrilla()
        {
            ClienteBusinessRule oClienteBR = new ClienteBusinessRule();
            dgvClientes.DataSource = oClienteBR.ObtenerClientes();
        }

        private void InicializarGrilla()
        {
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToOrderColumns = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.MultiSelect = false;
            dgvClientes.RowStateChanged += SeleccionCliente;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarCombos()
        {
            CommonBusinessRule oCommonBR = new CommonBusinessRule();

            try
            {
                //Limpio el combo
                cmbTipoCuenta.Items.Clear();

                //Busco los paises en la base
                DataTable dtTipoCuenta = oCommonBR.BuscarTiposCuenta();

                if (dtTipoCuenta.Rows.Count > 0)
                {
                    cmbTipoCuenta.DataSource = dtTipoCuenta.DefaultView;
                    cmbTipoCuenta.ValueMember = "Tipo_Cuenta_ID";
                    cmbTipoCuenta.DisplayMember = "Tipo_Cuenta_Descr";
                }

            }
            catch (Exception ex)
            {
                throw new BaseDatosException();
            }

        }

        private void SeleccionCliente(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                grpAltaCuenta.Enabled = true;
            }
            if (dgvClientes.SelectedRows.Count == 0)
            {
                grpAltaCuenta.Enabled = false;
            }
        }

    }
}
