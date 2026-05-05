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

        public void RecibirGolpe()
        {
            resistencia--;
            if(resistencia <= 0)
            {
                destruido = true;
            }
        }
    }
}
