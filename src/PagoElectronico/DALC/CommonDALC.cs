using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;
using System.Data;
using System.Data.SqlClient;

namespace PagoElectronico.DALC
{
    class CommonDALC : BaseDALC
    {

        private const String SQL_SELECT_PAISES = @"SELECT 0 AS [Pais_ID], '(Seleccione)' AS [Pais_Desc] UNION SELECT Pais_ID, Pais_Desc FROM " + ConstantesDALC.TB_PAIS;
        private const String SQL_SELECT_TIPOS_DOCUMENTOS = @"SELECT 0 AS [Tipo_Documento_ID], '(Seleccione)' AS [Tipo_Documento_Desc] UNION SELECT Tipo_Documento_ID, Tipo_Documento_Desc FROM " + ConstantesDALC.TB_TIPO_DOCUMENTO;
        //private const String SQL_SELECT_PREGUNTAS_SECRETAS = @"SELECT 0 AS [Pais_ID], '(Seleccione)' AS [Pais_Desc] UNION SELECT Pais_ID, Pais_Desc FROM " + ConstantesDALC.TB_PAIS; 
        private const String SQL_SELECT_ROLES = @"SELECT 0 AS [Rol_ID], '(Seleccione)' AS [Rol_Nombre] UNION SELECT Rol_ID, Rol_Nombre FROM " + ConstantesDALC.TB_ROL + " WHERE Rol_Estado = '1'";
        private const String SQL_SELECT_MONEDAS = @"SELECT 0 AS [Moneda_ID], '(Seleccione)' AS [Moneda_Tipo] UNION SELECT Moneda_ID, Moneda_Tipo FROM " + ConstantesDALC.TB_MONEDA;
        private const String SQL_SELECT_TIPO_CUENTAS = @"SELECT 0 AS [Tipo_Cuenta_ID], '(Seleccione)' AS [Tipo_Cuenta_Descr] UNION SELECT Tipo_Cuenta_ID, Tipo_Cuenta_Descr FROM " + ConstantesDALC.TB_TIPO_CUENTA;

        public DataSet PaisesGetList()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsPaises = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_PAISES;

                //Creo un set de datos
                dsPaises = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsPaises);
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

            return dsPaises;
        }

        public DataSet PreguntasSecretasGetList()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsPreguntasSecretas = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
              //  oCommand.CommandText = SQL_SELECT_PREGUNTAS_SECRETAS;

                //Creo un set de datos
                dsPreguntasSecretas = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsPreguntasSecretas);
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

            return dsPreguntasSecretas;
        }

        public DataSet TipoDocumentosGetList() 
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsTipoDocumentos = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_TIPOS_DOCUMENTOS;

                //Creo un set de datos
                dsTipoDocumentos = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsTipoDocumentos);
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

            return dsTipoDocumentos;
        }

        public DataSet RolesGetList()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsRoles = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_ROLES;

                //Creo un set de datos
                dsRoles = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsRoles);
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

            return dsRoles;
        }

        public DataSet MonedasGetList()
        {
             SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsMonedas = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_MONEDAS;

                //Creo un set de datos
                dsMonedas = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsMonedas);
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

            return dsMonedas;
        }

        public DataSet TipoCuentaGetList()
        {
            SqlConnection oConnection = null;
            SqlCommand oCommand = null;
            SqlDataAdapter oAdapter = null;
            DataSet dsTipoCuenta = null;

            try
            {
                //Abro conexión
                oConnection = this.Conectar();

                //Creo y configuro el comando asociado a la conexión
                oCommand = oConnection.CreateCommand();
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandText = SQL_SELECT_TIPO_CUENTAS;

                //Creo un set de datos
                dsTipoCuenta = new DataSet();

                //Creo un adaptador asignándole el comando
                oAdapter = new SqlDataAdapter(oCommand);

                //Genero el set de datos a través del adaptador
                oAdapter.Fill(dsTipoCuenta);
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

            return dsTipoCuenta;
        }
    }
}
