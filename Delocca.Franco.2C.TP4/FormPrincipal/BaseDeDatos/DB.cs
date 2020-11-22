using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaseDeDatos
{
    public class DB
    {
        /// <summary>
        /// Seteo la cadena de conexion
        /// </summary>
        static private string cadenaDeConexion = "Server=.\\SQLEXPRESS; DataBase=PRACTICA_TABLAS; Integrated Security=true";

        private SqlConnection conexion = new SqlConnection(cadenaDeConexion);

        /// <summary>
        /// Primero me fijo si la conexion esta cerrada y si lo esta la abro
        /// </summary>
        /// <returns></returns>
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        /// <summary>
        /// Primero me fijo si la conexion esta abierta y si lo esta la cierro
        /// </summary>
        /// <returns></returns>
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }


    }
}
