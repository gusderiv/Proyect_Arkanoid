namespace Proyect_Arkanoid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Juego ARKANOID!, Punto de prueba");
                  
            Pelota p = new Pelota(10, 25, 30);
            p.IniciarMovimiento();
        }
    }
}
