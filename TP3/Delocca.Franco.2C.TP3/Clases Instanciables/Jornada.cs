using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        } 
        #endregion

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #region Metodos
        /// <summary>
        /// Guarda el archivo de jornada en un txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        //NO SE GUARDA EN EL DESKTOP SE GUARDA EN EL DEBUG DE CONSOLA
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";

            return archivoTexto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Leo el archivo guardado de jornada
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";
            string datosArchivo;

            archivoTexto.Leer("Jornada.txt", out datosArchivo);

            return datosArchivo;
        }

        /// <summary>
        /// Muestro los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CLASE: " + this.clase);
            stringBuilder.AppendFormat("INSTRUCTOR: " + this.instructor.ToString());

            foreach (Alumno item in this.alumnos)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Si el alumno participa en la clase es igual
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {

            foreach (Alumno item in j.alumnos)
            {
                if (a == item)
                {
                    return true;
                }
            }
            return false;

        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrego un alumno a la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a && a == j.clase)
            {
                j.alumnos.Add(a);
            }
            return j;
        }  
        #endregion

    }
}
