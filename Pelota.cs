using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Pelota : ObjetoJuego
    {
        private int alturaMaxima;
        private int anchuraMaxima;
        private int alturaMinima;
        private int anchuraMinima;

        public Pelota(int x, int y, int alturaMaxima, int anchuraMaxima) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.AlturaMaxima = alturaMaxima;
            this.AnchuraMaxima = anchuraMaxima;
            this.AlturaMinima = 0;
            this.AnchuraMinima = 0;
            this.DirX = 1;
            this.DirY = -1;
        }

        public int AlturaMaxima { get => alturaMaxima; set => alturaMaxima = value; }
        public int AnchuraMaxima { get => anchuraMaxima; set => anchuraMaxima = value; }
        public int AlturaMinima { get => alturaMinima; set => alturaMinima = value; }
        public int AnchuraMinima { get => anchuraMinima; set => anchuraMinima = value; }

        public override void Dibujar()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("O");
            Thread.Sleep(20);
        }

        public override void Borrar()
        {
            Console.SetCursorPosition(this.X, this.y);

            if (this.Y == AlturaMinima || this.Y == 22)
            {
                Console.Write("─");
            }
            else if (this.X == AnchuraMinima || this.X == 77)
            {
                Console.Write("│");
            }
            else
            {
                Console.Write(" ");
            }
        }

        public void MoverP()
        {
            this.X += DirX;
            this.y += DirY;

            if (this.X == AnchuraMinima + 1 || this.X == 77)
            {
                this.DirX = this.DirX * -1;
            }

            if (this.Y == AlturaMinima + 1  || this.Y == 22)
            {
                this.DirY = this.DirY * -1;
            }
        }

        public void ActualizarPosicion()
        {
            Borrar();
            MoverP();
            Dibujar();
        }
    }     
}
