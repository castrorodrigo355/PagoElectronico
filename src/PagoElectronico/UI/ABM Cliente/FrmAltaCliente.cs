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

namespace PagoElectronico.UI.ABM_Cliente
{
    public partial class FrmAltaCliente : Form
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

            if (txtPassword.Text == String.Empty)
            {
                epValidador.SetError(txtPassword, "");
                MessageBox.Show("Debe ingresar el password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }

            if (cmbPreguntaSecreta.SelectedText == String.Empty)
            {
                epValidador.SetError(cmbPreguntaSecreta, "");
                MessageBox.Show("Debe seleccionar una pregunta secreta", "Pregunta secreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbPreguntaSecreta.Focus();
            }

            if (txtNombres.Text == String.Empty)
            {
                epValidador.SetError(txtNombres, "");
                MessageBox.Show("Debe ingresar por lo menos un nombre correspondiente al cliente", "Nombre de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombres.Focus();
            }

            if (txtApellidos.Text == String.Empty)
            {
                epValidador.SetError(txtApellidos, "");
                MessageBox.Show("Debe ingresar un apellido", "Apellido de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellidos.Focus();
            }

            if (cmbTipoDocumento.Text == String.Empty)
            {
                epValidador.SetError(cmbTipoDocumento, "");
                MessageBox.Show("Debe seleccionar un tipo de documento", "Tipo de Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellidos.Focus();
            }

            if (txtDocumento.Text == String.Empty)
            {
                epValidador.SetError(txtDocumento, "");
                MessageBox.Show("Debe ingresar un documento", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDocumento.Focus();
            }
            if (txtNacionalidad.Text == String.Empty)
            {
                epValidador.SetError(txtNacionalidad, "");
                MessageBox.Show("Debe ingresar una nacionalidad", "Nacionalidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNacionalidad.Focus();
            }

            if (dtpFechaNacimiento.Text == String.Empty && dtpFechaNacimiento.Value.CompareTo(DateTime.Now).Equals(-1))
            {
                epValidador.SetError(dtpFechaNacimiento, "");
                MessageBox.Show("Debe seleccionar una fecha de nacimiento", "Fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaNacimiento.Focus();
            }

            if (txtCalle.Text == String.Empty)
            {
                epValidador.SetError(txtCalle, "");
                MessageBox.Show("Debe indicar una calle correspondiente al domicilio", "Calle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCalle.Focus();
            }

            if (txtPiso.Text != String.Empty)
            {
                int piso;
                if (!int.TryParse(txtPiso.Text, out piso))
                {
                    epValidador.SetError(txtPiso, "");
                    MessageBox.Show("Debe indicar un piso valido", "Piso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPiso.Focus();
                }

                if (txtDepto.Text == String.Empty || txtDepto.Text.Length > 2)
                {
                    epValidador.SetError(txtDepto, "");
                    MessageBox.Show("Debe indicar un departamento valido", "Departamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDepto.Focus();
                }
            }

            return true;
        }

        #endregion


        public FrmAltaCliente()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                UsuarioBusinessRule oUsuarioBR = new UsuarioBusinessRule();
                int usuarioID = oUsuarioBR.RegistrarUsuario(txtNombreUsuario.Text, txtPassword.Text, cmbPreguntaSecreta.SelectedText, txtRespuestaSecreta.Text);

                ClienteBusinessRule oClienteBR = new ClienteBusinessRule();
                oClienteBR.RegistrarNuevoCliente(txtNombres.Text, txtApellidos.Text, cmbTipoDocumento.SelectedValue, Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text,dtpFechaNacimiento.Value, txtNacionalidad.Text,txtMail.Text, txtCalle.Text, Convert.ToInt32(txtCalleNro.Text),Convert.ToInt32(txtPiso),txtDepto.Text, 0);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.txtNombres.Clear();
            this.txtApellidos.Clear();
            this.txtCalle.Clear();
            this.txtDepto.Clear();
            this.txtDocumento.Clear();
            this.txtLocalidad.Clear();
            this.txtPiso.Clear();
            this.txtRespuestaSecreta.Clear();
            this.txtNombreUsuario.Clear();
            this.chkAdministrador.Checked = false;
            this.chkCliente.Checked = false;
        }

    }
}
