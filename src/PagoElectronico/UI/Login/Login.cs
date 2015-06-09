using System;
using System.Windows.Forms;
using PagoElectronico.configuracion;
using PagoElectronico.BusinessRules;
using PagoElectronico.BusinessEntities;
using PagoElectronico.UI.Login;
using PagoElectronico.Exceptions;

namespace PagoElectronico.login
{
    public partial class Login : Form
    {
        #region Metodos protegidos

        protected bool formularioValido()
        {
            if (txtNombreUsuario.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre de usuario para continuar", "Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una contraseña", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        #endregion

        #region Metodos privados

        private void insertarUsuario()
        {
            UsuarioBusinessRule oUsuarioBR = new UsuarioBusinessRule();
            oUsuarioBR.registrarUsuario("pepe", "pepito");
        }

        private void leerArchivoConfiguracion()
        {
            Configuracion config = new Configuracion();
            config.leearArchivoConfiguracion();
        }

        #endregion

        #region Constructor

        public Login()
        {
            InitializeComponent();
            leerArchivoConfiguracion();
        }

        #endregion

        #region Eventos

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Valido que los campos ingresados sean correctos
            if (this.formularioValido())
            {
                UsuarioBusinessRule oUsuarioBR = new UsuarioBusinessRule();

                try
                {
                    //Valido Usuario y Contraseña
                    if (oUsuarioBR.esUsuarioValido(txtNombreUsuario.Text, txtPassword.Text))
                    {
                        //Ahora tengo que buscar los roles que tiene dicho usuario y mostrar los formularios correspondientes
                        this.Hide();
                        frmSeleccionRol frmRol = new frmSeleccionRol();
                        frmRol.Show();
                    }
                }
                catch (UsuarioDeshabilitadoException e1)
               { 
                    MessageBox.Show("Usuario deshabilitado");
                }
                catch (PasswordIncorrectaException e2)
                {
                    MessageBox.Show("Password incorrecta");
                }
                catch (UsuarioInexistenteException e3)
                {
                    MessageBox.Show("Usuario inexistente");
                }

            }
        }

        #endregion

    }
}
