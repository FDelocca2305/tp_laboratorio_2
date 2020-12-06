using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;
using BaseDeDatos;
using MetodosDeExtension;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Instancio clases de las entidades
            ProductosDAO productosDao = new ProductosDAO();
            VentasDAO ventasDao = new VentasDAO();

            //Testeo el funcionamiento del abm de Productos
            #region TestProductos
            Console.WriteLine("Test de funcionamiento de productos...");

            //Instancio un producto
            Producto producto = new Producto(999,1,1,"Producto de test",10.5);
            Console.WriteLine("Se instancio el producto");

            //Agrego producto a la base de datos
            try
            {
                productosDao.InsertarProductos(producto);
                Console.WriteLine("Se inserto el producto");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo insertar el producto");
                //throw new ErrorDataBaseException("No se pudo guardar el producto de test, puede que falte la base de datos");
            }

            //Actualizo un dato de ese producto
            producto.Descripcion = "Este es el producto cambiado";
            Console.WriteLine("Actualizando producto");

            //Actualizo el producto en la base de datos con el id 999
            try
            {
                productosDao.EditarProductos(productosDao.ListarUltimoProducto().IdProducto, producto);
                Console.WriteLine("Se editó el producto");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo editar el produto");
                //throw new ErrorDataBaseException("No se pudo actualizar el producto de test");
                //throw;
            }

            //Borro ese producto de la base de datos
            Console.WriteLine("Eliminando producto");
            try
            {
                productosDao.EliminarProducto(productosDao.ListarUltimoProducto().IdProducto);
                Console.WriteLine("Se elimino el producto");
            }
            catch (Exception)
            {

                Console.WriteLine("No se pudo eliminar el producto");
            }

            #endregion

            Console.WriteLine("-------------------------------------------------------------------------");

            //Testeo el funcionamiento del abm de Ventas
            #region TestVentas
            Console.WriteLine("Test de funcionamiento de ventas...");

            //Instancio un producto para testearlo con la venta
            Producto productoParaVenta = new Producto(10000, 1, 1, "Producto para venta", 10.5);
            Console.WriteLine("Se instancio un producto para la venta");

            try
            {
                productosDao.InsertarProductos(productoParaVenta);
                Console.WriteLine("Se inserto el producto para la venta");
            }
            catch (Exception)
            {

                Console.WriteLine("No se pudo insertar el producto para la venta");
            }

            //Creo una venta
            Venta venta = new Venta(999, productosDao.ListarUltimoProducto().IdProducto, 2);
            Console.WriteLine("Se creo una venta");

            //Inserto en la base de datos la venta
            try
            {
                ventasDao.InsertarVentas(venta);
                Console.WriteLine("Se inserto una venta");
            }
            catch (Exception)
            {

                Console.WriteLine("No se pudo guardar la venta");
            }

            //Modifico el objeto de venta
            venta.Cantidad = 3;

            //Guardo en la base de datos la modificacion
            Console.WriteLine("Actualizando venta");
            try
            {
                ventasDao.EditarVentas(ventasDao.ListarUltimaVenta().IdVenta, venta);
                Console.WriteLine("Se actualizo la venta en la base de datos");
            }
            catch (Exception)
            {

                Console.WriteLine("No se pudo modificar la venta en la base de datos");
            }

            //Borro esa venta de la base de datos
            Console.WriteLine("Eliminando venta");
            try
            {
                ventasDao.EliminarVenta(ventasDao.ListarUltimaVenta().IdVenta);
                productosDao.EliminarProducto(productosDao.ListarUltimoProducto().IdProducto);
                Console.WriteLine("Se elimino la venta");
            }
            catch (Exception)
            {

                Console.WriteLine("No se pudo eliminar la venta");
            }

            #endregion
            Console.WriteLine("------------------------------------------------------------");
            //Pruebo la funcionalidad de archivos con 
            #region Archivos

            Console.WriteLine("Probando archivo...");

            //Creo venta para guardarla en el archivo

            Venta ventaParaArchivos = new Venta(9999, "Nombre test",3,500);

            Xml<Venta> xml = new Xml<Venta>();

            //Seteo la ruta en el escritorio
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

            DateTime tiempo = new DateTime();

            //Pruebo el metodo de extension para conseguir el timestamp
            long timestamp = tiempo.GetTimeStamp();

            Console.WriteLine("Guardando archivo");

            //Guardo archivo
            if (xml.Guardar(ruta + "Venta" + timestamp + ".xml", venta))
            {
                Console.WriteLine("Se guardo la venta en el escritorio");
            }
            else
            {
                Console.WriteLine("No se pudo guardar el archivo correctamente");
            }
            #endregion

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Se termino el test");
            Console.ReadKey();
        }
    }
}
