using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.UI.ABM_Cliente;
using PagoElectronico.UI.ABM_Rol;
using PagoElectronico.UI.ABM_Cuenta;
using PagoElectronico.UI.Consulta_Saldos;
using PagoElectronico.UI.Facturacion;
using PagoElectronico.UI.Listados;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.UI.Login
{
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
            this.FormClosed += CerrarFormulario;
            
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            FrmABMCliente frm = new FrmABMCliente();
            frm.Show();
        }

        private void btnABMRol_Click(object sender, EventArgs e)
        {
            FrmABMRol frm = new FrmABMRol();
            frm.Show();
        }

        private void btnABMClientes_Click(object sender, EventArgs e)
        {
            FrmABMCliente frm = new FrmABMCliente();
            frm.Show();
        }

        private void btnABMCuenta_Click(object sender, EventArgs e)
        {
            FrmABMCuenta frm = new FrmABMCuenta();
            frm.Show();
        }

        private void btnConsultaSaldos_Click(object sender, EventArgs e)
        {
            FrmConsultaSaldo frm = new FrmConsultaSaldo();
            frm.Show();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            FrmFacturacion frm = new FrmFacturacion();
            frm.Show();
        }

        private void btnListadoEstadistico_Click(object sender, EventArgs e)
        {
            FrmListadoEstadistico frm = new FrmListadoEstadistico();
            frm.Show();
        }

        private void CerrarFormulario(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            HabilitarFuncionalidades();
        }

        private void HabilitarFuncionalidades()
        {
            btnABMCuenta.Enabled = false;
            btnABMRol.Enabled = false;
            btnConsultaSaldos.Enabled = false;
            btnFacturacion.Enabled = false;
            btnListadoEstadistico.Enabled = false;
            btnABMClientes.Enabled = false;

            foreach (Rol oRol in Sesion.Roles)
            {
                if (oRol.Descripcion.Equals("Administrador"))
                {
                    foreach (Funcionalidad oFuncionalidad in oRol.Funcionalidades)
                    {
                        if (oFuncionalidad.Descripcion.Equals("ABM de Cliente"))
                        {
                            btnABMClientes.Enabled = true;
                        }
                        if (oFuncionalidad.Descripcion.Equals("ABM de Rol"))
                        {
                            btnABMRol.Enabled = true;
                        }
                        if (oFuncionalidad.Descripcion.Equals("ABM de Cuenta"))
                        {
                            btnABMCuenta.Enabled = true;
                        }
                        if (oFuncionalidad.Descripcion.Equals("Listado Estadistico"))
                        {
                            btnListadoEstadistico.Enabled = true;
                        }
                        if (oFuncionalidad.Descripcion.Equals("Facturacion de costos"))
                        {
                            btnFacturacion.Enabled = true;
                        }
                        if (oFuncionalidad.Descripcion.Equals("Consulta de saldos"))
                        {
                            btnConsultaSaldos.Enabled = true;
                        }
                    }
                }
            }
        }

    }
}
