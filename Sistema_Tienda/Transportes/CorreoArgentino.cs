using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Transportes
{
    internal class CorreoArgentino : Transporte
    {
        private DestinoDescuento des;
        private static double costeServicio = 0.21;
        
        
        public CorreoArgentino(string nombre , Pedido p, DestinoDescuento des) : base(nombre, p)
        {
            this.des = des;
           
        }


        public override double aplicarCosteServicio()
        {
            return (base.totalFacturado * CorreoArgentino.costeServicio) + base.totalFacturado;
        }


    }
}
