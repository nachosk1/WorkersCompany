using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class DatosLaborales
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }
        [Display(Name = "Departamento")]
        public string AreaDepartamento { get; set; }
    }
}
