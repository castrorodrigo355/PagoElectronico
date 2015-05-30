using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PagoElectronico.configuracion;

namespace PagoElectronico.configuracion
{
    class Configuracion
    {
        public static String CONNECTION_STRING;
        public static String TIEMPO_LIMITE_ESPERA = "15";

        public String _servidor { get; set; }
        public String _base_datos { get; set; }
        public String _fecha { get; set; }
        public String _usuario { get; set; }
        public String _password { get; set; }

        private void armarCadenaConexionBaseDeDatos()
        {

            Configuracion.CONNECTION_STRING = "User ID=" + this._usuario + ";" +
                                       "Password=" + this._password + ";" +
                                       "Server=" + this._servidor + ";" +
                                       "Trusted_Connection=" + true + ";" +
                                       "Database=" + this._base_datos + ";" +
                                       "Connection Timeout=" + Configuracion.TIEMPO_LIMITE_ESPERA;
            Console.WriteLine(CONNECTION_STRING);

        }

        public void leearArchivoConfiguracion()
        {

            XmlTextReader reader = new XmlTextReader("config.xml");

            while (reader.Read())
            {
                if (reader.Name.Equals(ConfiguracionTAG.CONFIGURACION))
                {
                    reader.Read();
                }
                if (reader.Name.Equals(ConfiguracionTAG.CONEXION))
                {
                    reader.Read();
                }
                if (reader.Name.Equals(ConfiguracionTAG.FECHA_SISTEMA))
                {
                    this._fecha = reader.ReadElementContentAsString();
                }
                if (reader.Name.Equals(ConfiguracionTAG.SERVIDOR))
                {
                    this._servidor = reader.ReadElementContentAsString();
                }
                if (reader.Name.Equals(ConfiguracionTAG.BASE_DATOS))
                {
                    this._base_datos = reader.ReadElementContentAsString();
                }
                if (reader.Name.Equals(ConfiguracionTAG.USUARIO))
                {
                    this._usuario = reader.ReadElementContentAsString();
                }
                if (reader.Name.Equals(ConfiguracionTAG.PASSWORD))
                {
                    this._password = reader.ReadElementContentAsString();
                }

            }
            this.armarCadenaConexionBaseDeDatos();


        }


    }
}
