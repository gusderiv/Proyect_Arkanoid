using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Nave
    {
        private string dibujoNave;
        private string borrarNave;

        public string DibujoNave { get => dibujoNave; set => dibujoNave = value; }
        public string BorrarNave1 { get => borrarNave; set => borrarNave = value; }

        public Nave()
        {
            this.dibujoNave = "[======]";
            this.borrarNave = "        ";
        }
        public bool MoverNave(ref int x)
        {
            bool action = false;
            if(Console.KeyAvailable)
            {
                if(Console.ReadKey(true).Key == ConsoleKey.LeftArrow && x > 1)
                {
                    x--;
                    action = true;
                }
                else if(Console.ReadKey(true).Key == ConsoleKey.RightArrow && x < Console.WindowWidth-11)
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
            Console.Write(this.dibujoNave);
        }
        
        public void BorrarNave(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(this.borrarNave);
        }
    }
}
