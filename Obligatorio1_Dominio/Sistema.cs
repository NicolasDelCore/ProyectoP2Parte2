using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class Sistema
    {
        #region Listas
        //*************** LISTAS PARA MANEJAR LOS OBJS DEL SISTEMA ***************
        private List<UsuarioRegistrado> usuarios = new List<UsuarioRegistrado>();
        private List<Lugar> lugares = new List<Lugar>();
        private List<Categoria> categorias = new List<Categoria>();
        private List<Actividad> actividades = new List<Actividad>();
        private List<Compra> compras = new List<Compra>();
        #endregion

        #region Singleton
        private static Sistema instancia;

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }
        #endregion        

        #region Método Constructor de Sistema
        public Sistema() //Metodo constructor de Object
        {
            //Llamada a los métodos que precargan objetos
            PreCargarDatosUsuarios();
            PreCargarDatosLugares();
            PreCargarDatosCategorias();
            PreCargarDatosActividades();
            PreCargarDatosCompras();
        }
        #endregion

        #region Métodos de Pre-Carga de Datos

        #region Método PreCargarDatosUsuarios
        //*************** CARGA DE DATOS DE USUARIOS HARCODEADOS ***************
        private void PreCargarDatosUsuarios()
        {
            //AGREGADO los valores correspodientes al usuario, contraseña y esOperador **Obligatorio 2**
            //usuarios
            AltaUsuarios("Fernando", "Fernandez", "fernanfernan1@skynet.net", new DateTime(1950, 06, 15), "Fer", "Fer1234", false);
            AltaUsuarios("Robin", "Hood", "comida@paralaplebe.org", new DateTime(1199, 07, 21), "RobinH", "RH-1234", false);
            AltaUsuarios("Es", "Talin", "comunista104@pueblo.org", new DateTime(1878, 12, 18), "STalin", "ILoveComunism1234", false);
            AltaUsuarios("Pepe", "Mujica", "elpepe@presidencia.uy", new DateTime(1935, 05, 20), "Pepe", "Pepe1234", false);
            AltaUsuarios("NombreUsuario", "ApellidoUsuario", "mailUsuario@mail.com", new DateTime(1990, 10, 05), "Usuario", "Usuario1234", false);
            AltaUsuarios("Francisco", "Fernandez", "fran@skynet.net", new DateTime(1985, 07, 04), "Fran", "Fran1234", false);
            AltaUsuarios("Fernando", "Fernandez", "fefefer@skynet.net", new DateTime(1991, 09, 05), "FerFerFer", "Fer1234", false);

            //operadores
            AltaUsuarios("Operador2", "Apellido2", "mimail2@mail.com", new DateTime(1973, 02, 20), "Operador2", "Operador2", true);
            AltaUsuarios("Operador", "Apellido", "mimail@mail.com", new DateTime(2000, 09, 27), "Operador1", "Operador1", true);
            AltaUsuarios("Operador3", "Apellido3", "mimail3@mail.com", DateTime.Now, "Operador3", "Operador3", true);

        }
        #endregion

        #region Método PreCargarDatosLugares
        //*************** CARGA DE DATOS DE LUGARES HARCODEADOS ***************
        private void PreCargarDatosLugares()
        {
            AltaLugarAbierto(1, "Plaza Césamo", 400);
            AltaLugarAbierto(2, "El Parque", 400);
            AltaLugarAbierto(3, "La Plaza", 400);
            AltaLugarAbierto(4, "Centenario", 400);

            AltaLugarCerrado(5, "Intendencia", 400, true, 700);
            AltaLugarCerrado(6, "Castillo Pittamiglio", 400, false, 700);
            AltaLugarCerrado(7, "Latu", 400, true, 700);
            AltaLugarCerrado(8, "El Galpón", 400, true, 700);


        }
        #endregion

        #region Método PreCargarDatosCategorias
        //*************** CARGA DE DATOS DE CATEGORIAS HARCODEADOS ***************
        private void PreCargarDatosCategorias()
        {
            AltaCategoria("Fiesta", "Eventos bailables para borrachines");
            AltaCategoria("Deporte", "Evento de actividad física");
            AltaCategoria("Competencia", "Evento en el que se disputa un premio");
            AltaCategoria("Educación", "Evento de culturización");
            AltaCategoria("Cine", "Proyeccion de películas");
            AltaCategoria("Teatro", "Representación de obras");
            AltaCategoria("Concierto", "Evento musical en vivo");
            AltaCategoria("Feria Gastronómica", "Mercado de alimentos y/o bebidas");

        }
        #endregion

        #region Método PreCargarDatosActividades
        //*************** CARGA DE DATOS DE ACTIVIDADES HARCODEADOS ***************
        private void PreCargarDatosActividades()
        {
            AltaActividad("Fiesta de la Cerveza", "Fiesta", new DateTime(2021, 10, 5, 20, 0, 0), "Plaza Césamo", "C18");
            AltaActividad("Juntada en la Intendencia", "Deporte", new DateTime(2022, 1, 24, 16, 30, 0), "Intendencia", "C16");
            AltaActividad("Competencia de cartas yugi", "Competencia", new DateTime(2021, 11, 15, 12, 30, 0), "El Parque", "C13");
            AltaActividad("Convención del Latu", "Educación", new DateTime(2021, 10, 9, 16, 30, 0), "Latu", "P");
            AltaActividad("Paseo por el Castillo", "Educación", new DateTime(2021, 12, 15, 10, 30, 0), "Castillo Pittamiglio", "C13");
            AltaActividad("Matrix Resurrections", "Cine", new DateTime(2021, 12, 10, 18, 45, 0), "El Galpón", "P");
            AltaActividad("Hamlet", "Teatro", new DateTime(2021, 11, 9, 19, 15, 0), "El Galpón", "C18");
            AltaActividad("Red Hot Chilli Peppers World Tour", "Concierto", new DateTime(2021, 11, 18, 21, 0, 0), "Centenario", "C16");
            AltaActividad("Eliminatorias Uruguay vs Colombia", "Deporte", new DateTime(2021, 10, 7, 19, 45, 0), "Centenario", "P");
            AltaActividad("Feria de foodtrucks", "Feria Gastronómica", new DateTime(2021, 12, 5, 16, 30, 0), "La Plaza", "P");
            AltaActividad("Feria de foodtrucks 2", "Feria Gastronómica", DateTime.Now, "La Plaza", "P");
            
        }
        #endregion

        #region Método PreCargarDatosCompras
        //*************** CARGA DE DATOS DE COMPRAS HARCODEADOS ***************
        private void PreCargarDatosCompras()
        {
            AltaCompra(1, "Fiesta de la Cerveza", 2, "fernanfernan1@skynet.net", new DateTime(2021, 11, 22));
            AltaCompra(2, "Juntada en la Intendencia", 1, "fefefer@skynet.net", new DateTime(2021, 11, 23));
            AltaCompra(3, "Competencia de cartas yugi", 3, "comunista104@pueblo.org", new DateTime(2021, 11, 20));
            AltaCompra(4, "Convención del Latu", 5, "fernanfernan1@skynet.net", new DateTime(2021, 11, 25));
            AltaCompra(5, "Red Hot Chilli Peppers World Tour", 5, "elpepe@presidencia.uy", new DateTime(2021, 11, 21));
            AltaCompra(6, "Paseo por el Castillo", 5, "mailUsuario@mail.com", DateTime.Now);
            AltaCompra(7, "Feria de foodtrucks", 2, "mailUsuario@mail.com", DateTime.Now);
            AltaCompra(8, "Matrix Resurrections", 5, "mailUsuario@mail.com", DateTime.Now);
            AltaCompra(9, "Matrix Resurrections", 1, "mailUsuario@mail.com", DateTime.Now);
            AltaCompra(10, "Feria de foodtrucks 2", 4, "mailUsuario@mail.com", DateTime.Now);
            AltaCompra(11, "Eliminatorias Uruguay vs Colombia", 3, "mailUsuario@mail.com", DateTime.Now);
        }
        #endregion

        #endregion

        #region Propiedades
        public List<Actividad> Actividades
        {
            get { return this.actividades; }
        }

        public List<Lugar> Lugares
        {
            get { return this.lugares; }
        }

        public List<Categoria> Categorias
        {
            get { return this.categorias; }
        }

        public List<Compra> Compras
        {
            get { return this.compras; }
        }

        #endregion

        #region Método ListarActividades
        //*************** METODO PARA MOSTRAR O LISTAR LAS ACTIVIDADES ***************
        public string ListarActividades()
        {
            string resultadoActividades = "";

            foreach (Actividad miActividad in actividades)
            {
                resultadoActividades += miActividad + "\n";
            }
            return resultadoActividades;
        }

        #endregion

        #region Método ListarCategorias
        //*************** METODO PARA MOSTRAR O LISTAR LAS ACTIVIDADES ***************
        public string ListarCategorias()
        {
            string resultadoCategorias = "";

            foreach (Categoria miCategoria in categorias)
            {
                resultadoCategorias += miCategoria.Nombre + " - ";
            }
            return resultadoCategorias;
        }
        #endregion

        #region Método CambiarAforoMaximo
        //*************** METODO PARA CAMBIAR EL AFORO MAXIMO ***************
        public string CambiarAforoMaximo(float nuevoPorcentajeAforoMaximo)
        {
            string nuevoValor = "";
            if (nuevoPorcentajeAforoMaximo > 0 && nuevoPorcentajeAforoMaximo < 101)
            {
                LugarCerrado.PorcentajeAforoMaximo = nuevoPorcentajeAforoMaximo;
                nuevoValor = "El nuevo valor para el Aforo Máximo es " + LugarCerrado.PorcentajeAforoMaximo + "%";
            }
            return nuevoValor;
        }
        #endregion

        #region Método CambiarPrecioButaca
        //*************** CAMBIAR VALOR DEL PRECIO DE BUTACAS QUE SE UTILIZAN EN LUGARES ABIERTOS ***************
        public string CambiarPrecioButaca(float nuevoPrecioButaca)
        {
            string nuevoValor = "";
            if (nuevoPrecioButaca > 0)
            {
                LugarAbierto.PrecioButaca = nuevoPrecioButaca;
                nuevoValor = "El nuevo precio para las Butaca es $" + LugarAbierto.PrecioButaca;
            }
            return nuevoValor;
        }
        #endregion

        #region Método ActividadesPorCategoriaEntreFechas
        //*************** DADA UNA CATEGORÍA, LISTAR LAS ACTIVIDADES DE ESA CATEGORÍA QUE SE REALICEN EN UN RANGO DE FECHAS DADO ***************
        public string ActividadesPorCategoriaEntreFechas(string categoria, DateTime fechaDesde, DateTime fechaHasta)
        {
            string resultadoActividades = "";
            Categoria miCategoria = BuscarCategoria(categoria);

            if (miCategoria != null && fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue)
            {
                //para evaluar las horas correctamente
                fechaHasta = fechaHasta.AddHours(23); //Agregamos 23 horas a fechaHasta
                fechaHasta = fechaHasta.AddMinutes(59); //Agregamos 59 minutos a fechaHasta
                fechaHasta = fechaHasta.AddSeconds(59); //Agregamos 59 segundos a fechaHasta

                foreach (Actividad miActividad in actividades)
                {
                    if (miActividad.Categoria == miCategoria && miActividad.FechaYHora >= fechaDesde && miActividad.FechaYHora <= fechaHasta)
                    {
                        resultadoActividades += miActividad + "\n";
                    }
                }
            }
            return resultadoActividades;
        }
        #endregion

        #region Método EspectaculosATP
        //*************** LISTAR ESPECTÁCULOS APTOS PARA TODO PÚBLICO ***************
        public string EspectaculosATP()
        {
            string resultadoEspectaculos = "";
            foreach (Actividad miActividad in actividades)
            {
                if (miActividad.EdadMinima == "P")
                {
                    resultadoEspectaculos += miActividad + "\n";
                }
            }
            return resultadoEspectaculos;
        }
        #endregion

        #region Método TieneEdadSuficiente
        //*************** METODO QUE VERIFICA EDAD MINIMA ***************
        public bool TieneEdadSuficiente(string edadActividad, UsuarioRegistrado usuarioInteresado)
        {
            bool resultado = true; //variable de retorno, true por defecto
            // Cálculo de edad del usuario
            int edadUsuario = DateTime.Now.Year - usuarioInteresado.FechaNacimiento.Year;

            // Posibles valores de edadActividad: P, C13, C16, C18
            // Cálculo de edad suficiente
            switch (edadActividad)
            {
                case "P":
                    break; // el resultado de un case "P" siempre será true
                case "C13":
                    if (edadUsuario < 13) { resultado = false; } // si edadComprador no llega a la edad mínima, devolveremos "resultado" con valor false
                    break;
                case "C16":
                    if (edadUsuario < 16) { resultado = false; }
                    break;
                case "C18":
                    if (edadUsuario < 18) { resultado = false; }
                    break;
                default: resultado = false; // si se ingresa una opción no válida, devolvemos False
                    break;
            }
            return resultado; //devolvemos resultado
        }
        #endregion

        #region Método BuscarCategoría
        //*************** METODO PARA BUSCAR UNA CATEGORIA ***************
        private Categoria BuscarCategoria(string nombre)
        {
            Categoria categoriaBuscada = null;
            int i = 0;
            while (i < categorias.Count && categoriaBuscada == null)
            {
                if (categorias[i].Nombre.ToUpper() == nombre.ToUpper())
                {
                    categoriaBuscada = categorias[i];
                }
                i++;
            }
            return categoriaBuscada;
        }
        #endregion

        #region Método BuscarCategoríaBool
        //Este método devolverá un bool para uso en Program
        public bool BuscarCategoriaBool(string nombre)
        {
            if (BuscarCategoria(nombre) != null)
            { return true; }
            else
            { return false; }
        }
        #endregion

        #region Método BuscarLugar
        //*************** METODO PARA BUSCAR UN LUGAR ***************
        private Lugar BuscarLugar(string nombre)
        {
            Lugar lugarBuscado = null;
            int i = 0;
            while (i < lugares.Count && lugarBuscado == null)
            {
                if (lugares[i].Nombre.ToUpper() == nombre.ToUpper())
                {
                    lugarBuscado = lugares[i];
                }
                i++;
            }
            return lugarBuscado;
        }
        #endregion

        #region Método BuscarActividad
        //*************** METODO PARA BUSCAR UNA ACTIVIDAD ***************
        public Actividad BuscarActividad(string nombre)
        {
            Actividad actividadBuscada = null;
            int i = 0;
            while (i < actividades.Count && actividadBuscada == null)
            {
                if (actividades[i].Nombre.ToUpper() == nombre.ToUpper())
                {
                    actividadBuscada = actividades[i];
                }
                i++;
            }
            return actividadBuscada;
        }
        #endregion

        #region Método para Login: ValidarUsuarioYOperador

        /*  Este metodo valida si los datos de usuario y contraseña corresponden con un usuario y devuelve: 0 si no se econtro usuario, 1 si el usuario encontrado es cliente y 2 si el usuario encontrado es operador*/
        public int ValidarUsuarioYOperador(string nombreUsuario, string contraseña)
        {
            int tipoUsuario = 0;
            int i = 0;
            while (i < usuarios.Count && tipoUsuario == 0)
            {

                if (usuarios[i].NombreUsuario.ToUpper().Equals(nombreUsuario.ToUpper()) && usuarios[i].Contraseña.Equals(contraseña))
                {
                    if (usuarios[i].EsOperador == true)
                    {
                        tipoUsuario = 2;
                    }
                    else
                    {
                        tipoUsuario = 1;
                    }
                }
                i++;
            }
            return tipoUsuario;
        }

        #endregion

        #region BuscarUsuario

        //*************** METODO PARA BUSCAR UN USUARIO ***************
        //NOTA: fue necesario convertir este método a Public para que pueda trabajar con MVC
        public UsuarioRegistrado BuscarUsuario(string entrada) // entrada puede ser email o nombre de usuario
        {
            UsuarioRegistrado usuarioBuscado = null; //usuarioBuscado tiene por defecto valor null
            int i = 0; //contador
            while (i < usuarios.Count && usuarioBuscado == null) //loop de la lista usuarios, mientras usuarioBuscado valga null
            {
                //buscaremos el usuario por nombre o por email
                if (usuarios[i].Mail.ToUpper() == entrada.ToUpper() || usuarios[i].NombreUsuario.ToUpper() == entrada.ToUpper()) 
                //Si "entrada" es igual al email o nombre de usuario de algún usuario existente
                {
                    usuarioBuscado = usuarios[i]; //devolver ese usuario
                }
                i++; //incrementar contador
            }
            return usuarioBuscado; //devolver valor de usuarioBuscado
        }

        #endregion

        #region BuscarCompra
        //*************** METODO PARA BUSCAR UNA COMPRA ***************
        public Compra BuscarCompra(int id)
        {
            Compra compraBuscado = null;
            int i = 0;
            while (i < compras.Count && compraBuscado == null)
            {
                if (compras[i].Id == id)
                {
                    compraBuscado = compras[i];
                }
                i++;
            }
            return compraBuscado;
        }
        #endregion

        #region Método AltaLugarAbierto
        //*************** METODO PARA DAR DE ALTA UN LUGAR ABIERTO***************
        private void AltaLugarAbierto(int id, string nombre, float dimensionesM2)
        {
            if (nombre != "" && dimensionesM2 > 0 && id > 0) //si los datos no están vacíos
            {
                if (BuscarLugar(nombre) == null)
                {
                    this.lugares.Add(new LugarAbierto(id, nombre, dimensionesM2));
                }
            }
        }
        #endregion

        #region Método AltaLugarCerrado
        //*************** METODO PARA DAR DE ALTA UN LUGAR CERRADO***************
        private void AltaLugarCerrado(int id, string nombre, float dimensionesM2, bool accesibilidad, float valorMantenimiento)
        {
            if (nombre != "" && dimensionesM2 > 0  && id > 0 && valorMantenimiento > 0) //si los datos no están vacíos
            {
                if (BuscarLugar(nombre) == null)
                {
                    this.lugares.Add(new LugarCerrado(id, nombre, dimensionesM2, accesibilidad, valorMantenimiento));
                }
            }
        }
        #endregion

        #region Método AltaCategoria
        //*************** METODO PARA DAR DE ALTA UNA CATEGORIA***************
        private void AltaCategoria(string nombre, string descripcion)
        {
            if (nombre != "" && descripcion != "") //si los datos no están vacíos
            {
                if (BuscarCategoria(nombre) == null)
                {
                    this.categorias.Add(new Categoria(nombre, descripcion));
                }
            }
        }
        #endregion

        #region Método AltaActividad
        //*************** METODO PARA DAR DE ALTA UNA ACTIVIDAD***************
        private void AltaActividad(string nombre, string miCategoria, DateTime fechaYHora, string miLugar, string edadMinima)
        {
            Lugar lugarObj = BuscarLugar(miLugar);
            Categoria categoriaObj = BuscarCategoria(miCategoria);
            if (nombre != "" && categoriaObj != null && fechaYHora > DateTime.MinValue && lugarObj != null && ValidarCodigoDeEdad(edadMinima)) //si los datos no están vacíos
            {
                this.actividades.Add(new Actividad(nombre, categoriaObj, fechaYHora, lugarObj, edadMinima));
            }
        }
        #endregion

        #region Método Auxiliar: ValidarCodigoDeEdad
        //*************** METODO AUXILIAR PARA VALIDAR EL CODIGO DE EDAD MINIMA***************
        private bool ValidarCodigoDeEdad(string texto)
        {
            if (texto != "P" && texto != "C13" && texto != "C16" && texto != "C18")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Método AltaUsuarios
        //*************** METODO PARA DAR DE ALTA UN USUARIO***************
        public string AltaUsuarios(string nombre, string apellido, string mail, DateTime fechaNacimiento, string nombreUsuario, string contraseña, bool esOperador)//AGREGADO los parametros correspodientes al usuario y contraseña **Obligatorio 2**
        {
            string mensaje = "Error en los datos";
            if (nombre != "" && apellido != "" && mail != "" && fechaNacimiento > DateTime.MinValue) //si los datos no están vacíos
            {
                if (BuscarUsuario(mail) == null) //confirmamos que el usuario no exista todavía
                {
                    this.usuarios.Add(new UsuarioRegistrado(nombre, apellido, mail, fechaNacimiento, nombreUsuario, contraseña, esOperador)); //agregamos una nueva instancia de UsuarioRegistrado a la lista de usuarios
                    mensaje = "Usuario creado con exito";

                }
            }
            return mensaje;
        }
        #endregion

        #region Métodos AltaCompra (sobrecarga)
        //*************** METODO PARA DAR DE ALTA UNA COMPRA***************
        public void AltaCompra(int id, string actividadNombre, int cantidadEntradas, string usuarioMailOUser)
        {
            Actividad actividadObj = BuscarActividad(actividadNombre);
            UsuarioRegistrado usuarioObj = BuscarUsuario(usuarioMailOUser);
            bool puedeEntrar = TieneEdadSuficiente(actividadObj.EdadMinima, usuarioObj);
            if (id > 0 && actividadObj != null && cantidadEntradas > 0 && usuarioObj != null && puedeEntrar) //verificamos los datos (que no estén vacíos, que los números sean > 0 y que la edad del usuario sea la apropiada)
            {
                if (BuscarCompra(id) == null) //verificamos que no exista otra compra con el mismo ID
                {
                    //creación de instancia de Compra
                    this.compras.Add(new Compra(id, actividadObj, cantidadEntradas, usuarioObj));
                }
            }
        }

        //SOBRECARGA DE METODO AltaCompra PARA PODER HARDCODEAR LA FECHA Y HORA PARA LA PRECARGA DE DATOS
        private void AltaCompra(int id, string actividadNombre, int cantidadEntradas, string usuarioMailOUser, DateTime fechaYHora)
        {
            Actividad actividadObj = BuscarActividad(actividadNombre);
            UsuarioRegistrado usuarioObj = BuscarUsuario(usuarioMailOUser);
            bool puedeEntrar = TieneEdadSuficiente(actividadObj.EdadMinima, usuarioObj);
            if (id > 0 && actividadObj != null && cantidadEntradas > 0 && usuarioObj != null && puedeEntrar && fechaYHora > DateTime.MinValue) 
            {
                if (BuscarCompra(id) == null)
                {
                    this.compras.Add(new Compra(id, actividadObj, cantidadEntradas, usuarioObj, fechaYHora));
                }
            }
        }
        #endregion

        #region Método Validar Contraseña
        public bool ValidarContraseña(string contraseña)
        {
            bool contraseñaValida = false; //bool de retorno
            bool hayDigito = false; // bool de control de dígito
            bool hayMayuscula = false; // bool de control de mayúscula
            bool hayMinuscula = false; // bool de ceontrol de minúscula
            int i = 0;

            //verificación de mayúscula, minúscula y dígito
            while (!contraseñaValida && i < contraseña.Length)
            {
                Char Caracter = contraseña[i];
                if (Char.IsUpper(Caracter))
                { hayMayuscula = true; }
                if (Char.IsDigit(Caracter))
                { hayDigito = true; }
                if (Char.IsLower(Caracter))
                { hayMinuscula = true; }

                if (hayMinuscula && hayMayuscula && hayDigito)
                { contraseñaValida = true; }

                i++;
            }

            return contraseñaValida;
        }
        #endregion

        #region Método Ordenar clientes por apellido y nombre
        //*************** METODO PARA ORDENADAR POR APELLIDO Y NOMBRE ASCENDENTE LOS USUARIOS CLIENTES (SIN OPERADORES)  ***************

        public List<UsuarioRegistrado> UsuariosClientesOrdenadosPorApellidoYNombre()
        {
            List<UsuarioRegistrado> misClientesOrdenados = ListaDeUsuarioCliente();
            misClientesOrdenados.Sort();
            return misClientesOrdenados;
        }
        #endregion

        #region Método Listar UsuariosClientes (Sin usuario operador)
        //*************** METODO PARA ARMAR UNA LISTA CON SOLO USUARIOS CLIENTES (SIN OPERADORES) ***************
        private List<UsuarioRegistrado> ListaDeUsuarioCliente()
        {
            List<UsuarioRegistrado> misUsuariosClientes = new List<UsuarioRegistrado>();

            foreach (UsuarioRegistrado miUsuario in usuarios)
            {
                if (!miUsuario.EsOperador)
                {
                    misUsuariosClientes.Add(miUsuario);
                }
            }
            return misUsuariosClientes;
        }
        #endregion

        #region Método Compras entre fechas
        //*************** METODO PARA LISTAR LAS COMPRAS REALIZADAS ENTRE 2 FECHAS DADAS  ***************

        public List<Compra> ComprasEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {

            List<Compra> misComprasEntreFechas = new List<Compra>();
           
            if (fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue && fechaHasta > fechaDesde)
            {
                //para evaluar las horas correctamente
                fechaHasta = fechaHasta.AddHours(23); //Agregamos 23 horas a fechaHasta
                fechaHasta = fechaHasta.AddMinutes(59); //Agregamos 59 minutos a fechaHasta
                fechaHasta = fechaHasta.AddSeconds(59); //Agregamos 59 segundos a fechaHasta

                foreach (Compra miCompra in compras)
                {
                    if (miCompra.FechaYHora >= fechaDesde && miCompra.FechaYHora <= fechaHasta)
                    {
                        misComprasEntreFechas.Add(miCompra);
                    }
                }
            }
            return misComprasEntreFechas;
        }

        #endregion

        #region Método Listar Actividades segun Lugar
        //*************** METODO PARA LISTAR LAS ACTIVIDADES SEGUN UN LUGAR DADO  ***************

        public List<Actividad> ListarActividadesPorLugar(string lugar)
        {

            List<Actividad> misActividadesPorLugar = new List<Actividad>();

            if (lugar !="-1")
            {
                foreach (Actividad miActividad in actividades)
                {
                    if (miActividad.Lugar.Nombre == lugar)
                    {
                        misActividadesPorLugar.Add(miActividad);
                    }
                }
            }
            return misActividadesPorLugar;
        }

        #endregion

        #region Método ActividadesPorCategoriaEntreFechas LIST
        //*************** DADA UNA CATEGORÍA, LISTAR LAS ACTIVIDADES DE ESA CATEGORÍA QUE SE REALICEN EN UN RANGO DE FECHAS DADO --> EDITADO PARA QUE DEVUELVA UNA LISTA EN VEZ DE STRING***************
        public List<Actividad> ActividadesPorCategoriaEntreFechasObligatorio2(string categoria, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Actividad> resultadoActividades = new List<Actividad>();

            Categoria miCategoria = BuscarCategoria(categoria);

            if (miCategoria != null && fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue && fechaDesde > fechaHasta)
            {
                //para evaluar las horas correctamente
                fechaHasta = fechaHasta.AddHours(23); //Agregamos 23 horas a fechaHasta
                fechaHasta = fechaHasta.AddMinutes(59); //Agregamos 59 minutos a fechaHasta
                fechaHasta = fechaHasta.AddSeconds(59); //Agregamos 59 segundos a fechaHasta

                foreach (Actividad miActividad in actividades)
                {
                    if (miActividad.Categoria == miCategoria && miActividad.FechaYHora >= fechaDesde && miActividad.FechaYHora <= fechaHasta)
                    {
                        resultadoActividades.Add(miActividad);
                    }
                }
            }
            return resultadoActividades;
        }
        #endregion

        #region Método Maximo Compras
        //*************** METODO PARA ORDENADAR POR VALOR LAS COMPRAS  ***************

        public List<Compra> MaximoCompras()
        {
            List<Compra> misComrpasMayorValor = new List<Compra>();
            float maximoCompras = float.MinValue;

            foreach (Compra miCompra in compras)
            {
                if (miCompra.PrecioFinal > maximoCompras)
                {
                    maximoCompras = miCompra.PrecioFinal;
                    misComrpasMayorValor.Clear();
                    misComrpasMayorValor.Add(miCompra);
                }
                else if (miCompra.PrecioFinal == maximoCompras)
                {
                    misComrpasMayorValor.Add(miCompra);
                }
            }
            
            return misComrpasMayorValor;
        }
        #endregion

        #region Método Filtrar Compras segun Usuario
        //*************** METODO PARA LISTAR LAS COMPRAS DE UN USUARIO ESPECIFICO  ***************

        public List<Compra> ListarComprasPorUsuario(string usuario)
        {

            List<Compra> misComprasPorUsuario = new List<Compra>();
                        
            if (usuario != "" && usuario != null)
            {
                int idUsuario = BuscarUsuario(usuario).Id;
                foreach (Compra miCompra in compras)
                {
                    if (miCompra.UsuarioComprador.Id == idUsuario)
                    {
                        misComprasPorUsuario.Add(miCompra);
                    }
                }
            }
            return misComprasPorUsuario;
        }

        #endregion 

        #region Método Cancelar compra
        //*************** METODO PARA CAMBIAR EL ESTADO DE UNA COMPRA SEGUN ID  ***************

        public void CancelarCompra(int idCompra)
        {                        
            if (idCompra >0)
            {
                Compra miCompra = BuscarCompra(idCompra);
                miCompra.EstaActiva = false;
            }
        }

        #endregion 

        #region Método Dar Me Gusta Actividad
        //*************** METODO PARA DAR MEGUSTA A UNA ACTIVIDAD SEGUN EL NOMBRE  ***************

        public void DarMeGusta(string actividadNombre)
        {
            if (actividadNombre !="" && actividadNombre !=null)
            {
                Actividad miActividad = BuscarActividad(actividadNombre);
                miActividad.MeGusta++;
            }            
        }

        #endregion 

        #region Método Sumar Compras Activas
        //*************** METODO PARA SUMAR UNA LISTA DE COMPRAS ACTIVAS  ***************

        public float SumaDeComprasActivas(List<Compra> misCompras)
        {
            float resultadoSuma = 0;
            if (misCompras != null)
            {                
                foreach (Compra miCompra in misCompras)
                {
                    if (miCompra.EstaActiva)
                    {
                        resultadoSuma += miCompra.PrecioFinal;
                    }                    
                }
            }
            return resultadoSuma;
        }
        #endregion 

    }
}
    
    


