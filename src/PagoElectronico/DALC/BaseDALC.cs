using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PagoElectronico.configuracion;

namespace PagoElectronico.DALC
{
    class BaseDALC
    {
        #region Metodos protegidos

        protected virtual SqlConnection conectar()
        {
            SqlConnection oConnection = new SqlConnection(Configuracion.CONNECTION_STRING);
            oConnection.Open();

            return oConnection;
        }
        
        protected virtual void desconectar(ref SqlConnection oConnection)
        {
            if (oConnection != null)
            {
                if (oConnection.State == ConnectionState.Open || oConnection.State == ConnectionState.Broken)
                    oConnection.Close();
            }
        }
        
        protected void liberarSqlConnection(ref SqlConnection oConnection)
        {
            if (oConnection != null)
            {
                this.desconectar(ref oConnection);
                oConnection.Dispose();
            }
            oConnection = null;
        }
        
        protected void liberarSqlCommand(ref SqlCommand oCommand)
        {
            if (oCommand != null)
                oCommand.Dispose();

            oCommand = null;
        }
        
        protected void liberarDataReader(ref SqlDataReader oDataReader)
        {
            if (oDataReader != null)
                oDataReader.Dispose();

            oDataReader = null;
        }

        #endregion

    }
}
