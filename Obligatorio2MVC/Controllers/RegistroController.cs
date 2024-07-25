using Microsoft.AspNetCore.Mvc;
using System;
using Obligatorio1_Dominio;
using Microsoft.AspNetCore.Http; //AGREGADO para el manejo de variables de sesion **Obligatorio 2**

namespace Obligatorio2MVC.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult RegistroUsuario()
        {
            return View();
        }

        public IActionResult AltaUsuario(string nombre, string apellido, DateTime fechaNacimiento, string email, string nombreUsuario, string contraseña)
        {
            //chequeo de valores null / vacíos y fecha válida
            if (nombre != null && apellido != null && fechaNacimiento != null && email != null && nombreUsuario != null && contraseña != null &&
               nombre != "" && apellido != "" && fechaNacimiento > DateTime.MinValue && email != "" && nombreUsuario != "" && contraseña != "")
            {
                //chequeo de longitud y seguridad para nombre, apellido y contraseña
                if (Sistema.Instancia.ValidarContraseña(contraseña) && contraseña.Length > 5 && nombre.Length > 1 && apellido.Length > 1)
                {
                    //chequeo de que el usuario no exista en la base de datos
                    if (Sistema.Instancia.BuscarUsuario(email) == null && Sistema.Instancia.BuscarUsuario(nombreUsuario) == null)
                    {
                        ViewBag.Mensaje = Sistema.Instancia.AltaUsuarios(nombre, apellido, email, fechaNacimiento, nombreUsuario, contraseña, false); // con el parámetro false: Hardcodeo que solo se puedan registrar Usuarios y no Operadores  VERIFICAR SI ES CORRECTO USARLO ACA ************************************************
                    }
                    //si se encontró un usuario ya registrado
                    else
                    {
                        ViewBag.Mensaje = "Ese nombre de usuario y/o email ya se encuentran registrados.";
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "Los datos no son correctos";
            }
            return View("RegistroUsuario");
        }

    }

}