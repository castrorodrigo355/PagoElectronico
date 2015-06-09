using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;
using PagoElectronico.BusinessEntities;
using System.Data.SqlClient;
using System.Data;
using PagoElectronico.BusinessRules;
using System.Windows.Forms;
using PagoElectronico.Exceptions;

namespace PagoElectronico.DALC
{
    class UsuarioDALC : BaseDALC, IDALC
    {

        #region Constantes

        private const int CANTIDAD_MAXIMA_INTENTOS_FALLIDOS = 3;
        private const String SQL_LOG_INTENTO_FALLIDO = @"INSERT INTO " + ConstantesDALC.TB_AUDITORIA_LOG + " (Log_Usuario, Log_Fecha_Hora, Log_Tipo, Log_Cant_Intentos) VALUES (@pi_Log_Usuario, @pi_Log_Fecha_Hora, @pi_Log_Tipo, @pi_Log_Cant_Intentos)";
        private const String SQL_INSERT_USUARIO = @"INSERT INTO " + ConstantesDALC.TB_USUARIO + " (Usuario_username, Usuario_password) VALUES (@pi_Usuario_username, @pi_Usuario_password)";
        private const String SQL_DELETE_USUARIO = @"DELETE FROM " + ConstantesDALC.TB_USUARIO + " WHERE Usuario_Username = @pi_Usuario_username";
        private const String SQL_UPDATE_USUARIO = @"UPDATE " + ConstantesDALC.TB_USUARIO + " SET Usuario_Username = @pi_Usuario_username, Usuario_password = @pi_Usuario_password WHERE Usuario_Username = @pi_Usuario_username";
        private const String SQL_SELECT_USUARIO = @"SELECT * FROM " + ConstantesDALC.TB_USUARIO + " WHERE Usuario_username = @pi_Usuario_username";
        private const String SQL_INCREMENTAR_INTENTO_FALLIDO = @"UPDATE " + ConstantesDALC.TB_USUARIO + " SET Usuario_Cant_Intentos = @pi_Usuario_Cant_Intentos WHERE Usuario_ID = @pi_Usuario_ID";
        private const String SQL_DESHABILITAR_USUARIO = @"UPDATE " + ConstantesDALC.TB_USUARIO + " SET Usuario_Estado = @pi_Usuario_Estado, Usuario_Cant_Intentos = @pi_Usuario_Cant_Intentos WHERE Usuario_ID = @pi_Usuario_ID";

        #endregion

        #region Metodos publicos

        public bool validarUsuario(String nombre_usuario, byte[] password)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            SqlDataReader oDataReader = null;
            bool result = false;
            Usuario usuarioValidado = null;

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

                    if (estadoActivo(oDataReader))
                    {
                        if (passwordValido(password, oDataReader))
                        {
                            //Creo el objeto usuario que esta logueandose al sistema
                            usuarioValidado = new Usuario();
                            usuarioValidado.Usuario_Username = nombre_usuario;
                            usuarioValidado.Usuario_Password = (byte[])oDataReader["Usuario_Password"]; ;
                            usuarioValidado.Usuario_Pregunta_Secreta = (String)oDataReader["Usuario_Pregunta_Secreta"];
                            usuarioValidado.Usuario_Respuesta_Secreta = (byte[])oDataReader["Usuario_Respuesta_Secreta"];
                            usuarioValidado.Usuario_ID = (int)oDataReader["Usuario_ID"];
                            usuarioValidado.Usuario_Fecha_Creacion = (DateTime)oDataReader["Usuario_Fecha_Creacion"];
                            usuarioValidado.Usuario_Fecha_Ultima_Modif = (DateTime)oDataReader["Usuario_Fecha_Ultima_Modif"];
                            usuarioValidado.Usuario_Cantidad_Intentos = (byte)oDataReader["Usuario_Cant_Intentos"];
                            usuarioValidado.Usuario_Estado = (String)oDataReader["Usuario_Estado"];

                            //Creo la sesión
                            Sesion sesionActual = new Sesion();
                            sesionActual.SesionActual = usuarioValidado;
                        }
                        else//No matchea la password
                        {
                            int intentos = ((byte)oDataReader["Usuario_Cant_Intentos"]);
                            if (intentos < CANTIDAD_MAXIMA_INTENTOS_FALLIDOS)
                            {
                                //Sumo cant intento fallido y logueo la actividad
                                nuevoIntentoFallido(intentos + 1, Convert.ToInt32(oDataReader["Usuario_ID"]));
                                logueoIntentoFallido(Convert.ToInt32(oDataReader["Usuario_ID"]), intentos + 1);
                                throw new PasswordIncorrectaException();
                            }
                            if (intentos == CANTIDAD_MAXIMA_INTENTOS_FALLIDOS)
                            {
                                //Deshabilito el usuario y restablezco los intentos
                                deshabilitarUsuario(Convert.ToInt32(oDataReader["Usuario_ID"]));
                            }

                        }
                    }
                    else
                    {
                        throw new UsuarioDeshabilitadoException();
                    }
                }
                else //No matcha el username, es decir no existe el usuario
                {
                    throw new UsuarioInexistenteException();
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

        #endregion

        #region Metodos privados

        private void deshabilitarUsuario(int usuario_id)
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
                oCommand.CommandText = SQL_DESHABILITAR_USUARIO;

                arrParms = new SqlParameter[3];

                arrParms[0] = new SqlParameter("@pi_Usuario_Estado", SqlDbType.Char);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = 'D';

                arrParms[1] = new SqlParameter("@pi_Usuario_Cant_Intentos", SqlDbType.TinyInt);
                arrParms[1].Direction = ParameterDirection.Input;
                arrParms[1].Value = 0;

                arrParms[2] = new SqlParameter("@pi_Usuario_ID", SqlDbType.Int);
                arrParms[2].Direction = ParameterDirection.Input;
                arrParms[2].Value = usuario_id;


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
        }


