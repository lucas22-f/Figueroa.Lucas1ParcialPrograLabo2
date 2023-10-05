using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public class Pedido
    {
        //Clase pedido que contiene la informacion de 1 pedido 
        private int idPedido;
        private List<Producto> productos;
        private Empleado_Ventas vendedor;
        private bool ventaFinalizada;

        public Pedido()
        {
            this.productos = new List<Producto>();
            this.ventaFinalizada = false;
        }
        public Pedido(Empleado_Ventas vendedor):this()
        {
            this.vendedor = vendedor;
          
            
        }



    }
}
