﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersCompany.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public Trabajador Trabajador { get; set; }

    }
}
