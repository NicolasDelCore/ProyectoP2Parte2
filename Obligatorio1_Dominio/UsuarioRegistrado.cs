using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class UsuarioRegistrado:IComparable<UsuarioRegistrado>
    {
        #region Atributos
        private int id;
        private static int ultimoId = 1;
        private string nombre;
        private string apellido;
        private string mail;
        private DateTime fechaNacimiento;
        //atributos de sesión **Obligatorio 2**
        private string nombreUsuario;
        private string contraseña;
        private bool esOperador;
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
        public string Apellido
        {
            get { return this.apellido; }
        }
        public string Mail
        {
            get { return this.mail; }
        }
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
        }

        //Propiedades de sesión **Obligatorio 2**
        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
        }
        public string Contraseña
        {
            get { return this.contraseña; }
        }
        public  bool EsOperador
        {
            get { return this.esOperador; }
        }
        #endregion
         
        #region Constructores
        //*************** METODO CONSTRUCTOR DE USUARIO ***************
        public UsuarioRegistrado(string nombre, string apellido, string mail, DateTime fechaNacimiento, string nombreUsuario, string contraseña, bool esOperador)
        {
            this.id = UsuarioRegistrado.ultimoId; //id autonumérico de instancia
            UsuarioRegistrado.ultimoId++; //+1 al contador de instancias de la clase UsuarioRegistrado
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.fechaNacimiento = fechaNacimiento;
            //parametros de sesión **Obligatorio 2**
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
            this.esOperador = esOperador; 
        }
        #endregion

        #region Comparacion

        //*************** METODO PARA COMPARAR USUARIOS***************
        public int CompareTo([AllowNull] UsuarioRegistrado other)
        {
            int comparacion = this.apellido.CompareTo(other.Apellido);
            if (comparacion == 0)
            {
                comparacion = this.nombre.CompareTo(other.Nombre);//ascendente por defecto
            }
            return comparacion;
        }
        #endregion

        #region ToString UsuarioRegistrado
        public override string ToString()
        {
            return $"\nID: {this.id}\nNombre: {this.nombre}\nApellido: {this.apellido}\nFecha de nacimiento: {this.fechaNacimiento.ToShortDateString()}\nMail: {this.mail}\n";
        }
        #endregion
    }
}
