using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Transferencia
    {
        public int Transferencia_ID { get; set; }
        public DateTime Transferencia_Fecha { get; set; }
        public int Transferencia_Moneda { get; set; }
        public Decimal Transferencia_Importe { get; set; }
        public Decimal Transferencia_Costo { get; set; }
        public int Transferencia_Cuenta_Origen { get; set; }
        public int Transferencia_Cuenta_Destino { get; set; }

        public Transferencia(DateTime fecha, int moneda, Decimal importe, Decimal costo, int cuenta_origen, int cuenta_destino) 
        {
            this.Transferencia_Fecha = fecha;
            this.Transferencia_Moneda = moneda;
            this.Transferencia_Importe = importe;
            this.Transferencia_Costo = costo;
            this.Transferencia_Cuenta_Origen = cuenta_origen;
            this.Transferencia_Cuenta_Destino = cuenta_destino;
        }
    }
}
