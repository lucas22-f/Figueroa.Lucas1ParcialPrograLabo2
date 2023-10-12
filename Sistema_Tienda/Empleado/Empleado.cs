using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public abstract class Empleado
    {

        //Clase Abstracta Empleado la cual me proporciona la base para los tipos de empleados.


        protected string nombre;
        protected double sueldo;
        protected int dni;
        protected Experiencia exp;


        public string Nombre { get; set; }
        public double Sueldo { get; set; }
        public int Dni { get; set; }

        public Empleado()
        {
            nombre = "";
            Nombre = "";

        }
        public Empleado(string nombre, double sueldo, int dni):this() {
            this.exp = Experiencia.Principiante;
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.dni = dni;
        }

        public Empleado(string nombre, double sueldo, int dni, Experiencia exp) : this(nombre,sueldo,dni)
        {
            
            this.exp = exp;
        }


        public virtual void RealizarTarea()
        {
            Console.WriteLine($"tarea realizada por : {nombre}");
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( nombre );
            sb.Append(' ');
            sb.Append((int)sueldo);
            sb.Append(' ');
            sb.Append(((int)dni).ToString());
            sb.Append(' ');
            sb.Append($"{this.exp}");
            
            return sb.ToString();
        }

        public static bool operator == (Empleado e1, Empleado e2)
        {

            return e1.dni == e2.dni;
        }

        public static bool operator !=(Empleado e1, Empleado e2)
        {
            return !(e1 == e2);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado)
            {

                retorno = this == (Empleado)obj;

            }

            return retorno;
        }

        
    }
}
