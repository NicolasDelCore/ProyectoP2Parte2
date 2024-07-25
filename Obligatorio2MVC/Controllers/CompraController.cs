using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Obligatorio1_Dominio;
using Microsoft.AspNetCore.Http; //AGREGADO para el manejo de variables de sesion **Obligatorio 2**

namespace Obligatorio2MVC.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult IndexCompra()
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult ComprasEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                //chequeo de valores null / fecha válida
                if (fechaDesde != null && fechaDesde > DateTime.MinValue && fechaHasta != null && fechaHasta > DateTime.MinValue && fechaHasta > fechaDesde)
                {
                    ViewBag.ComprasEntreFechas = Sistema.Instancia.ComprasEntreFechas(fechaDesde, fechaHasta);
                    ViewBag.Mensaje = $"La suma total de todas las compras (Activas) es ${Sistema.Instancia.SumaDeComprasActivas(ViewBag.ComprasEntreFechas)}";
                }
                else
                {
                    ViewBag.Mensaje = "Los datos no son correctos. Verifique.";
                }
                return View("ComprasEntreFechas");
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult ComprasDeMayorValor()
        {
            //se restringe el acceso si no es Usuario Operador
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 2)
            {
                ViewBag.ComprasMayorValor = Sistema.Instancia.MaximoCompras();
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult ComprarActividad(string actividadNombre)
        {
            //se restringe el acceso si no es Usuario Cliente
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                if (actividadNombre != null && actividadNombre != "-1")
                {
                    ViewBag.actividadEscogida = actividadNombre;
                    return View(); 
                }
                else
                {
                    TempData["Mensaje"] = "-1";
                    return RedirectToAction("ListadoYCompraActividades", "Actividades");
                }
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult RealizarCompra(string cantidadEntradas, string actividadEscogida)
        {
            //se restringe el acceso si no es Usuario Cliente
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                ViewBag.Confirmacion = "Error al comprar. Revise la cantidad de entradas y el evento seleccionado.";

                if (actividadEscogida != null && actividadEscogida != "" && cantidadEntradas != null && cantidadEntradas != "")
                {
                    int.TryParse(cantidadEntradas, out int cantididadEntradasInt);
                    if (cantididadEntradasInt > 0)
                    {
                        Sistema.Instancia.AltaCompra(Sistema.Instancia.Compras.Count + 1, actividadEscogida, cantididadEntradasInt, HttpContext.Session.GetString("NombreUsuario"));
                        ViewBag.Confirmacion = "Compra realizada con éxito!"; //+ cantididadEntradasInt + " " + cantidadEntradas; //debug - concatenación para problemas con cantidad
                    }
                    else
                    {
                        ViewBag.Confirmacion = "Error en los datos ingresados.";
                    }
                }
                else
                {
                    ViewBag.Confirmacion = "Error en los datos ingresados.";
                }
                return RedirectToAction("ComprarActividad"); //volvemos a la selección de actividad
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult MisCompras()
        {
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                ViewBag.Compras = Sistema.Instancia.ListarComprasPorUsuario(HttpContext.Session.GetString("NombreUsuario"));
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult CancelarCompras()
        {
            
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                ViewBag.Compras = Sistema.Instancia.ListarComprasPorUsuario(HttpContext.Session.GetString("NombreUsuario"));
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

        public IActionResult CompletarCancelacion(int id)
        {
            if (HttpContext.Session.GetString("NombreUsuario") != null && HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                if(id > 0)
                {
                    Sistema.Instancia.CancelarCompra(id);
                    ViewBag.Mensaje = $"Cancelacion Exitosa de la compra con ID: {id}";
                }
                return View();
            }
            else
            {
                return RedirectToAction("IndexLogin", "Home");
            }
        }

    }
}
