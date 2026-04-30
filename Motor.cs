using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Motor
    {
        Juego juego = new Juego();

        public void ActualizarPosicion()
        {
            while (true)
            {

                juego.Pelota.ActualizarPosicion();

                if(Console.KeyAvailable)
                {
                    ConsoleKey tecla = Console.ReadKey(true).Key;
                    juego.Nave.Mover(tecla);
                }

                juego.comprobarColisiones();
            }
        }
        public void ConfigurarConsola()
        {
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;
            Console.Clear();
            DibujarMarcos();
        }

        public void DibujarMarcos()
        {
            int width = 78;
            int height = 23;

            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(width - 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, height - 1);
            Console.Write("└");
            Console.SetCursorPosition(width - 1, height - 1);
            Console.Write("┘");

            for (int x = 1; x < width - 1; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("─");
                Console.SetCursorPosition(x, height - 1);
                Console.Write("─");
            }

            for (int y = 1; y < height - 1; y++)
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

        public void CrearLadrillos(int nivel)
        {
           
        }
    }
}
