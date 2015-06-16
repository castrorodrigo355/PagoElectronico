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

        protected virtual SqlConnection Conectar()
        {
            SqlConnection oConnection = new SqlConnection(Configuracion.CONNECTION_STRING);
            oConnection.Open();

            return oConnection;
        }
        
        protected virtual void Desconectar(ref SqlConnection oConnection)
        {
            if (oConnection != null)
            {
                if (oConnection.State == ConnectionState.Open || oConnection.State == ConnectionState.Broken)
                    oConnection.Close();
            }
        }
        
        protected void LiberarSQLConnection(ref SqlConnection oConnection)
        {
            if (oConnection != null)
            {
                this.Desconectar(ref oConnection);
                oConnection.Dispose();
            }
            oConnection = null;
        }
        
        protected void LiberarSQLCommand(ref SqlCommand oCommand)
        {
            if (oCommand != null)
                oCommand.Dispose();

            oCommand = null;
        }
        
        protected void LiberarDataReader(ref SqlDataReader oDataReader)
        {
            if (oDataReader != null)
                oDataReader.Dispose();

            oDataReader = null;
        }

        #endregion

    }
}
