using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase Cliente la cual me da la info de 1 cliente
    public class Cliente
    {
        public string nombre { get; set; }
        public int dni {  get; set; }
        public string telefono { get; set; }


        

        public Cliente()
        {
            this.nombre = "";
            this.dni = 0;
            this.telefono = "";

        }

        public Cliente(string nombre, int dni ,string telefono):this()
        {
            this.nombre = nombre;
            this.dni = dni;
            this.telefono= telefono;
          

        }

        public static bool operator == (Cliente c1, Cliente c2)
        {

            return c1.dni == c2.dni || c1.telefono == c2.telefono;
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
            return $"Nombre:  {this.nombre}   - - - - - - - - - - - - - - - - - - - - - -  DNI :   {this.dni}   - - - - - - - - - - - - - - - - - - - - - -   Telefono   :{this.telefono}  ";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
