using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public abstract class Empleado
    {

        //Clase Abstracta Empleado la cual me proporciona la base para los tipos de empleados.

        protected List<Empleado_Envios> empleados_envios;
        protected List<Empleado_Ventas> empleados_ventas;
        protected string nombre;
        protected double sueldo;
        protected int dni;


        public string Nombre { get; set; }
        public double Sueldo { get; set; }
        public int Dni { get; set; }

        public Empleado()
        {
            this.nombre = "";
            this.Nombre = "";
            this.empleados_envios = new List<Empleado_Envios>();
            this.empleados_ventas = new List<Empleado_Ventas>();
        }


        public Empleado(string nombre, double sueldo, int dni):this()
        {
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.dni = dni;
        }

        



    }
}
