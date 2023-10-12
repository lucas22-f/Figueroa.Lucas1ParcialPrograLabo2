using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Ventas : Empleado
    {
        //clase derivada de Empleado que posee las funciones del empleado de ventas.       

        // 1 empleado ventas realiza 1 pedido -> donde tiene los productos y la info del cliente. 
        protected Cliente clienteAtendido;
        private static int ventasRealizadas;
        private List<Producto> productos;

        public static int VentasRealizadas { get; private set; }
        static Empleado_Ventas()
        {
            Empleado_Ventas.ventasRealizadas = 0;
        }
        public Empleado_Ventas()
        {
            this.clienteAtendido = new Cliente();
           this.productos = new List<Producto>();
        }
        public Empleado_Ventas(Cliente c , string n , double s, int dni,List<Producto> p) : base(n, s ,dni)
        {
            VentasRealizadas++;
            this.clienteAtendido = c;
            this.productos = p;
        }
        public Empleado_Ventas(Cliente cliente, string nombre, double sueldo, int dni , List<Producto> productos,Experiencia exp) : base(nombre, sueldo, dni ,exp)
        {
            VentasRealizadas++;
            this.clienteAtendido = cliente;
            this.productos = productos;
            
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado_Ventas)
            {

                retorno = this == (Empleado_Ventas)obj;

            }

            return retorno;
        }





        public override void RealizarTarea()
        {
            base.RealizarTarea();
            Console.WriteLine(this.AgregarProductoACliente());
        }

        private string AgregarProductoACliente()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cliente:  " + clienteAtendido.ToString());
            sb.AppendLine("\nproductos: \n");
            foreach(Producto producto in this.productos)
            {
                sb.AppendLine(producto.ToString());
            }

            return sb.ToString();
            
        }

        public Pedido ConcretarPedido(Cliente c)
        {
            Pedido pedidoConcretado = new Pedido(this, this.clienteAtendido,this.productos);

            return pedidoConcretado;
        }

        public override string ToString()
        {
            return base.ToString();
        }




    }

    
 
}
