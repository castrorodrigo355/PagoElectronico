using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.BusinessEntities;
using PagoElectronico.DALC;

namespace PagoElectronico.BusinessRules
{
    class RolesUsuarioBusinessRule
    {
        #region Metodos publicos

        //Solo va a mostrar los roles del usuario que se encuentren habilitados
        public void ObtenerRolesUsuario(int usuarioID)
        {
            RolDALC oRolDALC = new RolDALC();
            List<Rol> rolesUsuario = oRolDALC.ObtenerRolesUsuario(usuarioID);

            //Retorna los roles habilitados y los agrego a la sesion actual
            Sesion.Roles = rolesUsuario.Where(rol => rol.Estado.Equals(true)).ToList();

        }

        #endregion

        #region Metodos privados

        #endregion
    }
}
