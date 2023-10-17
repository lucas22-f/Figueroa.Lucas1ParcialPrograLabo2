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


        private int IdPedido
        {
            get { return this.idPedido;  }
        }
        public Pedido()
        {
            this.productos = new List<Producto>();
            //this.vendedor = new Empleado_Ventas();
            this.c = new Cliente();
            this.ventaFinalizada = false;
            this.idPedido += 1;
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
            sb.Append($"id Pedido : {this.idPedido}\n");
            foreach(Producto producto in this.productos)
            {
                sb.AppendLine( producto.ToString() );
            }

            sb.AppendLine($"Datos vendedor : {this.vendedor.ToString()}");


            sb.AppendLine($"Datos Cliente Comprador:  {this.c.ToString()}");


            return sb.ToString();   
        }

        public static bool operator == ( Pedido a , Pedido b)
        {
            return a.IdPedido == b.IdPedido;
        }
        public static bool operator !=(Pedido a, Pedido b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            bool res = false;
            if(obj is Pedido)
            {
                res = this == (Pedido)obj;
            }

            return res;
        }





    }
}
