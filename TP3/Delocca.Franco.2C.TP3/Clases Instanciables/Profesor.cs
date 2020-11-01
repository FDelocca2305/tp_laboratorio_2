using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    sealed public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor()
            :base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #region Metodos
        /// <summary>
        /// Asigno clases random
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int opcion = random.Next(0, 3);

                switch (opcion)
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }


        /// <summary>
        /// Muestro los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.MostrarDatos());
            stringBuilder.AppendFormat(this.ParticiparEnClase());

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Clases que da el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CLASES DEL DIA");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        } 
        #endregion

        #region Operadores
        /// <summary>
        /// El profesor es igual cuando de esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// El profesor no es igual caundo no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        } 
        #endregion
    }
}
