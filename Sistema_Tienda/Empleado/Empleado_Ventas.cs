using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        
        public Cliente ClienteAtendido
        {
            get { return clienteAtendido; }
            set { clienteAtendido = value; }
        }
        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; } // Agregar un setter
        }

        public static int VentasRealizadas { get; private set; }

        public new string Nombre
        {
            get { return base.nombre; } set { base.nombre = value;}
        }

        public new double Sueldo
        {
            get { return base.sueldo; } set{base.sueldo = value;} 
        }
        public new int Dni
        {
            get { return base.dni; }
            set { base.dni = value; }
        }
        public Experiencia Exp
        {
            get { return base.exp; }
            set { base.exp = value; }
        }


        public Empleado_Ventas()
        {

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

        public string MostarInfoDetallada()
        {
            StringBuilder sb = new(base.ToString());
            sb.Append($"cliente:    \n    {this.clienteAtendido.ToString()}    ");
           
            return sb.ToString();
        }




    }

    
 
}
