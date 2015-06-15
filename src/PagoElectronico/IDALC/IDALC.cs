using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PagoElectronico.iDALC
{
    interface IDALC
    {
        int Insertar(object obj);
        int Eliminar(int id);
        int Actualizar(object obj);
        bool Existe(object obj);
        DataSet GetList();
        DataSet GetFilter(object obj);
    }
}
