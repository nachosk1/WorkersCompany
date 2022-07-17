using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class CargaFamiliar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Parentesco { get; set; }
        public int Sexo { get; set; }
        [Display(Name = "Carga Familiar")]
        public string Rut { get; set; }
        //psdfjpisdjifjsdjfljslkdflkjslkj
    }   
}
