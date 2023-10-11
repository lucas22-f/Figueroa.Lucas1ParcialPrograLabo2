namespace Sistema_Tienda.Empleado
{
    public class SistemaTienda// sistema que hace el manejo de todas mis clases.
    {

        private List<Cliente> clientes;

        // esta es mi lista de clases abstractas -> dentro tengo Empleados_Envios y Empleados_Ventas
        private List<Empleado_Ventas> empleadosVentas; 
        private List<Empleado_Envios> empleadosEnvios; 
       
        private List<Producto> productos;

        public SistemaTienda()
        {
            this.clientes = new List<Cliente>();
            this.empleadosVentas = new List<Empleado_Ventas>();
            this.empleadosEnvios = new List<Empleado_Envios>();
            this.productos = new List<Producto>();


        }

    }
}