using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Pelota : Entidad
    {

        private int x;
        private int y;

        private int desplazamientoX = 1;
        private int desplazamientoY = -1;


        //Limites (entran como parametros)
        private int anchoMinimo = 1;
        private int altoMinimo = 1;

        //Limites (entran como parametros)
        private int anchoMaximo = 50;
        private int altoMaximo = 25;

        public Pelota(int x, int y, int velocidad) : base(x, velocidad)
        {
            this.x = x;
            this.y = y;
            this.velocidadX = velocidad;
        }

        public void DibujoRectangulo() ///mover a su zona GRAPS
        {

            for (int a = 1; a < anchoMaximo; a++)
            {

                Console.SetCursorPosition(a, 1);
                Console.Write("═");
            }


            for (int b = 1; b < altoMaximo; b++)
            {
                Console.SetCursorPosition(1, b);
                Console.Write("║");

            }

            for (int c = 1; c < altoMaximo; c++)
            {
                Console.SetCursorPosition(anchoMaximo, c);
                Console.Write("║");
            }


            for (int s = 1; s < anchoMaximo; s++)//Se eliminara cuando este implementado nave
            {

                Console.SetCursorPosition(s, altoMaximo);
                Console.Write(" ");
            }

        }

        public void IniciarMovimiento()
        {
            Console.CursorVisible = false;

            //Ladrillos(); Implementacion para la nueva clase.
            DibujoRectangulo();

            while (true)
            {
                Dibujar();
                Borrar();
                MoverP();
            }



        }

        public override void Dibujar()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("O");
            Thread.Sleep(velocidadX);
        }

        public override void Borrar()
        {
            Console.SetCursorPosition(this.x, this.y);

            if (this.y == altoMinimo)
            {
                Console.Write("═");
            }

            else if (this.x == anchoMinimo || this.x == anchoMaximo)
            {
                Console.Write("║");
            }

            else
            {
                Console.Write(" ");
            }

        }

        public void MoverP()
        {
            this.x += desplazamientoX;
            this.y += desplazamientoY;

            if (this.x <= anchoMinimo || this.x >= anchoMaximo)
            {

                desplazamientoX = desplazamientoX * -1;
            }

            // Rebote vertical
            if (this.y <= altoMinimo || this.y >= altoMaximo)
            {
                desplazamientoY = desplazamientoY * -1;
            }
        }
    }     
}
