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
        public string nombre { get; set; }
        public int dni {  get; set; }
        private static int contadorClientes = 0;

        public int IdCliente { get; private set; }


        

        public Cliente()
        {
            this.nombre = "";
            this.dni = 0;
            this.IdCliente = ++contadorClientes;

        }

        public Cliente(string nombre, int dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.IdCliente = ++contadorClientes;

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
            return $"  {this.nombre}   ---------------------------------------------------   {this.dni}   ---------------------------------------------------   id:{this.IdCliente}  ";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
