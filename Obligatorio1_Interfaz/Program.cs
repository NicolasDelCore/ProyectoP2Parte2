using System;
using Obligatorio1_Dominio;


namespace Obligatorio1_Interfaz
{
    class Program
    {
        #region Instancia del Sistema
        //*************** SE CREA LA INSTANCIA DE LA CLASE ADMINISTRADORA SISTEMA ***************
        private static Sistema miSistema = new Sistema();
        #endregion

        #region Método Main
        //Ejecución de Menú principal en UI
        //*************** ARMA MENÚ QUE MUESTRA LAS DISTINTAS OPCIONES PLANTEADAS ***************
        static void Main(string[] args)
        {
            ComportamientoMenu();
        }
        #endregion

        #region Método ComportamientoMenu
        //Comportamiento del menú principal
        static void ComportamientoMenu() //(string opcionSeleccionada)
        {
            string opcionSeleccionada = "-1";
            do
            {
                MostrarMenu();
                opcionSeleccionada = Console.ReadLine();
                VerificarOpcionSeleccionada(opcionSeleccionada);

            }
            while (opcionSeleccionada != "0") ; //si se introduce 0, el programa termina
        }
        #endregion

        #region Método MostrarMenu
        //Dibujado del Menú
        //*************************  DIBUJA EN CONSOLA EL MENÚ CON LAS OPCIONES  ******************************
        static void MostrarMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("******************************************************************************************************************");
            Console.WriteLine("*                                                                                                                *");
            Console.WriteLine("*                                               MENU                                                             *");
            Console.WriteLine("*                                                                                                                *");
            Console.WriteLine("*    1) Listar todas las actividades (sin especificar el precio de la entrada)                                   *");
            Console.WriteLine("*    2) Cambiar valor del aforo máximo                                                                           *");
            Console.WriteLine("*    3) Cambiar valor del precio de butacas que se utilizan en lugares abiertos                                  *");
            Console.WriteLine("*    4) Dada una categoría, listar las actividades de esa categoría que se realicen en un rango de fechas dado   *");
            Console.WriteLine("*    5) Listar espectáculos aptos para todo público                                                              *");
            Console.WriteLine("*    0) Salir                                                                                                    *");
            Console.WriteLine("*                                                                                                                *");
            Console.WriteLine("*                                                                                                                *");
            Console.WriteLine("*                            Ingrese el número de la opción a ejecutar                                           *");
            Console.WriteLine("*                                                                                                                *");
            Console.WriteLine("******************************************************************************************************************");
        }
        #endregion

        #region Método VerificarOpcionSeleccionada
        //Ejecuta las funcionalidades del Menú
        /*************************  VERIFICA LA OPCIÓN SELECCIONADA Y EN FUNCIÓN DE LA MISMA INVOCA AL MÉTODO AUXILIAR QUE RESUELVE EL REQUERIMIENTO FUNCIONAL  *************************/
        private static void VerificarOpcionSeleccionada(string opcionSeleccionada)
        {
            if (opcionSeleccionada != "0") //si llegó un texto "0" como opcionSeleccionada, entonces no queremos mostrar el error del caso default (termina el método y termina el programa)
            {
                int.TryParse(opcionSeleccionada, out int opcion);
                switch (opcion)
                {
                    case 1:
                        ListarTodasLasActividades();
                        break;
                    case 2:
                        CambiarValorDelAforoMaximo();
                        break;
                    case 3:
                        CambiarValorPrecioButacasEnLugaresAbiertos();
                        break;
                    case 4:
                        ListarActividadesPorCategoriaYFechas();
                        break;
                    case 5:
                        ListarEspectaculosATP();
                        break;
                    default: Console.WriteLine("Error: Opción no válida."); // Devolvemos el error si se ingresa un dato no-parseable (out int opcion devolverá 0) o si se parsea un int que no está en el menú (ej: 66)
                        break;
                }
            }
        }
        #endregion

        #region Método MostrarMenuAuxiliar
        //Dibujado del Menú Auxiliar, de esta forma podemos hacer más legible los métodos que devuelven un output muy largo (ej: ListarTodasLasActividades)
        static void MostrarMenuAuxiliar()
        {
            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal.");
        }
        #endregion

        #region Método ComportamientoMenuAuxiliar
        //Comportamiento del menú auxiliar
        static void ComportamientoMenuAuxiliar()
        {
            MostrarMenuAuxiliar();
            Console.ReadLine(); //Ponemos una "pausa" en el programa hasta que el usuario ponga algo
            Console.WriteLine("Volviendo al menú principal."); //mostramos "Volviendo al menú principal.", como seguimos dentro del while del menú, no necesitamos hacer nada más
        }
        #endregion

