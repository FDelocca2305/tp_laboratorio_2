using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace BaseDeDatos
{
    public class VentasDAO
    {
        private DB conexion = new DB();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader LeerFilas;

        /// <summary>
        /// Listo productos mediante un store procedure
        /// </summary>
        /// <returns></returns>
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();

            command.CommandText = "ListarProductosVenta";
            command.CommandType = CommandType.StoredProcedure;

            LeerFilas = command.ExecuteReader();

            tabla.Load(LeerFilas);

            conexion.CerrarConexion();

            return tabla;

        }



        /// <summary>
        /// Listar ventas de la tabla ventas mediante un store procedure
        /// </summary>
        /// <returns></returns>
        public DataTable ListarVentas()
        {

            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();

            command.CommandText = "ListarVentas";
            command.CommandType = CommandType.StoredProcedure;

            LeerFilas = command.ExecuteReader();

            tabla.Load(LeerFilas);

            conexion.CerrarConexion();

            return tabla;
        }

        /// <summary>
        /// Inserto ventas en la tabla pasandole el objeto creado con los datos necesarios
        /// </summary>
        /// <param name="venta"></param>
        public void InsertarVentas(Venta venta)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "insert into VENTAS (IDPRODUCTO,CANTIDAD,TOTAL) values (@idproducto,@cantidad,(SELECT precio FROM PRODUCTOS where IDPROD = @idproducto) * @cantidad)";

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@idproducto", venta.IdProducto);
            command.Parameters.AddWithValue("@cantidad", venta.Cantidad);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        /// <summary>
        /// Edito la venta por id pasandole los datos cambiados por el objeto
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="venta"></param>
        public void EditarVentas(int idVenta, Venta venta)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "UPDATE VENTAS SET IDPRODUCTO=@idproducto, CANTIDAD=@cantidad, TOTAL=(@cantidad * (SELECT PRECIO FROM PRODUCTOS WHERE IDPROD = @idproducto)) WHERE IDVENTAS = @id ";

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@id", idVenta);

            command.Parameters.AddWithValue("@idproducto", venta.IdProducto);
            command.Parameters.AddWithValue("@cantidad", venta.Cantidad);


            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();

        }

        /// <summary>
        /// Elimino una venta por id
        /// </summary>
        /// <param name="idVenta"></param>
        public void EliminarVenta(int idVenta)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "DELETE FROM VENTAS WHERE IDVENTAS = @id";

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@id", idVenta);

            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        /// <summary>
        /// Selecciono el precio de un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double SelectProductPrice(int id)
        {
            command.Parameters.Clear();
            if (id != 0)
            {
                command.Connection = conexion.AbrirConexion();

                command.CommandText = "SELECT PRECIO FROM PRODUCTOS WHERE IDPROD = @id";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);

                LeerFilas = command.ExecuteReader();

                LeerFilas.Read();

                double result = (double)LeerFilas["PRECIO"];

                conexion.CerrarConexion();

                return result;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
