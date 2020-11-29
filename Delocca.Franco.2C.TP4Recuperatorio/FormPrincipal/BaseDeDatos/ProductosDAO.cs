using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class ProductosDAO
    {
        private DB conexion = new DB();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader LeerFilas;

        /// <summary>
        /// Listo categorias de la tabla y las paso como un DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ListarCategorias()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();

            command.CommandText = "select * from CATEGORIAS";
            command.CommandType = CommandType.Text;

            LeerFilas = command.ExecuteReader();

            tabla.Load(LeerFilas);

            conexion.CerrarConexion();

            return tabla;
        }

        /// <summary>
        /// Listo marcas de los productos de la marcas y las paso como un DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ListarMarcas()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();

            command.CommandText = "select * from MARCAS";
            command.CommandType = CommandType.Text;

            LeerFilas = command.ExecuteReader();

            tabla.Load(LeerFilas);

            conexion.CerrarConexion();

            return tabla;
        }

        /// <summary>
        /// Inserto productos en la tabla productos
        /// </summary>
        /// <param name="producto"></param>
        public void InsertarProductos(Producto producto)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "insert into PRODUCTOS (IDCATEGORIA, IDMARCA, DESCRIPCION, PRECIO) values (@idcategoria,@idmarca,@descrip,@prec)";

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@idcategoria", producto.IdCategoria);
            command.Parameters.AddWithValue("@idmarca", producto.IdMarca);
            command.Parameters.AddWithValue("@descrip", producto.Descripcion);
            command.Parameters.AddWithValue("@prec", producto.Precio);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        /// <summary>
        /// Listo productos de la tabla productos
        /// </summary>
        /// <returns></returns>
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();

            command.CommandText = "select IDPROD AS ID, CATEGORIAS.CATEGORIA,MARCAS.MARCA,DESCRIPCION,PRECIO from PRODUCTOS INNER JOIN CATEGORIAS ON PRODUCTOS.IDCATEGORIA = CATEGORIAS.IDCATEG INNER JOIN MARCAS ON PRODUCTOS.IDMARCA = MARCAS.IDMARCA";
            command.CommandType = CommandType.Text;

            LeerFilas = command.ExecuteReader();

            tabla.Load(LeerFilas);

            conexion.CerrarConexion();

            return tabla;
        }

        /// <summary>
        /// Edito un producto pasandole la id y  el objeto creado anteriormente con sus datos
        /// </summary>
        /// <param name="idProd"></param>
        /// <param name="producto"></param>
        public void EditarProductos(int idProd, Producto producto)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "UPDATE PRODUCTOS SET IDCATEGORIA = @idcategoria, IDMARCA = @idmarca, DESCRIPCION = @descrip, PRECIO = @prec WHERE IDPROD = @id ";

            command.CommandType = CommandType.Text;
            
            command.Parameters.AddWithValue("@id", idProd);

            command.Parameters.AddWithValue("@idcategoria", producto.IdCategoria);
            command.Parameters.AddWithValue("@idmarca", producto.IdMarca);
            command.Parameters.AddWithValue("@descrip", producto.Descripcion);
            command.Parameters.AddWithValue("@prec", producto.Precio);


            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();

        }

        /// <summary>
        /// Elimino un producto por id
        /// </summary>
        /// <param name="idProd"></param>
        public void EliminarProducto(int idProd)
        {
            command.Parameters.Clear();

            command.Connection = conexion.AbrirConexion();
            command.CommandText = "DELETE PRODUCTOS WHERE IDPROD = @id";
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@id", idProd);

            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }
    }
}
