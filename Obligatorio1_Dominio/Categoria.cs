using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class Categoria
    {
        #region Atributos
        private string nombre;
        private string descripcion;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
        }
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE CATEGORIA***************
        public Categoria(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        #endregion

        #region ToString Categoria
        public override string ToString() 
        {
            return $"{this.nombre} ({this.descripcion})";
        }
        #endregion
    }
}
