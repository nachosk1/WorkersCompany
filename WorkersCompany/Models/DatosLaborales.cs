using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class DatosLaborales
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string AreaDepartamento { get;set }
    }
}
