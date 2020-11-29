using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion lanzada cuando hay error con el proceso de algun archivo
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : this("Se produjo un error en la escritura del archivo: " + innerException.Message)
        {

        }

        /// <summary>
        /// Excepcion lanzada cuando hay error con el proceso de algun archivo
        /// </summary>
        public ArchivosException()
            : this("Se produjo un error en la escritura del archivo")
        {

        }

        /// <summary>
        /// Excepcion lanzada cuando hay error con el proceso de algun archivo
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException(string message)
            : base(message)
        {

        }
    }
}
