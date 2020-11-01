using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesor;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i <= this.jornada.Count || i > 0)
                {
                    return this.jornada[i];
                }
                else
                {
                    throw new ArchivosException("Indice invalido");
                }
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
                else if (i == this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        } 
        #endregion

        public Universidad()
        {
            this.profesor = new List<Profesor>();
            this.jornada = new List<Jornada>();
            this.alumnos = new List<Alumno>();
        }

        #region Metodos
        /// <summary>
        /// Guarda en archivo xml la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        //NO SE GUARDA EN EL DESKTOP SE GUARDA EN EL DEBUG DE CONSOLA
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UniversidadPrueba.xml";
            return xml.Guardar("Universidad.xml", uni);

        }

        /// <summary>
        /// Leo el archivo xml que se genero
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.xml";

            try
            {
                xml.Leer("Universidad.xml", out universidad);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return universidad;
        }


        /// <summary>
        /// Muestro todos los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < uni.jornada.Count; i++)
            {
                stringBuilder.AppendLine("JORNADA");
                stringBuilder.AppendFormat("CLASE DE {0} POR {1}\n\n", (uni.jornada[i]).Clase, ((uni.jornada[i]).Instructor).ToString());
                stringBuilder.AppendLine("ALUMNOS");
                foreach (Alumno item in (uni.jornada[i]).Alumnos)
                {
                    stringBuilder.AppendLine(item.ToString());

                }
                stringBuilder.AppendLine("<------------------------------------------------------>");
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Es igual cuando un alumno esta inscripto
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (a.Equals(item))
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Distinto si no esta inscripto
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Es igual si el profesor esta dando clases
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesor)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Es distinta si el profesor no da clases
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el profe que puede dar esa clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesor)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el profe que no pueda dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = new Profesor();
            foreach (Profesor item in u.profesor)
            {
                if (item != clase)
                {
                    profesor = item;
                    break;
                }
            }
            return profesor;
        }

        /// <summary>
        /// Agergo alumno a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrego un profesor a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesor.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Agrego jornada
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            int i = g.jornada.Count;
            g[i] = new Jornada(clase, g == clase);

            foreach (Alumno item in g.alumnos)
            {
                g.jornada[i] += item;
            }

            return g;
        } 
        #endregion

    }
}
