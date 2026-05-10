using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        private int cantida;

        public Juego()
        {
            this.pelota = new Pelota(40, 10, 23, 78);
            this.nave = new Nave(30, 20);
        }

        internal Pelota Pelota { get => pelota; set => pelota = value; }
        internal Nave Nave { get => nave; set => nave = value; }

        public void ComprobarColisionesLadrillos()
        {
            Ladrillo ladrilloGolpeado = null;

            Console.SetCursorPosition(1,23);
            Console.Write($"contenido lista: {contenidolistaLadrillo(),-5}");//solo para verificar que la lista se esta vaciando, eliminar despues.
            foreach (Ladrillo ladrillo in nivelActual)
            {

                if(!ladrillo.Destruido)
                {
                    if (pelota.Y == ladrillo.Y && pelota.X >= ladrillo.X && pelota.X <= ladrillo.X)
                    {
                        pelota.DirY = pelota.DirY * -1;
                        ladrillo.Resistencia--;

                        if(ladrillo.Resistencia == 0)
                        {
                            ladrillo.Destruido = true;
                            ladrilloGolpeado = ladrillo;
                        }
                    }
                }  
            }

            if (ladrilloGolpeado != null)
            {
                nivelActual.Remove(ladrilloGolpeado);
            }
        }

        public void comprobarColisiones()
        {
            if (pelota.Y == nave.Y - 1  && pelota.X >= nave.X && pelota.X <= nave.X + nave.Ancho)
            {
                pelota.DirY = pelota.DirY * -1;
            }
        }

        public void generarNivel()
        {
            for(int i = 4; i < Console.WindowWidth-8; i+= 2)
            {
                for(int j = 2; j < 9; j+= 2)
                {
                    Ladrillo ladrillo = new Ladrillo(i, j, 1);
                    nivelActual.Add(ladrillo);
                }
            }
          
        }

        public void dibujarNivel()
        {
            foreach(Ladrillo l in nivelActual)
            {
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write("#");
            }
        }


        public int contenidolistaLadrillo()
        {
            cantida = nivelActual.Count;
            return cantida;
        }
    }
}
