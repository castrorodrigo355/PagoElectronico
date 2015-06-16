using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.BusinessEntities;
using PagoElectronico.DALC;
using System.Data;
using System.Windows.Forms;

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

        public DataTable ObtenerRoles()
        {
            RolDALC oRolDALC = new RolDALC();
            return oRolDALC.GetList().Tables[0];
        }

        public DataTable ObtenerFuncionalidades()
        {
            RolDALC oRolDALC = new RolDALC();
            return oRolDALC.GetListFuncionalidades().Tables[0];
        }

        public int RegistrarRol(String nombre, Boolean habilitado, List<Funcionalidad> funcionalidades)
        {
            RolDALC oRolDALC = new RolDALC();
            Rol oRol = null;
            int result = 0;

            try
            {
                oRol = new Rol();
                oRol.Descripcion = nombre;
                oRol.Estado = habilitado;
                oRol.Funcionalidades = funcionalidades;

                result = oRolDALC.Insertar(oRol);
                
                foreach (Funcionalidad oFuncionalidad in funcionalidades)
                    oRolDALC.InsertarFuncionalidad(result, oFuncionalidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al registrar al Rol");
            }
            return result;
        }
    }
}
