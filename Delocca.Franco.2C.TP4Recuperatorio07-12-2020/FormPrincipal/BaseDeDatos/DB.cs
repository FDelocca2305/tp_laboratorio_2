using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excepciones;

namespace BaseDeDatos
{
    public class DB
    {
        /// <summary>
        /// Seteo la cadena de conexion
        /// </summary>
        static private string cadenaDeConexion = "Server=.\\SQLEXPRESS; DataBase=FrancoDeloccaTP4Recuperatorio; Integrated Security=true";

        private SqlConnection conexion = new SqlConnection(cadenaDeConexion);

        /// <summary>
        /// Primero me fijo si la conexion esta cerrada y si lo esta la abro
        /// </summary>
        /// <returns></returns>
        public SqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception)
            {

                throw new ErrorDataBaseException("Hubo un error al estableceer la conexion a la base de datos");
            }
            
            return conexion;
        }

        /// <summary>
        /// Primero me fijo si la conexion esta abierta y si lo esta la cierro
        /// </summary>
        /// <returns></returns>
        public SqlConnection CerrarConexion()
        {

            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception)
            {

                throw new ErrorDataBaseException("Hubo un error al finalizar la conexion a la base de datos");
            }
            
            return conexion;
        }


    }
}
