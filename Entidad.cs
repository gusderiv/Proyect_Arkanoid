using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal abstract class Entidad
    {
        protected int x;
        protected int velocidadX;



        public int X { get => x; set => x = value; }
        public int VelocidadX { get => velocidadX; set => velocidadX = value; }

        public Entidad(int x, int velocidad)
        {

        }

        public abstract void Dibujar();

        public abstract void Borrar();


    }
}
