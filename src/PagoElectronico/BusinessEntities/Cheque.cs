using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Cheque
    {
        public int Cheque_ID { get; set; }
        public int Cheque_Numero { get; set; }
        public DateTime Cheque_Fecha { get; set; }
        public int Cheque_Moneda { get; set; }
        public int Cheque_Importe { get; set; }
        public int Cheque_Cliente_ID { get; set; }
        public int Cheque_Banco { get; set; }

        public Cheque(int numero, DateTime fecha_emision, int moneda, int importe, int cliente, int banco)
        {
            Cheque_Numero = numero;
            Cheque_Fecha = fecha_emision;
            Cheque_Moneda = moneda;
            Cheque_Importe = importe;
            Cheque_Cliente_ID = cliente;
            Cheque_Banco = banco;
        }
    }
}
