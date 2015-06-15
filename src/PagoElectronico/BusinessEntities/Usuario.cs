using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Usuario
    {
        #region Atributos y Propiedades

        public int Usuario_ID { get; set; }
        public String Usuario_Username { get; set; }
        public String Usuario_Password { get; set; }
        public DateTime Usuario_Fecha_Creacion { get; set; }
        public DateTime Usuario_Fecha_Ultima_Modif { get; set; }
        public String Usuario_Pregunta_Secreta { get; set; }
        public String Usuario_Respuesta_Secreta { get; set; }
        public bool Usuario_Estado { get; set; }
        public int Usuario_Cantidad_Intentos { get; set; }

        #endregion

        #region Constructor

        public Usuario(String username, String password)
        {
            Usuario_Username = username;
            Usuario_Password = password;
        }

        public Usuario(String username, String password, String pregunta_secreta, String respuesta_secreta)
        {
            Usuario_Username = username;
            Usuario_Password = password;
            Usuario_Pregunta_Secreta = pregunta_secreta;
            Usuario_Respuesta_Secreta = respuesta_secreta;
        }

        public Usuario()
        {
        }

        #endregion
    }
}
