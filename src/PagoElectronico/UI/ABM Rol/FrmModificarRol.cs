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
    public partial class FrmModificarRol : Form
    {
        private Rol oRol;

        public FrmModificarRol(Rol oRol)
        {
            this.oRol = oRol;
            InitializeComponent();
        }

        private void FrmModificarRol_Load(object sender, EventArgs e)
        {
            MostrarInformacionRol();
            CargarListaFuncionalidades();
        }

        private void MostrarInformacionRol()
        {
            this.txtNombreRol.Text = oRol.Descripcion;
            this.chkHabilitado.Checked = oRol.Estado;
        }

        private void CargarListaFuncionalidades()
        {
            RolesUsuarioBusinessRule oRolesBR = new RolesUsuarioBusinessRule();
            chkListFuncionalidades.DataSource = oRolesBR.ObtenerFuncionalidades();
            chkListFuncionalidades.ValueMember = "Funcionalidad_ID";
            chkListFuncionalidades.DisplayMember = "Funcionalidad_Nombre";

        }

        private List<Funcionalidad> CargarFuncionalidadesAsignadas()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            foreach (DataRowView dr in chkListFuncionalidades.Items)
            {
                Funcionalidad oFuncionalidad = new Funcionalidad();
                oFuncionalidad.ID = Convert.ToInt32(dr[0]);
                oFuncionalidad.Descripcion = dr[1].ToString();
                funcionalidades.Add(oFuncionalidad);
            }

            return funcionalidades;
        }
        private void btnModificarRol_Click(object sender, EventArgs e)
        {

            Rol oRolModificado = new Rol();
            oRolModificado.Estado = chkHabilitado.Checked;
            oRolModificado.Descripcion = txtNombreRol.Text;
            oRolModificado.Funcionalidades = CargarFuncionalidadesAsignadas();
            oRolModificado.ID = this.oRol.ID;

            RolesUsuarioBusinessRule oRolesBR = new RolesUsuarioBusinessRule();
            oRolesBR.ActualizarRol(oRolModificado);
        }

    }
}
