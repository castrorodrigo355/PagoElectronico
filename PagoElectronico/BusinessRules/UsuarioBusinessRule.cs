using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.BusinessEntities;
using PagoElectronico.DALC;
using System.Security.Cryptography;
using PagoElectronico.UI.Login;

namespace PagoElectronico.BusinessRules
{
    class UsuarioBusinessRule
    {
        #region Metodos públicos

        public int bajaUsuario(int idUsuario)
        {
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();
            int resultado = 0;

            try
            {
                resultado = oUsuarioDALC.delete(idUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resultado;
        }

        public int registrarUsuario(String username, String password)
        {
            Usuario oUsuario = null;
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();
            int resultado = 0;

            try
            {
                //Creo la entidad de negocio Usuario
                oUsuario = new Usuario(username, password);

                //Registro el nuevo usuario
                resultado = oUsuarioDALC.insert(oUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return resultado;

        }

        public bool esUsuarioValido(String nombre_usuario, String password)
        {
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();
         
            if (oUsuarioDALC.validarUsuario(nombre_usuario, encriptarPassword(password))){
                return true;
            }
            return false;
        }

        #endregion

        #region Metodos privados

        private byte[] encriptarPassword(String password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA1 sha256 = new SHA1CryptoServiceProvider();
            byte[] hashedPassword = sha256.ComputeHash(passwordBytes);

            return hashedPassword;
        }

        #endregion


    }
}
