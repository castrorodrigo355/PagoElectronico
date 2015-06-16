using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.DALC;

namespace PagoElectronico.BusinessRules
{
    class CuentaBusinessRule
    {
        public DataTable ObtenerCuentas()
        {
            CuentaDALC oCuentaDALC = new CuentaDALC();
            return oCuentaDALC.GetList().Tables[0];
        }
    }
}
