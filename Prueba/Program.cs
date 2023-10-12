using Sistema_Tienda;
using Sistema_Tienda.Empleado;

internal class Program
{
    private static void Main(string[] args)
    {

        


        List<Producto> productos = new()
        {
        new Producto("remera1", 20, "remera blanca de algodon"),
        new Producto("remera2", 26, "remera verde de algodon"),
        new Producto("remera3", 21, "remera roja de algodon"),
        new Producto("remera4", 30, "remera azul de algodon"),
        new Producto("remera5", 13, "remera negra de algodon"),
        };
        Cliente cliente = new Cliente("lucas", 402002);
        Empleado_Ventas vendedor = new Empleado_Ventas(cliente,"Vendedor de lucas",2000,32340,productos);
        Empleado_Ventas vendedor2 = new Empleado_Ventas(cliente,"Vendedor de lucas",2000,35240,productos,Experiencia.Experto);

        vendedor.RealizarTarea();
        vendedor2.RealizarTarea();

        Console.WriteLine(Empleado_Ventas.VentasRealizadas);
        
        Console.WriteLine("_____________________________________________________________________________");

        Console.WriteLine(vendedor.ToString());

        Pedido p = vendedor.ConcretarPedido(cliente);

        Console.WriteLine("_____________________________________________________________________________");
        Console.WriteLine(p.ToString());

        Console.WriteLine(vendedor == vendedor2);









    }
}