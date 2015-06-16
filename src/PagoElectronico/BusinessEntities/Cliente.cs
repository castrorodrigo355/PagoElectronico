using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Cliente
    {
        #region Atributos y Propiedades

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
        public String Cliente_Nacionalidad { get; set; }
        public int Cliente_Pais_Codigo { get; set; }

        #endregion

        #region Constructor

        public Cliente(String nombre, String apellido, int tipo_documento_cod, int documento, String documento_desc, DateTime fecha, String nacionalidad, String mail, String calle, int calle_nro, int piso, String depto, int pais_codigo) 
        {
            this.Cliente_Nombre = nombre;
            this.Cliente_Apellido = apellido;
            this.Cliente_Tipo_Doc_Cod = tipo_documento_cod;
            this.Cliente_Tipo_Doc_Desc = documento_desc;
            this.Clinte_Nro_Doc = documento;
            this.Cliente_Fecha_Nacimiento = fecha;
            this.Cliente_Nacionalidad = nacionalidad;
            this.Cliente_Mail = mail;
            this.Cliente_Dom_Calle = calle;
            this.Cliente_Dom_Nro = calle_nro;
            this.Cliente_Dom_Piso = piso;
        }

        public Cliente() 
        {
        }

        #endregion
    }
}
