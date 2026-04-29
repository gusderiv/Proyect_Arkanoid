using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Nave:ObjetoJuego
    {
        int ancho;

        public int Ancho { get => ancho; set => ancho = value; }

        public Nave(int x, int y, int ancho) : base(x, y)
        {
            this.Ancho = ancho;
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

            Console.Write("        ");
        }

        public void Mover(ConsoleKey tecla)
        {
            Borrar();

            if(tecla == ConsoleKey.LeftArrow && X > 2)
            {
                X--;
            }
            else if(tecla == ConsoleKey.RightArrow && X < Console.WindowWidth-10)
            {
                X++;
            }

            Dibujar();
        }

    }
}
