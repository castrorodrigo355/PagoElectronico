using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.DALC;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.BusinessRules
{
    class ClienteBusinessRule
    {
        public void ObtenerCliente(int usuarioID)
        {
            ClienteDALC oClienteDALC = new ClienteDALC();
            Sesion.Cliente = oClienteDALC.ObtenerCliente(usuarioID);
        }
    }
}
