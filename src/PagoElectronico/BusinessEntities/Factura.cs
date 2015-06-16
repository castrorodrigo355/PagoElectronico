using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Factura
    {
        public int Factura_Numero { get; set; }
        public DateTime Factura_Fecha { get; set; }
        public int Factura_Nro_Cliente { get; set; }
        public List<ItemFactura> items;

        public Factura(int numero, DateTime fecha, int numero_cliente)
        {
            this.Factura_Numero = numero;
            this.Factura_Fecha = fecha;
            this.Factura_Nro_Cliente = numero_cliente;
        }
    }
}
