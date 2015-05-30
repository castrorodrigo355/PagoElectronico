using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Usuario
    {
        #region Atributos y Propiedades

        public int IDUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public String PreguntaSecreta { get; set; }
        public byte[] RespuestaSecreta { get; set; }
        public String Estado { get; set; }
        public int CantidadIntentos { get; set; }

        #endregion

        #region Constructor

        public Usuario(String username, String password)
        {
            NombreUsuario = username;
            Password = password;
        }

        public Usuario()
        {
        }

        #endregion
    }
}
