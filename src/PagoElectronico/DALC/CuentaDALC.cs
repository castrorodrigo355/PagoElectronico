using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;
using System.Data;
using System.Data.SqlClient;

namespace PagoElectronico.DALC
{
    class CuentaDALC : BaseDALC, IDALC
    {
        #region Constantes

        private const String SQL_SELECT_CUENTAS = @"SELECT * FROM " + ConstantesDALC.TB_CUENTA;
        private const String SQL_SELECT_CUENTAS_CLIENTE = @"SELECT * FROM " + ConstantesDALC.TB_CUENTA + " WHERE Cuenta_Cliente_ID = @pi_Cliente_ID";

        #endregion

        #region Miembros de IDALC

        public int Insertar(object obj)
        {
            throw new NotImplementedException();
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

        public DataSet GetList(int clienteID)
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
                oCommand.CommandText = SQL_SELECT_CUENTAS_CLIENTE;

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
                oCommand.CommandText = SQL_SELECT_CUENTAS;

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
    }
}
