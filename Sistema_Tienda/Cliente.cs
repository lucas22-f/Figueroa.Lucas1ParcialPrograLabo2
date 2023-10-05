using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase Cliente la cual me da la info de 1 cliente
    public class Cliente
    {
        private string nombre;
        private int dni;
        private int idCliente;
        private List<Pedido> pedidos;
      
        

        public Cliente()
        {

            this.nombre = "";
            this.dni = 0;
            this.idCliente = 0;
            this.pedidos = new List<Pedido>();
        
        }

       



    }
}
