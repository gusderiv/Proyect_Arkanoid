using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Ladrillo
    {
        private int x;
        private int y;
        Random rd = new Random();


        public Ladrillo()
        {
            
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }


        public void DibujoLadrillo()
        {
            //Sin implementar. int ladrilloX = rd.Next(x, y);
            Console.SetCursorPosition(23, 4); 
            Console.Write($"[###]");
        }


    }
}
