using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Motor
    {
        Juego juego = new Juego();
        bool seguirJugando = true;

        public void ActualizarPosicion()
        {
            while (seguirJugando)
            {
                switch (EstadoJuego.EstadoActual)
                {
                    case EstadoJuego.Estado.Menu:
                        juego.MostrarMenu();
                        break;

                    case EstadoJuego.Estado.Jugando:
                        Console.Clear();
                        ConfigurarConsola();
                        while (EstadoJuego.EstadoActual == EstadoJuego.Estado.Jugando)
                        {
                            Console.SetCursorPosition(0, 1);
                            Console.Write($"Vida: {juego.Vida} | Puntuacion: {juego.Puntuacion}");
                            juego.Pelota.ActualizarPosicion();

                            if (Console.KeyAvailable)
                            {
                                ConsoleKey tecla = Console.ReadKey(true).Key;
                                juego.Nave.Mover(tecla);
                            }

                            juego.comprobarColisiones();
                            juego.ComprobarColisionesLadrillos();
                            perderVida();
                        }
                        break;

                    case EstadoJuego.Estado.Pausa:
                        Console.Clear();
                        Console.WriteLine("Juego pausado");
                        break;
                    case EstadoJuego.Estado.GameOver:
                        Console.Clear();
                        Console.WriteLine("Juego terminado");
                        Console.WriteLine("Pulsa ENTER para seguir jugando...");

                        ConsoleKeyInfo teclaENTER = Console.ReadKey();

                        if (teclaENTER.Key == ConsoleKey.Enter)
                        {
                            EstadoJuego.EstadoActual = EstadoJuego.Estado.Jugando;
                        }
                        break;
                }
            }
        }


        public void ConfigurarConsola()
        {
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;
            Console.Clear();
            DibujarMarcos();
            juego.generarNivel();
            juego.dibujarNivel();
        }

        public void DibujarMarcos()
        {
            int width = 78;
            int height = 23;

            Console.SetCursorPosition(0, 2);
            Console.Write("┌");
            Console.SetCursorPosition(width - 1, 2);
            Console.Write("┐");
            Console.SetCursorPosition(0, height - 1);
            Console.Write("└");
            Console.SetCursorPosition(width - 1, height - 1);
            Console.Write("┘");

            for (int x = 1; x < width - 1; x++)
            {
                Console.SetCursorPosition(x, 2);
                Console.Write("─");
                Console.SetCursorPosition(x, height - 1);
                Console.Write("─");
            }

            for (int y = 3; y < height - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("│");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("│");
            }

            juego.Nave.Dibujar();                
            Console.SetCursorPosition(0, height);
        }

        public void BucleJuego()
        {
            while (true)
            {
                Thread.Sleep(50);
            }
        }

        public void perderVida()
        {
            if(juego.Pelota.Y == juego.Nave.Y + 2 && juego.Vida > 0)
            {
                juego.Vida -= 1;
            }
            else if(juego.Vida == 0)
            {
                EstadoJuego.EstadoActual = EstadoJuego.Estado.GameOver;
            }
        }
        public void cantidadLadrillos()
        {
            Console.WriteLine(juego.NivelActual);
        }
    }
}
