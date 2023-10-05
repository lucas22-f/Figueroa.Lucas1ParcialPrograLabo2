using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public class Empleado_Envios : Empleado
    {
        protected List<Pedido> pedidos;




        public Empleado_Envios(string nombre, double sueldo, int dni) : base(nombre, sueldo, dni)
        {
            base.empleados_envios = new List<Empleado_Envios>();
            this.pedidos = new List<Pedido>();
        }



    }
}
