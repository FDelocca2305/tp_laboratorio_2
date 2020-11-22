using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using BaseDeDatos;
using Excepciones;
using System.Data;
using System.Data.SqlClient;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test unitario que prueba que no se puedan insertar valores erroneos en la base de datos el id 99 de marca no existe
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AgregarALaBaseDeDatosUnProductoConDatosErroneos()
        {
            ProductosDAO dao = new ProductosDAO();

            Producto producto = new Producto(3, 99, "Producto de pruebaunitaria", 33.57);

            dao.InsertarProductos(producto);
        }
    }
}
