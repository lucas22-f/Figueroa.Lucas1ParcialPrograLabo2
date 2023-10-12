using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Transportes
{
    public abstract class Transporte
    {
        protected string nombre;
        protected static int conteoEnvio;
        protected int totalFacturado;
        protected Pedido p;

        static Transporte()
        {
            Transporte.conteoEnvio = 0;
            
        }

        public Transporte(string nombre, Pedido p)
        {
            this.nombre = nombre;
            this.p = p;
        }


        public virtual double aplicarCosteServicio()
        {
            return this.totalFacturado;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(nombre);
            sb.Append('(');
            sb.Append(p.ToString());
            sb.Append(")");
            sb.Append($"Total facturado :  {this.totalFacturado}");
            sb.Append(')');

            return sb.ToString();   


            
        }


        public static bool operator ==(Transporte a, Transporte b)
        {

            return a.nombre == b.nombre;
        }

        public static bool operator !=(Transporte a, Transporte b)
        {
            return !(a == b);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Transporte)
            {

                retorno = this == (Transporte)obj;

            }

            return retorno;
        }



    }
}
