using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; //AGREGADO para el manejo de variables de sesion **Obligatorio 2**
using Obligatorio1_Dominio;

namespace Obligatorio2MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index() //Sin uso
        {
            return View();
        }

        public IActionResult ListadoUsuariosClientesOrdenados()
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                ViewBag.UsuarioRegistrado = Sistema.Instancia.UsuariosClientesOrdenadosPorApellidoYNombre();
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }
    }
}
