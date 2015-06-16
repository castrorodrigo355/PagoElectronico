using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessEntities;
using PagoElectronico.BusinessRules;

namespace PagoElectronico.UI.ABM_Rol
{
    public partial class FrmAltaRol : Form
    {
        public FrmAltaRol()
        {
            InitializeComponent();
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            if (FormularioValido())
            {
                RolesUsuarioBusinessRule oRolesBR = new RolesUsuarioBusinessRule();
                int rolID = oRolesBR.RegistrarRol(txtNombreRol.Text, chkHabilitado.Checked, CargarFuncionalidadesAsignadas());

                if (rolID != 0)
                {
                    MessageBox.Show("Se dio de alta satisfactoriamente");
                    this.LimpiarCampos();
                    this.Hide();
                }
            }
        }

        private void LimpiarCampos()
        {
            this.txtNombreRol.Clear();
            this.chkHabilitado.Checked = false;
            this.lstFuncionalidadesAsignadas.Items.Clear();
        }

        private bool FormularioValido()
        {
            return true;
        }

        private List<Funcionalidad> CargarFuncionalidadesAsignadas()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            foreach (DataRowView dr in lstFuncionalidadesAsignadas.Items)
            {
                Funcionalidad oFuncionalidad = new Funcionalidad();
                oFuncionalidad.ID = Convert.ToInt32(dr[0]);
                oFuncionalidad.Descripcion = dr[1].ToString();
                funcionalidades.Add(oFuncionalidad);
            }

            return funcionalidades;
        }

        private void FrmAltaRol_Load(object sender, EventArgs e)
        {
            CargarListaFuncionalidades();
        }

        private void CargarListaFuncionalidades()
        {
            RolesUsuarioBusinessRule oRolesBR = new RolesUsuarioBusinessRule();
            lstFuncionalidadesDisponibles.DataSource = oRolesBR.ObtenerFuncionalidades();
            lstFuncionalidadesDisponibles.ValueMember = "Funcionalidad_ID";
            lstFuncionalidadesDisponibles.DisplayMember = "Funcionalidad_Nombre";

            lstFuncionalidadesAsignadas.ValueMember = "Funcionalidad_ID";
            lstFuncionalidadesAsignadas.DisplayMember = "Funcionalidad_Nombre";

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (lstFuncionalidadesDisponibles.SelectedItem != null)
            {
                if (!lstFuncionalidadesAsignadas.Items.Contains(lstFuncionalidadesDisponibles.SelectedItem))
                    lstFuncionalidadesAsignadas.Items.Add(lstFuncionalidadesDisponibles.SelectedItem);
            }

            lstFuncionalidadesDisponibles.SelectedItems.Clear();

        }


    }
}
