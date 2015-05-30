using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.iDALC
{
    interface IDALC
    {
        int insert(object obj);
        int delete(int id);
        int update(object obj);
        bool exists(object obj);
        DataSet getList();
        DataSet getFilter(object obj);
    }
}
