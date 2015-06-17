using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.UI.ABM_Rol
{
    public partial class FrmABMRol : Form
    {
        public FrmABMRol()
        {
            InitializeComponent();
            this.Activated += Actualizar_Grilla;
        }

        private void FrmABMRol_Load(object sender, EventArgs e)
        {
            InicializarGrilla();
            CargarGrilla();
            dgvRoles.ClearSelection();
        }

        private void CargarGrilla()
        {
            RolesUsuarioBusinessRule oRolesBR = new RolesUsuarioBusinessRule();
            dgvRoles.DataSource = oRolesBR.ObtenerRoles();
        }

        private void InicializarGrilla()
        {
            dgvRoles.ReadOnly = true;
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToResizeRows = false;
            dgvRoles.AllowUserToOrderColumns = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.MultiSelect = false;
            dgvRoles.RowStateChanged += SeleccionRol;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SeleccionRol(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                btnModificarRol.Enabled = true;
                btnInhabilitarRol.Enabled = true;
            }
            if (dgvRoles.SelectedRows.Count == 0)
            {
                btnModificarRol.Enabled = false;
                btnInhabilitarRol.Enabled = false;
            }
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            FrmAltaRol frmAltaRol = new FrmAltaRol();
            frmAltaRol.Show();
        }

        private void Actualizar_Grilla(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            Rol oRol = new Rol();
            foreach (DataGridViewRow dr in dgvRoles.SelectedRows) 
            {
                oRol.ID = Convert.ToInt32(dr.Cells[0].Value);
                oRol.Descripcion = Convert.ToString(dr.Cells[1].Value);
                oRol.Estado = Convert.ToBoolean(dr.Cells[2].Value);
            }

            FrmModificarRol frmModificarRol = new FrmModificarRol(oRol);
            frmModificarRol.Show();
        }
    }
}
