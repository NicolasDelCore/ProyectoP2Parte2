using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; //Agregado para el manejo de variables de sesión
using Obligatorio1_Dominio;

namespace Obligatorio2MVC.Controllers
{
    public class ActividadesController : Controller
    {
        public IActionResult Index()//Sin uso
        {
            return View();
        }

        public IActionResult ListadoActividades() //Se usa tanto como para usuario sin identificar como para usuario operador
        {
            ViewBag.Actividades = Sistema.Instancia.Actividades;
            return View();
        }

        public IActionResult IndexListadoActividadesSegunLugar()
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                ViewBag.Actividades = Sistema.Instancia.Actividades;
                return View();

            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult ListadoActividadesSegunLugar(string lugar)
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {

                if (lugar != null && lugar != "-1")
                {
                    ViewBag.Actividades = Sistema.Instancia.ListarActividadesPorLugar(lugar);
                    return View("ListadoActividades");
                }
                else
                {
                    ViewBag.Mensaje = "Error en los datos ingresados.";
                    return View("IndexListadoActividadesSegunLugar");
                }
                
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult IndexListadoActividadesSegunFechaYCategoria()
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                ViewBag.Actividades = Sistema.Instancia.Actividades;
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult ListadoActividadesSegunFechaYCategoria(DateTime fechaDesde, DateTime fechaHasta, string categoria)
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                if (fechaHasta > fechaDesde && fechaDesde != null && fechaDesde > DateTime.MinValue && fechaHasta != null && fechaHasta > DateTime.MinValue && categoria != null && categoria != "-1")
                {
                    ViewBag.Actividades = Sistema.Instancia.ActividadesPorCategoriaEntreFechasObligatorio2(categoria, fechaDesde, fechaHasta);
                }
                else
                {
                    ViewBag.Mensaje = "Datos incorrectos. Verifique.";
                }
                return View("ListadoActividades");
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home"); 
            }
        }

        public IActionResult ListadoYCompraActividades()
        {
            //se restringe el acceso si no es UsuarioCliente
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                ViewBag.Actividades = Sistema.Instancia.Actividades;
                //Verificacion de seleccion de actividad en el select y muestra de mensaje error
                if (TempData["Mensaje"]!=null)//Este TempData se genera en el controller ComprarActividad de Compra
                {
                    string verificacion = TempData["Mensaje"].ToString();
                    if (verificacion == "-1")
                    {
                        ViewBag.Mensaje = "Debe seleccionar una actividad";
                    }                    
                }
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult MeGustaActividades()
        {
            //se restringe el acceso si no es UsuarioCliente
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                ViewBag.Actividades = Sistema.Instancia.Actividades;
                //Verificacion de seleccion de actividad en el select y muestra de mensaje error
                if (TempData["Mensaje"] != null)//Este TempData se genera en el controller ComprarActividad de Compra
                {
                    string verificacion = TempData["Mensaje"].ToString();
                    if (verificacion == "-1")
                    {
                        ViewBag.Mensaje = "Debe seleccionar una actividad";
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult CompletarMeGustaActividades(string actividadNombre)
        {
            //se restringe el acceso si no es Usuario Cliente
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                if (actividadNombre != null && actividadNombre != "-1")
                {
                    Sistema.Instancia.DarMeGusta(actividadNombre);
                    ViewBag.Mensaje = $"Se dio Me Gusta! con exito. Ahora {actividadNombre} tiene {Sistema.Instancia.BuscarActividad(actividadNombre).MeGusta} me gusta";                    
                }
                else
                {
                    TempData["Mensaje"] = "-1";
                    return RedirectToAction("MeGustaActividades", "Actividades");
                }
                return View("MeGustaActividades");
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }
    }
}