        #region Método ListarTodasLasActividades
        /*************************  OPCION 1  --  LISTAR TODAS LAS ACTIVIDADES  ******************************/
        static void ListarTodasLasActividades() 
        {
            string misActividades = miSistema.ListarActividades(); ;
            if (misActividades == "")
            {
                Console.WriteLine("\n\nNo hay actividades disponibles.\n");
            }
            else
            {
                Console.WriteLine("\n\nLas Actividades son:\n" + misActividades + "\n");
                ComportamientoMenuAuxiliar(); //Mostramos el menú auxiliar, para facilitar la lectura del output
            }
        }
        #endregion

        #region Método CambiarValorDelAforoMaximo
        /*************************  OPCION 2  --  CAMBIAR VALOR DEL AFORO MAXIMO     ******************************/
        
        static void CambiarValorDelAforoMaximo()
        {
            Console.WriteLine("\n\nIngrese el nuevo valor para el porcentaje de aforo máximo");
            float.TryParse(Console.ReadLine(), out float nuevoPorcentajeAforoMaximo);

            if (nuevoPorcentajeAforoMaximo > 0 && nuevoPorcentajeAforoMaximo < 101) // con este chequeo, confirmamos que no se introdujeron caracteres, 0 o valores mayores a 100
            {
                Console.WriteLine(miSistema.CambiarAforoMaximo(nuevoPorcentajeAforoMaximo));
                ComportamientoMenuAuxiliar(); //Mostramos el menú auxiliar, para facilitar la lectura del output
            }
            else
            {
                Console.WriteLine("Error en los datos ingresados");
            }

        }
        #endregion

        #region Método Cambiar Precio de Butacas en Lugares Abiertos
        /*************************  OPCION 3  --  CAMBIAR VALOR DEL PRECIO DE BUTACAS  ******************************/
        static void CambiarValorPrecioButacasEnLugaresAbiertos()
        {
            Console.WriteLine("\n\nIngrese el nuevo precio de butacas que se utilizan en lugares abiertos");
            float.TryParse(Console.ReadLine(), out float nuevoPrecio);

            if (nuevoPrecio > 0)
            {
                Console.WriteLine(miSistema.CambiarPrecioButaca(nuevoPrecio));
                ComportamientoMenuAuxiliar(); //Mostramos el menú auxiliar, para facilitar la lectura del output
            }
            else
            {
                Console.WriteLine("Error en los datos ingresados");
            }
        }
        #endregion

        #region Listar Actividades por Categoría y Fecha
        /*************************  OPCION 4  --  LISTAR LAS ACTIVIDADES SEGUN CATEGORÍA Y RANGO DE FECHAS  ******************************/
        static void ListarActividadesPorCategoriaYFechas()
        {
            Console.WriteLine($"Categorías disponibles: {miSistema.ListarCategorias()} \n\nIngrese la Categoria que desea Listar.");
            string categoria = Console.ReadLine();
            
            Console.WriteLine("Ingrese fecha desde en el formato YYYY-MM-DD");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde);

            Console.WriteLine("Ingrese fecha hasta en el formato YYYY-MM-DD");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta);

            if (miSistema.BuscarCategoriaBool(categoria) && fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue)
            {
                string misActividades = miSistema.ActividadesPorCategoriaEntreFechas(categoria, fechaDesde.Date, fechaHasta.Date); //guardamos el string de retorno de ActividadesPorCategoriaEntreFechas
                if (misActividades == "")
                {
                    Console.WriteLine("\n\nNo hay actividades disponible para esa categoría en ese rango de fechas. \n");
                }
                else
                {
                    Console.WriteLine("\n\nLas actividades disponibles para esa categoría en ese rango de fechas son: \n" + misActividades + "\n");
                    ComportamientoMenuAuxiliar(); //Mostramos el menú auxiliar, para facilitar la lectura del output
                }
            }
            else
            {
                Console.WriteLine("\n\nError en los datos ingresados. Revise categoría y fechas. \n");
            }
        }
        #endregion

        #region Listar Espectáculos ATP
        /*************************  OPCION 5  --  LISTAR ESPECTÁCULOS APTOS PARA TODO PÚBLICO  ******************************/
        static void ListarEspectaculosATP()
        {
            string misEspectaculosATP = miSistema.EspectaculosATP();
            if (misEspectaculosATP == "")
            {
                Console.WriteLine("\n\nNo hay espectáculos Para Todo Público disponibles.\n");
            }
            else
            {
                Console.WriteLine("\n\nLos espectáculos Para Todo Público son:\n" + misEspectaculosATP + "\n");
                ComportamientoMenuAuxiliar(); //Mostramos el menú auxiliar, para facilitar la lectura del output
            }
        }
        #endregion        
    }
}
