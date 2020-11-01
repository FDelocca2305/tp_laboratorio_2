using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #region Metodos
        /// <summary>
        /// Valida si dos objetos son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {

            if (obj is Universitario)
            {
                return this == (Universitario)obj;
            }

            return false;
        }

        /// <summary>
        /// Muestra sus datos
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return stringBuilder.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion


        #region Operadores
        /// <summary>
        /// Veo si dos universitarios son iguales por si legajo o dni y su tipo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if ((object)pg1 != null && (object)pg2 != null)
            {
                if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Veo si dos universitarios son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        } 
        #endregion
    }
}
