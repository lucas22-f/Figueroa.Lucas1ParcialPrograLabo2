using Sistema_Tienda.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Clientes
{
    internal class PedidoTerminado
    {
        private Cliente cliente;
        private Pedido pedido;
        private Transporte transporte;
        private int idPedido;

        
        public PedidoTerminado(Cliente c, Pedido p , Transporte t)
        {
            this.cliente = c;
            this.pedido = p;
            this.transporte = t;
        }
        public PedidoTerminado(Cliente c , Pedido p, Transporte t,int idPedido):this(c,p,t) { 
            
            
            this.idPedido = idPedido;
        
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.cliente.ToString());
            sb.Append(this.pedido.ToString());
            sb.Append(',');
            sb.Append(this.idPedido);
            sb.Append(",");
            sb.Append(this.transporte.ToString());

            return sb.ToString(); 
        }

        
    }
}
