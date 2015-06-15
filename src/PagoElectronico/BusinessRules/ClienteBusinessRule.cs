using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.DALC;
using PagoElectronico.BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace PagoElectronico.BusinessRules
{
    class ClienteBusinessRule
    {
        public void ObtenerCliente(int usuarioID)
        {
            ClienteDALC oClienteDALC = new ClienteDALC();
            Sesion.Cliente = oClienteDALC.ObtenerCliente(usuarioID);
        }

        public DataTable ObtenerClientes()
        {
            ClienteDALC oClienteDALC = new ClienteDALC();
            return oClienteDALC.GetList().Tables[0];
        }

        public void RegistrarNuevoCliente(String nombre, String apellido, int tipo_documento, int documento, String documento_desc, DateTime fecha_nacimiento, String nacionalidad, String mail, String calle, int calle_nro, int piso, String depto, int pais_codigo)
        {
            ClienteDALC oClienteDALC = null;
            Cliente oCliente = null;
            int result = 0;

            try
            {
                //Creo la instancia Cliente
                oCliente = new Cliente(nombre,apellido,tipo_documento,documento,documento_desc,fecha_nacimiento, nacionalidad,mail, calle,calle_nro, piso,depto, pais_codigo);

                //Inserta el registro en la base de datos
                oClienteDALC.Insertar(oCliente);
            }
            catch (SqlException ex)
            {
 
            }
        }
    }
}
