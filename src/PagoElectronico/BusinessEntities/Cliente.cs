using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Cliente
    {
        public int Cliente_ID { get; set; }
        public String Cliente_Nombre { get; set; }
        public String Cliente_Apellido { get; set; }
        public DateTime Cliente_Fecha_Nacimiento { get; set; }
        public int Cliente_Tipo_Doc_Cod { get; set; }
        public int Clinte_Nro_Doc { get; set; }
        public String Cliente_Dom_Calle { get; set; }
        public int Cliente_Dom_Nro { get; set; }
        public int Cliente_Dom_Piso { get; set; }
        public String Cliente_Dom_Depto { get; set; }
        public String Cliente_Mail { get; set; }
        public String Cliente_Tipo_Doc_Desc { get; set; }
    }
}
