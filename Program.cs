 namespace Proyect_Arkanoid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Juego ARKANOID!, Punto de prueba");

            Motor motor = new Motor();

            motor.ConfigurarConsola();
            //motor.DibujarMarcos();
            motor.ActualizarPosicion();

            int alturaMaxima = Console.WindowHeight;
            int anchuraMaxima = Console.WindowWidth;

            // Pelota pelota = new Pelota(40, 10, alturaMaxima, anchuraMaxima);
            //pelota.ActualizarPosicion();
        }
    }
}
