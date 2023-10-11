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



    }
}
