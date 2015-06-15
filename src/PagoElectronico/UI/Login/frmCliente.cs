using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessEntities;
using System.Reflection;
using PagoElectronico.UI.ABM_Cliente;
using PagoElectronico.UI.ABM_Rol;
using PagoElectronico.UI.Depositos;
using PagoElectronico.UI.Retiros;
using PagoElectronico.UI.Transferencias;
using PagoElectronico.UI.ABM_Cuenta;
using PagoElectronico.UI.Facturacion;
using PagoElectronico.UI.Consulta_Saldos;

namespace PagoElectronico.UI.Login
{
    public partial class frmCliente : Form
    {


        #region Constructor

        public frmCliente()
        {
            InitializeComponent();
        }
        #endregion


        #region Eventos

        private void btnABMCuenta_Click(object sender, EventArgs e)
        {
            FrmABMCuenta frm = new FrmABMCuenta();
            frm.Show();
        }

        private void btnDepositos_Click(object sender, EventArgs e)
        {
            FrmDepositos frm = new FrmDepositos();
            frm.Show();
        }

        private void btnRetirosEfectivo_Click(object sender, EventArgs e)
        {
            FrmRetiros frm = new FrmRetiros();
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

        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            FrmTransferencias frm = new FrmTransferencias();
            frm.Show();
        }

        #endregion

    }
}
