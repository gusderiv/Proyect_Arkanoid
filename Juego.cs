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
        int puntuacion;
        int vida;

        List<Ladrillo> nivelActual = new List<Ladrillo>();
        private int cantida;
        public Juego()
        {
            this.pelota = new Pelota(40, 10, 43, 78);
            this.nave = new Nave(30, 25);
            this.puntuacion = 0;
            this.vida = 3;
        }

        internal Pelota Pelota { get => pelota; set => pelota = value; }
        internal Nave Nave { get => nave; set => nave = value; }
        public int Puntuacion { get => puntuacion; set => puntuacion = value; }
        public int Vida { get => vida; set => vida = value; }
        internal List<Ladrillo> NivelActual { get => nivelActual; set => nivelActual = value; }

        public void ComprobarColisionesLadrillos()
        {
            Ladrillo ladrilloGolpeado = null;

            Console.SetCursorPosition(1, 27);

            Console.Write($"Cantidad ladrillos sin destruir: {contenidolistaLadrillo(),-5}");

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
                            puntuacion += 10;
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
            nivelActual.Clear();
            for (int i = 6; i < Console.WindowWidth-8; i+= 2)
            {
                for(int j = 4; j < 9; j+= 2)
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

        public void MostrarMenu()
        {
            EstadoJuego.EstadoActual = EstadoJuego.Estado.Menu;
            Console.WriteLine("Pulsa la tecla Enter");
            ConsoleKeyInfo tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Enter)
            {
                EstadoJuego.EstadoActual = EstadoJuego.Estado.Jugando;
                Console.Clear();
            }
        }

        public int contenidolistaLadrillo()
        {
            cantida = nivelActual.Count;
            return cantida;
        }

    }
}
