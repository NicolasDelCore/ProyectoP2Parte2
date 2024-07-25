using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{

    public class LugarAbierto : Lugar
    {
        #region Atributos
        private static float precioButaca = 150;
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE LUGAR ABIERTO***************
        public LugarAbierto(int id, string nombre, float dimensionesM2) : base(id, nombre, dimensionesM2)
        {
        }
        #endregion

        #region Propiedades
        public static float PrecioButaca
        {
            set { LugarAbierto.precioButaca = value; }
            get { return LugarAbierto.precioButaca; }
        }
        #endregion

        #region Overrride Calculo de costo adicional
        public override float costoAdicional()
        {
            float multiplicador = 1f;

            if (this.DimensionesM2 > 1)
            {
                multiplicador = 1.1f;
            }

            return multiplicador;
        }
        #endregion
    }
}
