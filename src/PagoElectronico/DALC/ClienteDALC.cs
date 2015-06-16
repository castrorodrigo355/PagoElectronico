using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;
using System.Data.SqlClient;
using System.Data;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.DALC
{
    class ClienteDALC : BaseDALC, IDALC
    {
        #region Constantes

        private const String SQL_SELECT_CLIENTE = @"SELECT * FROM " + ConstantesDALC.TB_CLIENTE + " WHERE Cliente_Usuario = @pi_Usuario_ID";
        private const String SQL_SELECT_CLIENTES = @"SELECT * FROM " + ConstantesDALC.TB_CLIENTE;
        private const String SQL_INSERT_CLIENTE = @"INSERT INTO " + ConstantesDALC.TB_CLIENTE + " (Cliente_Nombre, Cliente_Apellido, Cliente_Tipo_Doc_Cod, Cliente_Nro_Doc, Cliente_Tipo_Doc_Desc, Cliente_Dom_Calle, Cliente_Dom_Nro, Cliente_Dom_Piso, Cliente_Dom_Depto, Cliente_Fecha_Nac, Cliente_Mail, Cliente_Pais_Codigo, Cliente_Nacionalidad) = VALUES (@pi_Cliente_Nombre, @pi_Cliente_Apellido, @pi_Cliente_Tipo_Doc_Cod, @pi_Cliente_Nro_Doc, @pi_Tipo_Doc_Desc, @pi_Cliente_Dom_Calle, @pi_Cliente_Dom_Nro, @pi_Cliente_Dom_Piso, @pi_Cliente_Dom_Depto, @pi_Cliente_Fecha_Nac, @pi_Cliente_Mail, @pi_Cliente_Pais_Codigo, @pi_Cliente_Nacionalidad)";

        #endregion

        #region Miembros de IDALC

        public int Insertar(object obj)
        {
            Cliente oCliente = (Cliente)obj;
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
                oCommand.CommandText = SQL_INSERT_CLIENTE;

                //Genero parámetros de entrada                
                this.SetParametros(ref arrParms, ref oCliente);

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

        //Seteo los parametros para la consulta de insertar cliente
        private void SetParametros(ref SqlParameter[] arrParms, ref Cliente oCliente)
        {
            arrParms = new SqlParameter[14];

            arrParms[0] = new SqlParameter("@pi_Cliente_Nombre", SqlDbType.VarChar);
            arrParms[0].Direction = ParameterDirection.Input;
            arrParms[0].Value = oCliente.Cliente_Nombre;

            arrParms[1] = new SqlParameter("@pi_Cliente_Apellido", SqlDbType.VarChar);
            arrParms[1].Direction = ParameterDirection.Input;
            arrParms[1].Value = oCliente.Cliente_Apellido;

            arrParms[2] = new SqlParameter("@pi_Cliente_Tipo_Doc_Cod", SqlDbType.TinyInt);
            arrParms[2].Direction = ParameterDirection.Input;
            arrParms[2].Value = oCliente.Cliente_Tipo_Doc_Cod;

            arrParms[3] = new SqlParameter("@pi_Cliente_Nro_Doc", SqlDbType.Int);
            arrParms[3].Direction = ParameterDirection.Input;
            arrParms[3].Value = oCliente.Clinte_Nro_Doc;

            arrParms[4] = new SqlParameter("@pi_Cliente_Tipo_Doc_Desc", SqlDbType.VarChar);
            arrParms[4].Direction = ParameterDirection.Input;
            arrParms[4].Value = oCliente.Cliente_Tipo_Doc_Desc;

            arrParms[5] = new SqlParameter("@pi_Cliente_Nombre", SqlDbType.VarChar);
            arrParms[5].Direction = ParameterDirection.Input;
            arrParms[5].Value = oCliente.Cliente_Nombre;

            arrParms[6] = new SqlParameter("@pi_Cliente_Dom_Calle", SqlDbType.VarChar);
            arrParms[6].Direction = ParameterDirection.Input;
            arrParms[6].Value = oCliente.Cliente_Dom_Calle;

            arrParms[7] = new SqlParameter("@pi_Cliente_Dom_Nro", SqlDbType.Int);
            arrParms[7].Direction = ParameterDirection.Input;
            arrParms[7].Value = oCliente.Cliente_Dom_Nro;

            arrParms[8] = new SqlParameter("@pi_Cliente_Dom_Piso", SqlDbType.Int);
            arrParms[8].Direction = ParameterDirection.Input;
            arrParms[8].Value = oCliente.Cliente_Dom_Piso;

            arrParms[9] = new SqlParameter("@pi_Cliente_Dom_Depto", SqlDbType.VarChar);
            arrParms[9].Direction = ParameterDirection.Input;
            arrParms[9].Value = oCliente.Cliente_Dom_Depto;

            arrParms[10] = new SqlParameter("@pi_Cliente_Fecha_Nac", SqlDbType.DateTime);
            arrParms[10].Direction = ParameterDirection.Input;
            arrParms[10].Value = oCliente.Cliente_Fecha_Nacimiento;

            arrParms[11] = new SqlParameter("@pi_Cliente_Mail", SqlDbType.VarChar);
            arrParms[11].Direction = ParameterDirection.Input;
            arrParms[11].Value = oCliente.Cliente_Mail;

            arrParms[12] = new SqlParameter("@pi_Cliente_Pais_Codigo", SqlDbType.Int);
            arrParms[12].Direction = ParameterDirection.Input;
            arrParms[12].Value = oCliente.Cliente_Pais_Codigo;

            arrParms[13] = new SqlParameter("@pi_Cliente_Nacionalidad", SqlDbType.VarChar);
            arrParms[13].Direction = ParameterDirection.Input;
            arrParms[13].Value = oCliente.Cliente_Nacionalidad;
        }

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public int Actualizar(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Existe(object obj)
        {
            throw new NotImplementedException();
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
                oCommand.CommandText = SQL_SELECT_CLIENTES;

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

        public DataSet GetFilter(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodos publicos

        public Cliente ObtenerCliente(int usuarioID)
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlParameter[] arrParms = null;
            SqlDataReader oDataReader = null;
            Cliente oCliente = new Cliente();
            try
            {
                oConnection = this.Conectar();

                //Preparo el comando asociado a la conexion
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_CLIENTE;

                arrParms = new SqlParameter[1];

                arrParms[0] = new SqlParameter("@pi_Usuario_ID", SqlDbType.Int);
                arrParms[0].Direction = ParameterDirection.Input;
                arrParms[0].Value = usuarioID;

                AgregarParametros(ref oCommand, ref arrParms);

                //Ejecuto el comando
                oDataReader = oCommand.ExecuteReader();

                if (oDataReader.HasRows)
                {
                    while (oDataReader.Read())
                    {
                        oCliente.Cliente_ID = Convert.ToInt32(oDataReader["Cliente_ID"]);
                        oCliente.Cliente_Nombre = Convert.ToString(oDataReader["Cliente_Nombre"]);
                        oCliente.Cliente_Apellido = Convert.ToString(oDataReader["Cliente_Apellido"]);
                        oCliente.Cliente_Dom_Calle = Convert.ToString(oDataReader["Cliente_Dom_Calle"]);
                        oCliente.Cliente_Dom_Nro = Convert.ToInt32(oDataReader["Cliente_Dom_Nro"]);
                        oCliente.Cliente_Dom_Piso = Convert.ToInt32(oDataReader["Cliente_Dom_Piso"]);
                        oCliente.Cliente_Dom_Depto = Convert.ToString(oDataReader["Cliente_Dom_Depto"]);
                        oCliente.Cliente_Fecha_Nacimiento = Convert.ToDateTime(oDataReader["Cliente_Fecha_Nac"]);
                        oCliente.Cliente_Mail = Convert.ToString(oDataReader["Cliente_Mail"]);
                        oCliente.Cliente_Tipo_Doc_Cod = Convert.ToInt32(oDataReader["Cliente_Tipo_Doc_Cod"]);
                        oCliente.Clinte_Nro_Doc = Convert.ToInt32(oDataReader["Cliente_Nro_Doc"]);
                        oCliente.Cliente_Tipo_Doc_Desc = Convert.ToString(oDataReader["Cliente_Tipo_Doc_Desc"]);
                    }
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
            return oCliente;
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

