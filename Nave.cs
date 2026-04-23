using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Nave
    {
        public void MoverNave(ref int x)
        {
            if(Console.KeyAvailable)
            {
                if(Console.ReadKey().Key == ConsoleKey.LeftArrow && x > 2)
                {
                    x--;
                }
                else if(Console.ReadKey().Key == ConsoleKey.RightArrow && x < Console.WindowWidth-10)
                {
                    x++;
                }
            }
        }

        public void DibujarNave(int x, int y)
        {
            Console.SetCursorPosition(x, y);

            Console.Write("[======]");
        }

        public void BorrarNave(int x, int y)
        {
            Console.SetCursorPosition(x, y);

            Console.Write("        ");
        }
    }
}
