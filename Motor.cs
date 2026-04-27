using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Motor
    {
        public void ConfigurarConsola()
        {
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;
            Console.Clear();
        }

        public void DibujarMarcos()
        {
            int width = 78;
            int height = 23;

            for (int x = 1; x < width - 1; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("-");
                Console.SetCursorPosition(x, height - 1);
                Console.Write("-");
            }

            for (int y = 1; y < height - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("|");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("|");
            }

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
