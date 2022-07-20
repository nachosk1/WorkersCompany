using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models{
    public class Trabajador {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Sexo { get; set; }
        public int Estado { get; set; }
        public ContactosEmerg ContactosEmerg { get; set; }
        public DatosLaborales DatosLaborales { get; set; }
        public CargaFamiliar CargaFamiliar { get; set; }
        


    }
}
