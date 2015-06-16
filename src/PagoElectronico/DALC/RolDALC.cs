using PagoElectronico.iDALC;
using System.Data.SqlClient;
using System.Data;
using System;
using PagoElectronico.BusinessEntities;
using System.Collections.Generic;

namespace PagoElectronico.DALC
{
    class RolDALC : BaseDALC, IDALC
    {
        #region Constantes

        private const string SQL_SELECT_ROLES_USUARIO = @"SELECT Rol_ID, Rol_Estado, Rol_Nombre, Funcionalidad_ID, Funcionalidad_Nombre FROM " + ConstantesDALC.TB_USUARIO_ROL + " INNER JOIN" + ConstantesDALC.TB_ROL + " ON Usuario_Rol_Rol_ID = Rol_ID INNER JOIN " + ConstantesDALC.TB_ROL_FUNCIONALIDADES + " ON Rol_ID = Rol_Funcionalidad_Rol_ID INNER JOIN" + ConstantesDALC.TB_FUNCIONALIDAD + " ON Rol_Funcionalidad_Funcionalidad_ID = Funcionalidad_ID WHERE Usuario_Rol_Usuario_ID = @pi_Usuario_ID";

        #endregion

        #region Miembros de IDALC

        public int Insertar(object obj)
        {
            throw new System.NotImplementedException();
        }

        public int Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Actualizar(object obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(object obj)
        {
            throw new System.NotImplementedException();
        }

        public System.Data.DataSet GetList()
        {
            throw new System.NotImplementedException();
        }

        public System.Data.DataSet GetFilter(object obj)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Metodos publicos

        public List<Rol> ObtenerRolesUsuario(int usuarioID)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            SqlDataReader oDataReader = null;
            List<Rol> rolesUsuario = new List<Rol>();

            try
            {
                oConnection = this.Conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_ROLES_USUARIO;

                arrParms = new SqlParameter[1];

                arrParms[0] = new SqlParameter("@pi_Usuario_ID", SqlDbType.Int);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = usuarioID;

                AgregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                oDataReader = oCommand.ExecuteReader();

                int rolAnterior = 0;
                //Mientras tengas filas avanza

                Rol oRol = null;
                while (oDataReader.Read())
                {
                    if (Convert.ToInt32(oDataReader["Rol_ID"]) != rolAnterior)
                    {
                        rolAnterior = Convert.ToInt32(oDataReader["Rol_ID"]);
                        oRol = new Rol();
                        oRol.ID = rolAnterior;
                        oRol.Estado = Convert.ToBoolean(oDataReader["Rol_Estado"]);
                        oRol.Descripcion = Convert.ToString(oDataReader["Rol_Nombre"]);
                        rolesUsuario.Add(oRol);
                    }

                    Funcionalidad nuevaFuncionalidad = new Funcionalidad();
                    nuevaFuncionalidad.ID = Convert.ToInt32(oDataReader["Funcionalidad_ID"]);
                    nuevaFuncionalidad.Descripcion = Convert.ToString(oDataReader["Funcionalidad_Nombre"]);
                    oRol.AgregarFuncionalidad(nuevaFuncionalidad);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Cierro la conexion
                this.Desconectar(ref oConnection);

                //Libero los recursos
                this.LiberarSQLConnection(ref oConnection);
                this.LiberarSQLCommand(ref oCommand);
            }

            return rolesUsuario;
        }

        #endregion

        #region Metodos privados

        private void AgregarParametros(ref SqlCommand oCommand, ref SqlParameter[] arrParms)
        {
            foreach (SqlParameter parameter in arrParms)
                oCommand.Parameters.Add(parameter);
        }

        #endregion
    }
}
