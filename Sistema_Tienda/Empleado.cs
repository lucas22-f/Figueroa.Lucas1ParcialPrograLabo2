using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public abstract class Empleado
    {
        protected List<Empleado_Envios> empleados_envios;
        protected List<Empleado_Ventas> empleados_ventas;
        protected string Nombre { get; set; }
        protected double Sueldo { get; set; }
        protected int Dni { get; set; }


        public Empleado(string nombre, double sueldo, int dni)
        {
            this.Nombre = nombre;
            this.Sueldo = sueldo;
            this.Dni = dni;
        }

        



    }
}
