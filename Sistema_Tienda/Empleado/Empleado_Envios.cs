using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Envios : Empleado
    {

        //Clase derivada de Empleado que posee las funciones de Empleado de Envios.
        private Pedido p;
        


        public Empleado_Envios(string nombre, double sueldo, int dni , Pedido p,Experiencia exp) : base(nombre, sueldo, dni,exp) 
        {
            this.p = p;
          
        }

        public override void RealizarTarea()
        {
            base.RealizarTarea();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
