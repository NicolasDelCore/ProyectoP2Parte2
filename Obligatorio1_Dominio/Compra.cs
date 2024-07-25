using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class Compra
    {
        #region Atributos
        private int id;
        private Actividad actividad;
        private int cantidadEntradas;
        private DateTime fechaYHora;
        private bool estaActiva;
        private float precioFinal;
        private UsuarioRegistrado usuarioComprador;
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE COMPRA***************
        public Compra(int id, Actividad actividad, int cantidadEntradas, UsuarioRegistrado usuarioComprador)
        {
            this.id = id;
            this.actividad = actividad;
            this.cantidadEntradas = cantidadEntradas;
            this.fechaYHora = DateTime.Now; //La compra se efectúa en el momento en que se da de alta un objeto tipo Compra
            this.estaActiva = true; //Por defecto, al crear la instancia, el atributo estaActiva será true, dado que la compra acaba de ocurrir
            this.precioFinal = AplicarDescuento();
            this.usuarioComprador = usuarioComprador;
        }
        

        //SOBRECARGA DE METODO CONSTRUCTOR PARA PODER HARDCODEAR LA FECHA Y HORA PARA LA PRECARGA DE DATOS
        public Compra(int id, Actividad actividad, int cantidadEntradas, UsuarioRegistrado usuarioComprador, DateTime fechaYHora)
        {
            this.id = id;
            this.actividad = actividad;
            this.cantidadEntradas = cantidadEntradas;
            this.fechaYHora = fechaYHora; 
            this.estaActiva = true; 
            this.precioFinal = AplicarDescuento();
            this.usuarioComprador = usuarioComprador;
        }
        #endregion

        #region Propiedades
        public int Id
        {
            get { return this.id; }
        }
        public Actividad Actividad
        {
            get { return this.actividad; }
            set { this.actividad = value; } //para actualizar si la compra se canceló o no
        }
        public int CantidadEntradas
        {
            get { return this.cantidadEntradas; }
        }
        public DateTime FechaYHora
        {
            get { return this.fechaYHora; }
        }
        public bool EstaActiva
        {
            get { return this.estaActiva; }
            set { this.estaActiva = value; }
        }
        public float PrecioFinal
        {
            get { return this.precioFinal; }
        }
        public UsuarioRegistrado UsuarioComprador
        {
            get { return this.usuarioComprador; }
        }
        #endregion

        #region Calculo de precio Total
        private float AplicarDescuento()
        {
            float precioTotal = actividad.PrecioFinal * cantidadEntradas; //precio sin descuento
            if (this.cantidadEntradas > 5) //descuento si lleva más de 5 entradas
            {
                precioTotal = precioTotal - ((5 * precioTotal) / 100);
            }
            return precioTotal;
        }
        #endregion

        #region ToString Compra
        public override string ToString()
        {
            string Activa = "Activa";
            if (!this.estaActiva)
            {
                Activa = "Cancelada";
            }
            
            return $"\nID: {this.id}\nActividad: {this.actividad.Nombre}\n Lugar: {this.actividad.Lugar}\nPrecio por entrada: {this.actividad.PrecioFinal}\nCantidad de Entradas: {this.cantidadEntradas}\nFecha Y Hora de Compra: {this.fechaYHora}\nFecha y Hora de Actividad: {this.actividad.FechaYHora}\nEstado: {Activa}\nPrecio Total Compra: {this.precioFinal} \nUsuario Comprador: ID {this.usuarioComprador.Id} - Nombre {this.usuarioComprador.Nombre} - Apellido {this.usuarioComprador.Apellido}";

        }
        #endregion

    }
}
