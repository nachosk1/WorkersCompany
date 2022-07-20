using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio*")]
        [Display(Name = "Nombre Usuario")]
        [StringLength(10)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio*")]
        [Display(Name = "Contraseña")]
        [StringLength(10)]
        public string Password { get; set; }
        public Trabajador Trabajador { get; set; }

        public override string ToString()
        {
            return "Usuario: " + Username + "Contraseña: " + Password;
        }

    }
}
