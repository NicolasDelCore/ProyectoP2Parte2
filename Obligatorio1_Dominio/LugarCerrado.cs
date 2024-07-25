using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1_Dominio
{
    public class LugarCerrado : Lugar
    {

        #region Atributos
        private bool accesibilidad;
        private float valorMantenimiento;
        private static float porcentajeAforoMaximo = 43;
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE LUGAR CERRADO***************
        public LugarCerrado(int id, string nombre, float dimensionesM2, bool accesibilidad, float valorMantenimiento) : base(id, nombre, dimensionesM2)
        {
            this.accesibilidad = accesibilidad;
            this.valorMantenimiento = valorMantenimiento;
        }
        #endregion

        #region Propiedades
        public static float PorcentajeAforoMaximo 
        {
            set { LugarCerrado.porcentajeAforoMaximo = value; }
            get { return LugarCerrado.porcentajeAforoMaximo; }
        }
        #endregion

        #region Override Calculo de costo adicional
        public override float costoAdicional()
        {
            float multiplicador = 1f;

            if (LugarCerrado.porcentajeAforoMaximo < 50 )
            {
                multiplicador = 1.3f;
            }
            else if (LugarCerrado.porcentajeAforoMaximo >= 50 && LugarCerrado.porcentajeAforoMaximo <= 70)
            {
                multiplicador = 1.15f;
            }

            return multiplicador;
        }
        #endregion
    }
}
