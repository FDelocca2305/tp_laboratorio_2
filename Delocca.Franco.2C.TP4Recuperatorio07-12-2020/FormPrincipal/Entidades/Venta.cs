using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public class Venta
    {

        private int idProducto;
        private int cantidad;
        private double subtotal;
        private string descripcionProd;
        private int idVenta;
       
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public string DescripcionProd { get => descripcionProd; set => descripcionProd = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }

        public Venta(int idProducto, int cantidad)
        {
            this.idProducto = idProducto;
            this.cantidad = cantidad;
        }

        public Venta (int id)
        {
            this.idVenta = id;
        }

        public Venta(int id, string descripcionProd, int cantidad, double subtotal)
        {
            this.idVenta = id;
            this.descripcionProd = descripcionProd;
            this.cantidad = cantidad;
            this.subtotal = subtotal;

        }

        public Venta(int idProducto, int cantidad, double subtotal): this(idProducto, cantidad)
        {
            this.subtotal = subtotal;
        }

        public Venta(int idVenta, int idProducto, int cantidad)
            :this(idProducto, cantidad)
        {
            this.idVenta = idVenta;
        }

        public Venta()
        {

        }

    }
}
