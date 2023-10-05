using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase de producto que posee la info de 1 producto.
    internal class Producto
    {
        private int idProducto;
        private string nombreProducto;
        private int cantidad;
        private string descripcion;


        public Producto(int idProducto, string nombreProducto, int cantidad, string descripcion)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
        }
    }
}
