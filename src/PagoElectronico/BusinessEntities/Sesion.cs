using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Exceptions;

namespace PagoElectronico.BusinessEntities
{
    public class Sesion
    {
        public static Usuario SesionActual { get; set; }
        public static List<Rol> Roles { get; set; }
        public static Cliente Cliente { get; set; }

        public static Rol GetRolCliente()
        {
            foreach (Rol oRol in Roles)
            {
                if (oRol.Descripcion.Equals("Cliente"))
                    return oRol;
            }

            throw new RolDesconocidoException();
        }

        public static Rol getRolAdministrador()
        {
            foreach (Rol oRol in Roles)
            {
                if (oRol.Descripcion.Equals("Administrador"))
                    return oRol;
            }
            throw new RolDesconocidoException();
        }

    }
}
