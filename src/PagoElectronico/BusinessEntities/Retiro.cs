using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Retiro
    {
        public int Retiro_ID { get; set; }
        public DateTime Retiro_Fecha { get; set; }
        public int Retiro_Moneda { get; set; }
        public Decimal Retiro_Importe { get; set; }
        public int Retiro_Cuenta_Numero { get; set; }
        public int Retiro_Codigo_Egreso { get; set; }
        public int Retiro_Nro_Cheque { get; set; }


        public Retiro(DateTime fecha, int moneda, Decimal importe, int cuenta_numero, int codigo_egreso, int cheque) 
        {
            this.Retiro_Fecha = fecha;
            this.Retiro_Moneda = moneda;
            this.Retiro_Importe = importe;
            this.Retiro_Nro_Cheque = cheque;
            this.Retiro_Cuenta_Numero = cuenta_numero;
            this.Retiro_Codigo_Egreso = codigo_egreso;
        }
    }
}
