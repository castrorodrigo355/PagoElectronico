using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.UI.Login;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.BusinessRules
{
    class AdministradorRoles
    {

        #region Constructor

        public AdministradorRoles()
        {
        }

        #endregion

        public void procesarRoles()
        {
            if (Sesion.Roles.Count == 2)
            {
                frmSeleccionRol frmSeleccionRol = new frmSeleccionRol();
                frmSeleccionRol.Show();
            }
            else { 
                if (Sesion.Roles.Exists(rol => rol.Descripcion.Equals("Cliente")))
                {
                    frmCliente frmCliente = new frmCliente();
                    frmCliente.Show();
                }
            }
        }
    }
}
