using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;
using PagoElectronico.BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.DALC
{
    class UsuarioDALC : BaseDALC, IDALC
    {
        #region Constantes
        private const int CANTIDAD_MAXIMA_INTENTOS_FALLIDOS = 3;
        private const String SQL_INSERT_USUARIO = @"INSERT INTO " + ConstantesDALC.TB_USUARIO + " (Usuario_Username, Usuario_password) VALUES (@pi_Usuario_Username, @pi_Usuario_password)";
        private const String SQL_DELETE_USUARIO = @"DELETE FROM " + ConstantesDALC.TB_USUARIO + " WHERE Usuario_Username = @pi_Usuario_username";
        private const String SQL_UPDATE_USUARIO = @"UPDATE " + ConstantesDALC.TB_USUARIO + " SET Usuario_Username = @pi_Usuario_Username, Usuario_password = @pi_Usuario_password WHERE Usuario_Username = @pi_Usuario_username";
        private const String SQL_SELECT_USUARIO = @"SELECT * FROM " + ConstantesDALC.TB_USUARIO + " WHERE Usuario_Username = @pi_Usuario_Username";
        private const String SQL_INCREMENTAR_INTENTO_FALLIDO = @"INSERT INTO " + ConstantesDALC.TB_USUARIO + "(Usuario_Cant_Intentos) VALUES (@pi_Usuario_Cant_Intentos)";

        #endregion

        #region Metodos publicos

        public bool validarUsuario(String nombre_usuario, byte[] password)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            SqlDataReader oDataReader = null;
            bool result = false;

            try
            {
                oConnection = this.conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_USUARIO;

                setParametros(ref arrParms, nombre_usuario);

                agregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                oDataReader = oCommand.ExecuteReader();

                //Si tiene filas el SqlDataReader es porque retorno una coincidencia
                if (oDataReader.HasRows)
                {
                    //Leo el SqlReader
                    oDataReader.Read();

                    if (passwordValido(password, oDataReader))
                    {
                        if (estadoActivo(oDataReader))
                        {
                            Usuario usuarioValidado = new Usuario();
                            usuarioValidado.NombreUsuario = nombre_usuario;
                            usuarioValidado.Password =
                            usuarioValidado.PreguntaSecreta = (String)oDataReader["Usuario_Pregunta_Secreta"];
                            usuarioValidado.RespuestaSecreta = (byte[])oDataReader["Usuario_Respuesta_Secreta"];
                            usuarioValidado.IDUsuario = (int)oDataReader["Usuario_ID"];
                            usuarioValidado.FechaCreacion = (DateTime)oDataReader["Usuario_Fecha_Creacion"];
                            usuarioValidado.FechaUltimaModificacion = (DateTime)oDataReader["Usuario_Fecha_Ultima_Modif"];
                            usuarioValidado.CantidadIntentos = (byte)oDataReader["Usuario_Cant_Intentos"];
                            usuarioValidado.Estado = (String)oDataReader["Usuario_Estado"];

                            Sesion sesionActual = new Sesion();
                            sesionActual.SesionActual = usuarioValidado;
                        }
                    }
                    else//No matchea la password
                    {
                        int intentos = ((byte)oDataReader["Usuario_Cant_Intentos"]);
                        if (intentos < CANTIDAD_MAXIMA_INTENTOS_FALLIDOS)
                        {
                            //Sumo cant intento fallido
                            nuevoIntentoFallido(intentos + 1);

                        }
                    }
                }
                else //No matcha el username, es decir no existe el usuario
                {
                    throw new Exception();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Cierro la conexion
                this.desconectar(ref oConnection);

                //Libero los recursos
                this.liberarSqlConnection(ref oConnection);
                this.liberarSqlCommand(ref oCommand);
                this.liberarDataReader(ref oDataReader);
            }
            return result;
        }

        private bool estadoActivo(SqlDataReader oDataReader)
        {
            return (bool)oDataReader["Usuario_Estado"];
        }

        private static bool passwordValido(byte[] password, SqlDataReader oDataReader)
        {
            return password == ((byte[])oDataReader["Usuario_Password"]);
        }

        private int nuevoIntentoFallido(int intento_fallido)
        {

            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            int result = 0;

            try
            {
                oConnection = this.conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_INCREMENTAR_INTENTO_FALLIDO;

                setParametros(ref arrParms, intento_fallido);

                agregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                result = oCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Cierro la conexion
                this.desconectar(ref oConnection);

                //Libero los recursos
                this.liberarSqlConnection(ref oConnection);
                this.liberarSqlCommand(ref oCommand);
            }
            return result;
        }

        #endregion

        #region Metodos privados

        private void setParametros(ref SqlParameter[] arrParms, String nombre_usuario)
        {
            arrParms = new SqlParameter[1];
            arrParms[0] = new SqlParameter("@pi_Usuario_Username", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = nombre_usuario;

        }

        private void setParametros(ref SqlParameter[] arrParms, int intento_fallido)
        {
            arrParms = new SqlParameter[1];
            arrParms[0] = new SqlParameter("@pi_Usuario_Cant_Intentos", SqlDbType.TinyInt);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = intento_fallido;

        }


        private void setParametros(ref SqlParameter[] arrParms, ref Usuario oUsuario)
        {
            arrParms = new SqlParameter[2];

            arrParms[0] = new SqlParameter("@pi_Usuario_Username", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = oUsuario.NombreUsuario;

            arrParms[1] = new SqlParameter("@pi_Usuario_Password", SqlDbType.VarBinary);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = oUsuario.Password;
        }

        private void agregarParametros(ref SqlCommand oCommand, ref SqlParameter[] arrParms)
        {
            foreach (SqlParameter parameter in arrParms)
                oCommand.Parameters.Add(parameter);
        }

        #endregion

        #region IDALC Metodos

        public int insert(object obj)
        {
            Usuario oUsuario = (Usuario)obj;
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            int result = 0;

            try
            {
                //Abro conexión
                oConnection = this.conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_INSERT_USUARIO;

                //Genero parámetros de entrada                
                this.setParametros(ref arrParms, ref oUsuario);

                //Asigno parámetros al comando
                this.agregarParametros(ref oCommand, ref arrParms);

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
                this.desconectar(ref oConnection);

                //Libero recursos
                this.liberarSqlConnection(ref oConnection);
                this.liberarSqlCommand(ref oCommand);
            }

            return result;
        }

        public int delete(int idUsuario)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            int result = 0;

            try
            {
                //Abro la conexion
                oConnection = this.conectar();

                //Creo y configuro el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_DELETE_USUARIO;

                //Agrego parametros a la query
                oCommand.Parameters.Add("@pi_Usuario_Username", SqlDbType.VarChar).Value = idUsuario;

                result = oCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Cierro la conexion
                this.desconectar(ref oConnection);

                //Libero los recursos
                this.liberarSqlConnection(ref oConnection);
                this.liberarSqlCommand(ref oCommand);
            }

            return result;

        }

        public int update(object obj)
        {
            throw new NotImplementedException();
        }

        public bool exists(object obj)
        {
            throw new NotImplementedException();
        }

        public DataSet getList()
        {
            throw new NotImplementedException();
        }

        public DataSet getFilter(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
