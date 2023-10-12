using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Transportes
{
    internal class Andreani : Transporte
    {
        private DestinoDescuento des;
        private static double costeServicio = 0.31;


        public Andreani(string nombre, Pedido p, DestinoDescuento des) : base(nombre, p)
        {
            this.des = des;

        }


        public override double aplicarCosteServicio()
        {
            return (base.totalFacturado * Andreani.costeServicio) + base.totalFacturado;
        }


        public override string ToString()
        {
            return base.ToString();
        }


    }
}
