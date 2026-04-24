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
            for (int a = 1; a < Console.WindowWidth; a++)
            {

                Console.SetCursorPosition(a, 1);
                Console.Write("-");
            }


            for (int b = 1; b < Console.WindowHeight; b++)
            {
                Console.SetCursorPosition(1, b);
                Console.Write("|");

            }

            for (int c = 1; c < Console.WindowHeight; c++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 1, c);
                Console.Write("|");
            }

            for (int d = 70; d<Console.WindowWidth; d++)
            {
                Console.SetCursorPosition(d, 1);
                Console.Write("-");
            }
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
