using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models{
    public class Trabajador{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}
