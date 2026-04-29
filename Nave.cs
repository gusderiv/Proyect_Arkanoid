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

        public override void Dibujar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("[======]");
        }
        
        public override void Borrar()
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
