using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal abstract class ObjetoJuego
    {
        protected int x;
        protected int y;
        private int dirX;
        private int dirY;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        protected int DirX { get => dirX; set => dirX = value; }
        protected int DirY { get => dirY; set => dirY = value; }

        public ObjetoJuego(int x, int y)
        {

        }

        public abstract void Dibujar();

        public abstract void Borrar();
    }
}
