using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Deposito
    {
        public int Deposito_ID { get; set; }
        public int Deposito_Numero { get; set; }
        public DateTime Deposito_Fecha { get; set; }
        public int Deposito_Moneda { get; set; }
        public int Deposito_Importe { get; set; }
        public int Deposito_Nro_Tarjeta_cli { get; set; }
        public int Deposito_Cuenta_Numero { get; set; }

        public Deposito(int numero, DateTime fecha, int moneda, int importe, int tarjeta, int cuenta) 
        {
            this.Deposito_Numero = numero;
            this.Deposito_Fecha = fecha;
            this.Deposito_Moneda = moneda;
            this.Deposito_Importe = importe;
            this.Deposito_Nro_Tarjeta_cli = tarjeta;
            this.Deposito_Cuenta_Numero = cuenta;
        }
    }
}
