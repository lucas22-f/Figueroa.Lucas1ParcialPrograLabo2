using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public class Empleado_Ventas : Empleado
    {
        
        protected List<Cliente> clientesEmpleado;



        public Empleado_Ventas(string nombre, double sueldo, int dni) : base(nombre, sueldo, dni)
        {
            base.empleados_ventas = new List<Empleado_Ventas>();
            this.clientesEmpleado = new List<Cliente>();
        }



    }
}