        private void logueoIntentoFallido(int usuario_id, int intento_fallido)
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
                oCommand.CommandText = SQL_LOG_INTENTO_FALLIDO;

                setParametrosLogueo(ref arrParms, usuario_id, intento_fallido);

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
        }

        private bool estadoActivo(SqlDataReader oDataReader)
        {
            return 'A'.Equals(Convert.ToChar(oDataReader["Usuario_Estado"]));
        }

        private static bool passwordValido(byte[] password, SqlDataReader oDataReader)
        {
            return password == ((byte[])oDataReader["Usuario_Password"]);
        }

        private int nuevoIntentoFallido(int intento_fallido, int usuario_id)
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

                arrParms = new SqlParameter[2];

                arrParms[0] = new SqlParameter("@pi_Usuario_Cant_Intentos", SqlDbType.TinyInt);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = intento_fallido;

                arrParms[1] = new SqlParameter("@pi_Usuario_ID", SqlDbType.Int);
                arrParms[1].Direction = ParameterDirection.Input;
                arrParms[1].Value = usuario_id;


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

        private void setParametros(ref SqlParameter[] arrParms, String nombre_usuario)
        {
            arrParms = new SqlParameter[1];
            arrParms[0] = new SqlParameter("@pi_Usuario_username", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = nombre_usuario;

        }

        private void setParametros(ref SqlParameter[] arrParms, int intento_fallido, int usuario_id)
        {
            arrParms = new SqlParameter[2];
            arrParms[0] = new SqlParameter("@pi_Usuario_Cant_Intentos", SqlDbType.TinyInt);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = intento_fallido;

            arrParms[1] = new SqlParameter("@pi_Usuario_ID", SqlDbType.Int);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = usuario_id;

        }

        private void setParametrosLogueo(ref SqlParameter[] arrParms, int usuario_id, int intento_fallido)
        {
            arrParms = new SqlParameter[4];

            arrParms[0] = new SqlParameter("@pi_Log_Usuario", SqlDbType.Int);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = usuario_id;

            arrParms[1] = new SqlParameter("@pi_Log_Fecha_Hora", SqlDbType.DateTime);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = System.DateTime.Now;

            arrParms[2] = new SqlParameter("@pi_Log_Tipo", SqlDbType.VarChar);
            arrParms[2].Direction = ParameterDirection.Input;
            arrParms[2].Value = "INTENTO_FALLIDO";


            arrParms[3] = new SqlParameter("@pi_Log_Cant_Intentos", SqlDbType.TinyInt);
            arrParms[3].Direction = ParameterDirection.Input;
            arrParms[3].Value = intento_fallido;

        }

        private void setParametros(ref SqlParameter[] arrParms, ref Usuario oUsuario)
        {
            arrParms = new SqlParameter[2];

            arrParms[0] = new SqlParameter("@pi_Usuario_username", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = oUsuario.Usuario_Username;

            arrParms[1] = new SqlParameter("@pi_Usuario_Password", SqlDbType.VarBinary);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = oUsuario.Usuario_Password;
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
                oCommand.Parameters.Add("@pi_Usuario_username", SqlDbType.VarChar).Value = idUsuario;

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
