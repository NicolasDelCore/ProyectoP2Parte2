using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; //AGREGADO para el manejo de variables de sesion **Obligatorio 2**
using Microsoft.Extensions.Logging;
using Obligatorio2MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Obligatorio1_Dominio;

namespace Obligatorio2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult IndexLogin()
        {
            return View(); //Retorna la vista que pide al usuario los datos para loguearse
        }

        public IActionResult Login(string nombreUsuario, string contraseña) 
        {
            if (nombreUsuario != null && contraseña != null && nombreUsuario != "" && contraseña != "")
            {
                // ValidarUsuarioYOperador devuelve: 0 si no se econtro usuario, 1 si el usuario encontrado es cliente y 2 si el usuario encontrado es operador
                int tipoUsuario = Sistema.Instancia.ValidarUsuarioYOperador(nombreUsuario, contraseña);
                if (tipoUsuario == 1)
                {
                    HttpContext.Session.SetString("NombreUsuario", nombreUsuario); //Guardo el nombre de usuario como variable de sesion
                    HttpContext.Session.SetInt32("TipoUsuario", tipoUsuario); //Guardo el tipo de usuario como variable de sesion
                    //Cambiar los valores para redireccionar correctamente
                    return RedirectToAction("Index", "Home"); //Redireccionamos al controlador que maneja la vista a mostrar
                }
                else if (tipoUsuario == 2)
                {
                    HttpContext.Session.SetString("NombreUsuario", nombreUsuario);
                    HttpContext.Session.SetInt32("TipoUsuario", tipoUsuario);
                    //Cambiar los valores para redireccionar correctamente
                    return RedirectToAction("Privacy", "Home");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario no existente";
                }
            }
            else
            {
                ViewBag.Mensaje = "Los datos ingresados no son correctos";
            }
            return View("IndexLogin"); 
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("NombreUsuario");
            HttpContext.Session.Remove("TipoUsuario");
            return View("IndexLogin");
        }

    }
}
