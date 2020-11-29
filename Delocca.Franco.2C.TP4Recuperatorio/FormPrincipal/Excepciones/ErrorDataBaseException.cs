using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorDataBaseException : Exception
    {
        /// <summary>
        /// Excepcion lanzada cuando hay algun error con la base de datos
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ErrorDataBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Excepcion lanzada cuando hay algun error con la base de datos
        /// </summary>
        /// <param name="message"></param>
        public ErrorDataBaseException(string message) : base(message)
        {
        }
    }
}
