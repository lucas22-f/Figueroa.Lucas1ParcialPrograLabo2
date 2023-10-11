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
        private static int idCliente;
        
        
        static Cliente()
        {
            Cliente.idCliente = 0;
        }

        public Cliente()
        {
            this.nombre = "";
            this.dni = 0;
            
        }

        public Cliente(string nombre, int dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            Cliente.idCliente += 1;
            
        }

        public override string ToString()
        {
            return $"{this.nombre}  -   {this.dni} --  id:{Cliente.idCliente}";
        }
    }
}
