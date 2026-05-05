using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Ladrillo:ObjetoJuego
    {
        private int x;
        private int y;
        bool destruido;
        int resistencia;
        Random rd = new Random();

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Ladrillo() : base(0, 0)
        {

        }

        public void DibujoLadrillo()
        {
            //Sin implementar. int ladrilloX = rd.Next(x, y);
            Console.SetCursorPosition(23, 4); 
            Console.Write($"[###]");
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
