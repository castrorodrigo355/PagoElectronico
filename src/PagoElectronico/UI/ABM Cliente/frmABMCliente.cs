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
using PagoElectronico.Exceptions;

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
            ClienteBusinessRule oClienteBR = new ClienteBusinessRule();
            dgvClientes.DataSource = oClienteBR.ObtenerClientes();
        }

        #endregion

        #region Eventos

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {
            InicializarGrilla();
            CargarGrilla();
            CargarCombos();
            dgvClientes.ClearSelection();
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
                cmbTipoDocFiltro.Items.Clear();

                //Busco los paises en la base
                DataTable dtTipoDocumentos = oCommonBR.BuscarTiposDocumentos();

                if (dtTipoDocumentos.Rows.Count > 0)
                {
                    cmbTipoDocFiltro.DataSource = dtTipoDocumentos.DefaultView;
                    cmbTipoDocFiltro.ValueMember = "Tipo_Documento_ID";
                    cmbTipoDocFiltro.DisplayMember = "Tipo_Documento_Desc";
                }

            }
            catch (Exception ex)
            {
                throw new BaseDatosException();
            }

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente frmAlta = new FrmAltaCliente();
            frmAlta.Show();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            FrmModificarCliente frmModificacion = new FrmModificarCliente();
            frmModificacion.Show();
        }

        private void SeleccionCliente(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                btnModificarCliente.Enabled = true;
                btnDarBaja.Enabled = true;
            }
            if (dgvClientes.SelectedRows.Count ==0)
            {
                btnModificarCliente.Enabled = false;
                btnDarBaja.Enabled = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataView filtroClientes = new DataView((DataTable)dgvClientes.DataSource);
            StringBuilder sb = new StringBuilder();

            if (txtFiltroNombre.Text != String.Empty)
                sb.Append("[Cliente_Nombre] LIKE " + "'" + "%" + txtFiltroNombre.Text +"%" + "'");

            if (txtFiltroApellido.Text != String.Empty){
                if (sb.Length > 0)
                    sb.Append(" AND ");
                sb.Append("[Cliente_Apellido] LIKE " + "'" + "%" + txtFiltroApellido.Text +"%" + "'");
            }

            if(cmbTipoDocFiltro.SelectedIndex != 0){
                if(sb.Length >0)
                    sb.Append(" AND ");
                sb.Append("[Cliente_Tipo_Doc_Cod] = " + cmbTipoDocFiltro.Text);
            }

            filtroClientes.RowFilter = sb.ToString();
            dgvClientes.DataSource = filtroClientes.ToTable();
        }


    }
}
