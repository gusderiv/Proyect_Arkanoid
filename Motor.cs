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
                        ConfigurarConsola();
                        break;

                    case EstadoJuego.Estado.Jugando:
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true).Key;
                            if (key == ConsoleKey.P)
                            {
                                EstadoJuego.EstadoActual = EstadoJuego.Estado.Pausa;
                                break;
                            }
                            juego.Nave.Mover(key);
                        }

                        Console.SetCursorPosition(0, 1);
                        Console.Write($"Vida: {juego.Vida} | Puntuacion: {juego.Puntuacion}");

                        juego.Pelota.ActualizarPosicion();
                        juego.comprobarColisiones();
                        juego.ComprobarColisionesLadrillos();
                        perderVida();
                        Thread.Sleep(25);
                        break;

                    case EstadoJuego.Estado.Pausa:
                        Console.SetCursorPosition(1, 27);
                        Console.WriteLine("Juego pausado. Pulsa P para continuar");
                        var teclaPausa = Console.ReadKey(true).Key;
                        if (teclaPausa == ConsoleKey.P)
                        {
                            EstadoJuego.EstadoActual = EstadoJuego.Estado.Jugando;
                        }
                        break;
                    case EstadoJuego.Estado.GameOver:
                        Console.Clear();
                        Console.WriteLine("Juego terminado");

                        ConsoleKeyInfo teclaENTER = Console.ReadKey();

                        seguirJugando = false;
                        break;
                }
            }
        } 

        public void ConfigurarConsola()
        {
            Console.SetWindowSize(80, 45);
            Console.CursorVisible = false;
            Console.Clear();
            DibujarMarcos();
            juego.generarNivel();
            juego.dibujarNivel();
        }

        public void DibujarMarcos()
        {
            int width = 78;
            int height = 27;

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
            if(juego.Pelota.Y == juego.Nave.Y + 1 && juego.Vida > 0)
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
            int cantidadLadrillos = juego.contenidolistaLadrillo();

            if (cantidadLadrillos > 0) 
            {
              Console.SetCursorPosition(1, 24);
              Console.WriteLine($"Ladrillos restantes: {juego.contenidolistaLadrillo}");
            }

            else 
            {
              Console.WriteLine("Lista vacia");
            }
            

        }

    }
}
