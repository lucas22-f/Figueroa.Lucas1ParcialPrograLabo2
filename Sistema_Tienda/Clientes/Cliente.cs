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


        private int IdCliente
        {
            get { return idCliente; }
        }
        
        
        
        
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

        public static bool operator == (Cliente c1, Cliente c2)
        {

            return c1.dni == c2.dni || c1.IdCliente == c2.IdCliente;
        }

        public static bool operator != (Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is  Cliente) {

                retorno =  this == (Cliente)obj;
            
            }

            return retorno;
        }

        public override string ToString()
        {
            return $"{this.nombre}  -   {this.dni} --  id:{Cliente.idCliente}";
        }
    }
}
