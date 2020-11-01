using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, miCodificacion))
                {
                    sw.WriteLine(datos);
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamReader streamReader = new StreamReader(archivo, miCodificacion))
                {
                    datos = streamReader.ReadToEnd();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
