﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase de producto que posee la info de 1 producto.
    public class Producto
    {
        private static int idProducto;
        private string nombreProducto;
        private int cantidad;
        private string descripcion;

        static Producto()
        {
            Producto.idProducto = 0;
        }

        public Producto(string nombreProducto, int cantidad, string descripcion)
        {
            
            this.nombreProducto = nombreProducto;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            Producto.idProducto += 1;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(nombreProducto);
            sb.Append(", ");
            sb.Append('[');
            sb.Append(cantidad);
            sb.Append(", ");
            sb.Append(descripcion);
            sb.Append("]");
            

            return sb.ToString();
        }
    }
}
