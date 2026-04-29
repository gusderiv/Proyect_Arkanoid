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
    }
}
