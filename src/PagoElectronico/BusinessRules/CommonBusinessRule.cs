using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.DALC;

namespace PagoElectronico.BusinessRules
{
    class CommonBusinessRule
    {
        public DataTable BuscarTiposDocumentos()
        {
            DataTable dtTiposDocumentos = null;

            try
            {
                CommonDALC oCommonDALC = new CommonDALC();
                dtTiposDocumentos = oCommonDALC.TipoDocumentosGetList().Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return dtTiposDocumentos;
        }

        public DataTable BuscarPaises()
        {
            DataTable dtPaises = null;

            try
            {
                CommonDALC oCommonDALC = new CommonDALC();
                dtPaises = oCommonDALC.PaisesGetList().Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return dtPaises;
        }

        public DataTable BuscarPreguntasSecretas() 
        {
            DataTable dtPreguntasSecretas = null;

            return dtPreguntasSecretas;
        }

        public DataTable BuscarRoles()
        {
            DataTable dtRoles = null;

            try
            {
                CommonDALC oCommonDALC = new CommonDALC();
                dtRoles = oCommonDALC.RolesGetList().Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return dtRoles;
        }

        internal DataTable BuscarMonedas()
        {
            DataTable dtMonedas = null;

            try
            {
                CommonDALC oCommonDALC = new CommonDALC();
                dtMonedas = oCommonDALC.MonedasGetList().Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return dtMonedas;
        }

        public DataTable BuscarTiposCuenta()
        {
            DataTable dtTipoCuenta = null;

            try
            {
                CommonDALC oCommonDALC = new CommonDALC();
                dtTipoCuenta = oCommonDALC.TipoCuentaGetList().Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return dtTipoCuenta;
        }
    }
}
