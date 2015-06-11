using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.iDALC;

namespace PagoElectronico.DALC
{
    class ClienteDALC : BaseDALC, IDALC
    {
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
    }
}
