using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {

        public ArchivosException(Exception innerException)
            :this("Se produjo un error en la lectura/escritura del archivo: " + innerException.Message)
        {

        }

        public ArchivosException()
            : this("Se produjo un error en la lectura/escritura del archivo")
        {

        }

        public ArchivosException(string message)
            :base(message)
        {

        }
        
        
    }
}
