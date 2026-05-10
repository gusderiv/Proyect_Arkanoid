 namespace Proyect_Arkanoid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Juego ARKANOID!, Punto de prueba");
            Motor motor = new Motor();

            motor.ConfigurarConsola();
            motor.ActualizarPosicion();


            int alturaMaxima = Console.WindowHeight;
            int anchuraMaxima = Console.WindowWidth;


        }
    }
}
