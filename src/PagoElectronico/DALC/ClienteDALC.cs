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

        #endregion

        #region Miembros de IDALC

        public int insert(object obj)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public int update(object obj)
        {
            throw new NotImplementedException();
        }

        public bool exists(object obj)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet getList()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet getFilter(object obj)
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
                oConnection = this.conectar();

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
                this.desconectar(ref oConnection);

                //Libero los recursos
                this.liberarSqlConnection(ref oConnection);
                this.liberarSqlCommand(ref oCommand);
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

