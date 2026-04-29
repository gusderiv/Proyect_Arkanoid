using System;
using System.Collections.Generic;
using System.Text;

namespace Proyect_Arkanoid
{
    internal class Nave:ObjetoJuego
    {
        int ancho;
        string dibujoNave = "[======]";

        public int Ancho { get => ancho; set => ancho = value; }

        public Nave(int x, int y) : base(x, y)
        {
            this.Ancho = dibujoNave.Length;
        }

        public override void Dibujar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(dibujoNave);
        }
        
        public override void Borrar()
        {
            Console.SetCursorPosition(X, Y);

            Console.Write("        ");
        }

        public void Mover(ConsoleKey tecla)
        {
            Borrar();

            if(tecla == ConsoleKey.LeftArrow && X > 2)
            {
                X--;
            }
            else if(tecla == ConsoleKey.RightArrow && X < Console.WindowWidth-12)
            {
                X++;
            }

            Dibujar();
        }

    }
}
