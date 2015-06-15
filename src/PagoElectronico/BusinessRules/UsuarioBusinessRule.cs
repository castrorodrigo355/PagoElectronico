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
                resultado = oUsuarioDALC.Eliminar(idUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resultado;
        }

        public int RegistrarUsuario(String username, String password, String pregunta, String respuesta)
        {
            Usuario oUsuario = null;
            UsuarioDALC oUsuarioDALC = new UsuarioDALC();
            int resultado = 0;

            try
            {
                //Creo la entidad de negocio Usuario
                oUsuario = new Usuario(username, EncriptarPassword(password), pregunta, EncriptarPassword(respuesta));

                //Registro el nuevo usuario
                resultado = oUsuarioDALC.Insertar(oUsuario);
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

        private String EncriptarPassword(String password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] hashedPassword = sha256.ComputeHash(passwordBytes);
            return BitConverter.ToString(hashedPassword).Replace("-","");
        }

        #endregion

    }
}
