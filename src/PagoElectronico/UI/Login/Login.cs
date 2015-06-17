using System;
using System.Windows.Forms;
using PagoElectronico.configuracion;
using PagoElectronico.BusinessRules;
using PagoElectronico.BusinessEntities;
using PagoElectronico.UI.Login;
using PagoElectronico.Exceptions;
using System.Collections.Generic;

namespace PagoElectronico.login
{
    public partial class Login : Form
    {
        #region Metodos protegidos

        protected bool FormularioValido()
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
            if (this.FormularioValido())
            {
                UsuarioBusinessRule oUsuarioBR = new UsuarioBusinessRule();
                try
                {
                    //Valido Usuario y Contraseña
                    if (oUsuarioBR.EsUsuarioValido(txtNombreUsuario.Text, txtPassword.Text))
                    {
                        //Ahora tengo que buscar los roles que tiene dicho usuario y mostrar los formularios correspondientes
                        RolesUsuarioBusinessRule oRolesUsuarioBR = new RolesUsuarioBusinessRule();
                        oRolesUsuarioBR.ObtenerRolesUsuario(Sesion.SesionActual.Usuario_ID);
                        
                        //Obtengo el cliente unico para este usuario
                        ClienteBusinessRule oClienteBR = new ClienteBusinessRule();
                        oClienteBR.ObtenerCliente(169);
                        
                        //Oculto el panel de login y muestro el correspondiente al rol del usuario
                        this.Hide();
                        AdministradorRoles administradorRoles = new AdministradorRoles();
                        administradorRoles.procesarRoles();
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

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no se encuentra implementada aún. Por favor contacte a su Administrador si desea dar de alta un usuario.","No disponible", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
               

    }
}
