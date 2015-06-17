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
        private const String SQL_SELECT_ROLES = @"SELECT * FROM " + ConstantesDALC.TB_ROL;
        private const String SQL_SELECT_FUNCIONALIDADES = @"SELECT * FROM " + ConstantesDALC.TB_FUNCIONALIDAD;
        private const String SQL_INSERT_ROL = @"INSERT INTO " + ConstantesDALC.TB_ROL + "(Rol_Nombre, Rol_Estado) VALUES (@pi_Rol_Nombre, @pi_Rol_Estado); SELECT CAST(scope_identity() AS int)";
        private const String SQL_INSERT_FUNCIONALIDAD = @"INSERT INTO " + ConstantesDALC.TB_ROL_FUNCIONALIDADES + "(Rol_Funcionalidad_Rol_ID, Rol_Funcionalidad_Funcionalidad_ID) VALUES (@pi_Rol_ID, @pi_Funcionalidad_ID); SELECT CAST(scope_identity() AS int)";
        private const String SQL_SELECT_FUNCIONALIDADES_PARA_ROL = @"SELECT Funcionalidad_ID, Funcionalidad_Nombre FROM " + ConstantesDALC.TB_ROL_FUNCIONALIDADES + " INNER JOIN " + ConstantesDALC.TB_FUNCIONALIDAD + " ON Funcionalidad_ID = Rol_Funcionalidad_Funcionalidad_ID WHERE Rol_Funcionalidad_Rol_ID = @pi_Rol_ID";
        private const String SQL_UPDATE_ROL = @"UPDATE " + ConstantesDALC.TB_ROL + " SET Rol_Nombre = @pi_Rol_Nombre, Rol_Estado = @pi_Rol_Estado WHERE Rol_ID = @pi_Rol_ID";

        #endregion

        #region Miembros de IDALC

        public int Insertar(object obj)
        {
            Rol oRol = (Rol)obj;
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            int result = 0;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_INSERT_ROL;

                //Genero parámetros de entrada                
                this.SetParametros(ref arrParms, ref oRol);

                //Asigno parámetros al comando
                this.AgregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                result = Convert.ToInt32(oCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //Cierro conexión
                this.Desconectar(ref oConnection);

                //Libero recursos
                this.LiberarSQLConnection(ref oConnection);
                this.LiberarSQLCommand(ref oCommand);
            }

            return result;
        }

        public void InsertarFuncionalidad(int rolID, Funcionalidad oFuncionalidad)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_INSERT_FUNCIONALIDAD;

                arrParms = new SqlParameter[2];

                arrParms[0] = new SqlParameter("@pi_Rol_ID", SqlDbType.Int);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = rolID;

                arrParms[1] = new SqlParameter("@pi_Funcionalidad_ID", SqlDbType.Int);
                arrParms[1].Direction = ParameterDirection.Input;
                arrParms[1].Value = oFuncionalidad.ID;

                //Asigno parámetros al comando
                this.AgregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                oCommand.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //Cierro conexión
                this.Desconectar(ref oConnection);

                //Libero recursos
                this.LiberarSQLConnection(ref oConnection);
                this.LiberarSQLCommand(ref oCommand);
            }

         
        }

        private void SetParametros(ref SqlParameter[] arrParms, ref Rol oRol)
        {
            arrParms = new SqlParameter[2];

            arrParms[0] = new SqlParameter("@pi_Rol_Nombre", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = oRol.Descripcion;

            arrParms[1] = new SqlParameter("@pi_Rol_Estado", SqlDbType.Bit);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = oRol.Estado;
        }

        public int Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Actualizar(object obj)
        {
            Rol oRol = (Rol)obj;
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            int result = 0;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_UPDATE_ROL;

                arrParms = new SqlParameter[3];

                arrParms[0] = new SqlParameter("@pi_Rol_Nombre", SqlDbType.VarChar);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = oRol.Descripcion;

                arrParms[1] = new SqlParameter("@pi_Rol_Estado", SqlDbType.Bit);
                arrParms[1].Direction = ParameterDirection.Input;
                arrParms[1].Value = oRol.Estado;

                arrParms[2] = new SqlParameter("@pi_Rol_ID", SqlDbType.Int);
                arrParms[2].Direction = ParameterDirection.Input;
                arrParms[2].Value = oRol.ID;

                //Asigno parámetros al comando
                this.AgregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                result = Convert.ToInt32(oCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //Cierro conexión
                this.Desconectar(ref oConnection);

                //Libero recursos
                this.LiberarSQLConnection(ref oConnection);
                this.LiberarSQLCommand(ref oCommand);
            }

            return result;
        }

        public bool Existe(object obj)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetList()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oDataAdapter = null;
            DataSet oDataSet = new DataSet();

            try
            {
                oConnection = this.Conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_ROLES;

                oDataAdapter = new SqlDataAdapter(oCommand);

                oDataAdapter.Fill(oDataSet);
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
            return oDataSet;
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

        public DataSet GetListFuncionalidades()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oDataAdapter = null;
            DataSet oDataSet = new DataSet();

            try
            {
                oConnection = this.Conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_FUNCIONALIDADES;

                oDataAdapter = new SqlDataAdapter(oCommand);

                oDataAdapter.Fill(oDataSet);
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
            return oDataSet;
        }

        public DataSet GetListFuncionalidadesRol(int rolID)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oDataAdapter = null;
            DataSet oDataSet = new DataSet();
            SqlParameter[] arrParms = null;

            try
            {
                oConnection = this.Conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_FUNCIONALIDADES_PARA_ROL;

                arrParms = new SqlParameter[1];

                arrParms[0] = new SqlParameter("@pi_Rol_ID", SqlDbType.Int);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = rolID;

                AgregarParametros(ref oCommand, ref arrParms);
                
                oDataAdapter = new SqlDataAdapter(oCommand);

                oDataAdapter.Fill(oDataSet);
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
            return oDataSet;
        }
    }
}
