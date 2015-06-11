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
                oUsuario = new Usuario(username, EncriptarPassword(password));

                //Registro el nuevo usuario
                resultado = oUsuarioDALC.insert(oUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return resultado;

        }

        public bool EsUsuarioValido(String nombre_usuario, String password)
        {
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();
            return oUsuarioDALC.ValidarUsuario(nombre_usuario, EncriptarPassword(password));
        }

        #endregion

        #region Metodos privados

        private byte[] EncriptarPassword(String password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] hashedPassword = sha256.ComputeHash(passwordBytes);
           // Console.WriteLine(BitConverter.ToString(hashedPassword).Replace("-",""));
            return hashedPassword;
        }

        #endregion



        public List<Rol> RolesUsuario(int usuarioID)
        {
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();

            return new List<Rol>();

        }
    }
}
