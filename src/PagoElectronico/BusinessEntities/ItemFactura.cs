using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class ItemFactura
    {
        public int Item_Factura_ID { get; set; }
        public String Item_Factura_Descripcion { get; set; }
        public int Item_Factura_Importe { get; set; }
        public int Item_Factura_ID_Factura { get; set; }

        public ItemFactura(String descripcion, int importe, int factura_id) 
        {
            this.Item_Factura_Descripcion = descripcion;
            this.Item_Factura_ID_Factura = factura_id;
            this.Item_Factura_Importe = importe;
        }
    }
}
