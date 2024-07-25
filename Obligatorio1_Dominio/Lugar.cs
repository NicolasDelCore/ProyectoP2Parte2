using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public abstract class Lugar
    {
        #region Atributos
        private int id;
        private string nombre;
        private float dimensionesM2;
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
        public float DimensionesM2
        {
            get { return this.dimensionesM2; }
        }

        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE LUGAR***************
        public Lugar(int id, string nombre, float dimensionesM2)
        {
            this.id = id;
            this.nombre = nombre;
            this.dimensionesM2 = dimensionesM2;
        }
        #endregion

        #region ToString Lugar (nombre)
        public override string ToString() 
        {
            return this.nombre;
        }
        #endregion

        #region Calculo de costo adicional
        public abstract float costoAdicional();       
        #endregion
    }

}
