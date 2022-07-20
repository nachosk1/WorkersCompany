using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersCompany.Context;
using WorkersCompany.Models;

namespace WorkersCompany.Controllers
{
    public class LoginController : Controller
    {
        private readonly YuriDBContext _context;
        public LoginController(YuriDBContext context) {
            _context = context; 
        }
        // GET: LoginController
        public IActionResult Login()
        {
            ViewBag.Error = null;
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if(usuario.Username.Equals("Admin") && usuario.Password.Equals("1234")){
                return RedirectToAction("Index", "Usuario");
            }
            else{
                var user = (from u in _context.Usuarios
                           where u.Username.Equals(usuario.Username)
                           && u.Password.Equals(usuario.Password)
                           select u).FirstOrDefault();
                           
                if (user != null){
                    return RedirectToAction("Index", "Trabajador");
                }
                else{
                    if(!usuario.Username.Equals("") || !usuario.Password.Equals("")){
                        ViewBag.Error = "Usuario y/o Contraseña incorrecta";
                    }
                    return View();
                }
            }
            
        }


    }
}
