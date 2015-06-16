using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;

namespace PagoElectronico.DALC
{
    class FacturaDALC : BaseDALC, IDALC
    {
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

        public System.Data.DataSet GetList()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet GetFilter(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
