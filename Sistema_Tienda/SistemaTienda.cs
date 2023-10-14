namespace Sistema_Tienda.Empleado
{
    public class SistemaTienda// sistema que hace el manejo de todas mis clases.
    {

        private List<Cliente> clientes;

        // esta es mi lista de clases abstractas -> dentro tengo Empleados_Envios y Empleados_Ventas
        private List<Empleado> empleados; 
        
       
        private List<Producto> productos;

        public List<Empleado> ListaEmpleados
        {
             get { return empleados; }
        }

        public SistemaTienda()
        {
            this.clientes = new List<Cliente>();
            this.empleados = new List<Empleado>();
            this.productos = new List<Producto>();


        }

    }
}