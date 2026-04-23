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
            int alto = 25;
            int ancho = 80;

            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    if (i == 0 || i == alto - 1)
                    {
                        Console.Write("-");
                    }
                    else if (j == 0 || j == ancho - 1)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
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
