
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
       
        private int idPedido;

        
        public PedidoTerminado(Cliente c, Pedido p)
        {
            this.cliente = c;
            this.pedido = p;
            
        }
        public PedidoTerminado(Cliente c , Pedido p,int idPedido):this(c,p) { 
            
            
            this.idPedido = idPedido;
        
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.cliente.ToString());
            sb.Append(this.pedido.ToString());
            sb.Append(',');
            sb.Append(this.idPedido);
            

            return sb.ToString(); 
        }

        
    }
}
