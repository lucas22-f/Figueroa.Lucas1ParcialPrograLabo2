using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Tienda.Empleado;

namespace Sistema_Tienda
{
    public class Pedido
    {
        //Clase pedido que contiene la informacion de 1 pedido 
        private int idPedido;
        private List<Producto> productos;
        private Empleado_Ventas vendedor;
        private bool ventaFinalizada;
        protected Cliente c;

        public Pedido()
        {
            this.productos = new List<Producto>();
            this.vendedor = new Empleado_Ventas();
            this.c = new Cliente();
            this.ventaFinalizada = false;
        }
        public Pedido(Empleado_Ventas vendedor,Cliente c , List<Producto> productos):this()
        {
            this.vendedor = vendedor;
            this.c = c;
            this.productos = productos;
          
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"id Pedido : {this.idPedido}");
            foreach(Producto producto in this.productos)
            {
                sb.AppendLine( producto.ToString() );
            }

            sb.AppendLine($"Datos vendedor : {this.vendedor.ToString()}");


            sb.AppendLine($"Datos Cliente Comprador:  {this.c.ToString()}");


            return sb.ToString();   
        }



    }
}
