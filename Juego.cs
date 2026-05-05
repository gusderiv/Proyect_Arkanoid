using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Arkanoid
{
    internal class Juego
    {
        Pelota pelota;
        Nave nave;

        List<Ladrillo> nivelActual = new List<Ladrillo>();

        public Juego()
        {
            this.pelota = new Pelota(40, 10, 23, 78);
            this.nave = new Nave(30, 20);
        }

        internal Pelota Pelota { get => pelota; set => pelota = value; }
        internal Nave Nave { get => nave; set => nave = value; }

        public void comprobarColisiones()
        {
            if (pelota.Y == nave.Y - 1  && pelota.X >= nave.X && pelota.X <= nave.X + nave.Ancho)
            {
                pelota.DirY = pelota.DirY * -1;
            }
        }

        public void generarNivel()
        {
            for(int i = 4; i < Console.WindowWidth-8; i++)
            {
                for(int j = 2; j < 9; j++)
                {
                    Ladrillo ladrillo = new Ladrillo(i, j, 100);
                    nivelActual.Add(ladrillo);
                }
            }
        }

        public void dibujarNivel()
        {
            foreach(Ladrillo l in nivelActual)
            {
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write("## ");
            }
        }
    }
}
