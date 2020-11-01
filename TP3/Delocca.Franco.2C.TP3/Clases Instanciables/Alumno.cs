using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    sealed public class Alumno : Universitario
    {

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        public Alumno()
            :base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        #region Metodos
        /// <summary>
        /// Muestro sus datos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.MostrarDatos());
            stringBuilder.AppendFormat("ESTADO CUENTA: {0}\n", this.estadoCuenta);
            stringBuilder.AppendFormat(this.ParticiparEnClase());

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Muestro la clase en la que participa
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("TOMA CLASE DE {0}\n", this.claseQueToma);

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// El alumno es igual a la clase si la toma y no debe nada
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Si el alumno no toma la clase es distinto
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        } 
        #endregion
    }
}
