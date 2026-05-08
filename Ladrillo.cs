using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Ladrillo:ObjetoJuego
    {
        bool destruido;
        int resistencia;
        Random rd = new Random();

        public Ladrillo(int x, int y, int resistencia) : base(x, y)
        {
            this.resistencia = resistencia;
            this.destruido = false;
        }

        public bool Destruido { get => destruido; set => destruido = value; }
        public int Resistencia { get => resistencia; set => resistencia = value; }

        public bool RecibirGolpe()
        {
            resistencia--;

            if(resistencia <= 0)
            {
                destruido = true;
            }

            return destruido;
        }
    }
}
