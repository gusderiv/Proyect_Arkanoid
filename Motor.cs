using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Motor//<---- CLASE JUEGO
    {
        Pelota pelota = new Pelota(40, 10, 23, 78);
        Nave nave = new Nave();

        private int posicionX = 30;
        private int posicionY = 18;

        public void ActualizarPosicion()
        {
            DibujarMarcos();


            while (true)
            {
                pelota.Dibujar();
                pelota.Borrar();
                pelota.MoverP();

                nave.DibujarNave(posicionX, posicionY);
                pelota.ComprobarColisionNave(posicionX, posicionY);

                if (nave.MoverNave(ref posicionX))
                {
                    nave.BorrarNave(posicionX, 18);
                }

            }
        }
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
