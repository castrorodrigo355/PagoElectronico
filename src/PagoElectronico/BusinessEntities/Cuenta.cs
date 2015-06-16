using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Cuenta
    {
        public int Cuenta_Numero { get; set; }
        public DateTime Cuenta_Fecha_Creacion { get; set; }
        public int Cuenta_Pais_Codigo { get; set; }
        public DateTime Cuenta_Fecha_Cierre { get; set; }
        public int Cuenta_Tipo { get; set; }
        public int Cuenta_Cliente_ID { get; set; }
        public int Cuenta_Moneda { get; set; }
        public Boolean Cuenta_Estado { get; set; }

        public Cuenta(int cuenta_numero, DateTime fecha_creacion, DateTime fecha_cierre, int pais, int tipo, int cliente, int moneda, Boolean estado)
        {
            this.Cuenta_Numero = cuenta_numero;
            this.Cuenta_Fecha_Creacion = fecha_creacion;
            this.Cuenta_Fecha_Cierre = fecha_cierre;
            this.Cuenta_Pais_Codigo = pais;
            this.Cuenta_Tipo = tipo;
            this.Cuenta_Cliente_ID = cliente;
            this.Cuenta_Moneda = moneda;
            this.Cuenta_Estado = estado;
        }

    }
}
