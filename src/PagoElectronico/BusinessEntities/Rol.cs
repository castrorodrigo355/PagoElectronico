using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.BusinessEntities
{
    public class Rol
    {
        public int ID { get; set; }
        public String Descripcion { get; set; }
        public bool Estado { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }

        public Rol()
        {
            Funcionalidades = new List<Funcionalidad>();
        }

        public void AgregarFuncionalidad(Funcionalidad funcionalidad) 
        {
            Funcionalidades.Add(funcionalidad);
        }

        public void QuitarFuncionalidad(Funcionalidad funcionalidad)
        {
            Funcionalidades.Remove(funcionalidad);
        }
    }
}
