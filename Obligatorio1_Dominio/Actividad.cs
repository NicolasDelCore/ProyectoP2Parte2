using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class Actividad
    {
        #region Atributos
        private int id;
        private static int ultimoId = 1;
        private string nombre;
        private Categoria categoria;
        private DateTime fechaYHora;
        private Lugar lugar;
        private string edadMinima;
        private static float precioBase = 500; //precio base de TODAS las actividades
        private int meGusta;
        private float precioFinal; //precio final, calculado en la creación de la instancia
        #endregion

        #region Propiedades
        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public Categoria Categoria
        {
            get { return this.categoria; }
        }
        public DateTime FechaYHora
        {
            get { return this.fechaYHora; }
        }

        public Lugar Lugar
        {
            get { return this.lugar; }
        }
        public string EdadMinima
        {
            get { return this.edadMinima; }
        }
        public float PrecioBase
        {
            get { return Actividad.precioBase; }
        }
        public int MeGusta
        {
            get { return this.meGusta; }
            set { this.meGusta = value; } 
        }
        public float PrecioFinal
        {
            get { return this.precioFinal; }
        }
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE ACTIVIDAD***************
        public Actividad(string nombre, Categoria miCategoria, DateTime fechaYHora, Lugar miLugar, string edadMinima)
        {
            this.id = Actividad.ultimoId; //asignamos el valor del atrib de clase "ultimoId" como atrib "id" de la instancia
            Actividad.ultimoId++; //aumentamos el atributo contador de clase, ultimoId
            this.nombre = nombre;
            this.categoria = miCategoria;
            this.fechaYHora = fechaYHora;
            this.lugar = miLugar;
            this.edadMinima = edadMinima;
            this.meGusta = 0; //Contador miembro de instancia que incrementará luego de creado el obj Actividad, cuando se implemente una función para aumentar los "Me Gusta"
            this.precioFinal = calcularPrecioSegunLugar();
        }
        #endregion

        #region ToString Actividad
        public override string ToString()
        {
            return $"\nNombre: {this.nombre}\nCategoría: {this.categoria}\nFecha: {this.fechaYHora}\nLugar: {this.lugar}\nEdad mínima: {this.edadMinima}\nPrecio: {this.precioFinal} MeGusta: {this.meGusta}"; 
        }
        #endregion

        #region Calculo de precio
        public float calcularPrecioSegunLugar()
        {
            return precioBase * lugar.costoAdicional();
        }
        #endregion
    }
}
