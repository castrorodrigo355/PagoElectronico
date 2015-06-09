using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.UI.ABM_Cliente
{
    public partial class AltaCliente : Form
    {
        #region Metodos protegidos

        protected bool formularioValido()
        {
            epValidador.Clear();

            if (txtNombreUsuario.Text == String.Empty)
            {
                epValidador.SetError(txtNombreUsuario, "");
                MessageBox.Show("Debe ingresar el nombre de usuario", "Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreUsuario.Focus();
            }

            if (txtNombreUsuario.Text.Length > 40)
            {
            }

            return true;
        }

        #endregion


        public AltaCliente()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
