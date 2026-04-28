using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Nave
    {
        public bool MoverNave(ref int x)
        {
            bool action = false;
            if(Console.KeyAvailable)
            {
                if(Console.ReadKey().Key == ConsoleKey.LeftArrow && x > 2)
                {
                    x--;
                    action = true;
                }
                else if(Console.ReadKey().Key == ConsoleKey.RightArrow && x < Console.WindowWidth-10)
                {
                    x++;
                    action = true;
                }
            }
            return action;
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
