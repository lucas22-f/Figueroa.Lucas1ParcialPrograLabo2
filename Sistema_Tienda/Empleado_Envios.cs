﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    public class Empleado_Envios : Empleado
    {

        //Clase derivada de Empleado que posee las funciones de Empleado de Envios.
        private Pedido p;
        


        public Empleado_Envios(string nombre, double sueldo, int dni , Pedido p) : base(nombre, sueldo, dni) 
        {
            this.p = p;
          
        }

       



    }
}
