using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Sesion
    {
        public static Usuario SesionActual { get; set; }

        public static Usuario GetUsuarioActual()
        {
            return SesionActual;
        }
    }
}
