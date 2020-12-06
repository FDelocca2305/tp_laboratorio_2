using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Producto
    {
        
        private int idMarca;
        private int idCategoria;
        private string descripcion;
        private double precio;
        private int idProducto;

        public Producto(int idMarca, int idCategoria, string descripcion, double precio)
        {
            this.idMarca = idMarca;
            this.idCategoria = idCategoria;
            this.descripcion = descripcion;
            this.precio = precio;

        }

        public Producto(int id)
        {
            this.idProducto = id;
        }

        public Producto(int idProducto, int idMarca, int idCategoria, string descripcion, double precio)
            :this(idMarca, idCategoria, descripcion, precio)
        {
            this.idProducto = idProducto;
        }

        public Producto() { }

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int IdProducto { get => idProducto; }
    }
}
