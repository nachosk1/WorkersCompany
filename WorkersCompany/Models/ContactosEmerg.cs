using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class ContactosEmerg
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        [Display(Name = "Contacto Emergencia")]
        public int Numero { get; set; }
    }
}
