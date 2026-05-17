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
        private int nivelJuego;

        List<Ladrillo> nivelActual = new List<Ladrillo>();
        private int cantida;
        private int resistencia;
        private int valorInicialFor;
        public Juego()
        {
            this.pelota = new Pelota(40, 10, 43, 78);
            this.nave = new Nave(30, 25);
            this.puntuacion = 0;
            this.vida = 3333;
            this.nivelJuego = 1;
            this.valorInicialFor = 4;
        }

        internal Pelota Pelota { get => pelota; set => pelota = value; }
        internal Nave Nave { get => nave; set => nave = value; }
        public int Puntuacion { get => puntuacion; set => puntuacion = value; }
        public int Vida { get => vida; set => vida = value; }
        internal List<Ladrillo> NivelActual { get => nivelActual; set => nivelActual = value; }

        public int NivelJuego { get => nivelJuego; set => nivelJuego = value; }
        public void ComprobarColisionesLadrillos()
        {
            Ladrillo ladrilloGolpeado = null;

            Console.SetCursorPosition(0, 27);

            Console.Write($"Cantidad ladrillos sin destruir: {contenidolistaLadrillo(),-5}");

            foreach (Ladrillo ladrillo in nivelActual)
            {
                if(!ladrillo.Destruido)
                {
                    if (pelota.Y == ladrillo.Y &&
                       Math.Abs(pelota.X - ladrillo.X) <= 1)
                    {
                        pelota.DirY = pelota.DirY * -1;
                        ladrillo.Resistencia--;

                        if(ladrillo.Resistencia < 0)
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
                VerificarListaVacia();
            }

            else
            {
                dibujarNivel();
            }
        }

        public void comprobarColisiones()
        {
            if (pelota.Y == nave.Y - 1  && pelota.X >= nave.X && pelota.X <= nave.X + nave.Ancho)
            {
                pelota.DirY = pelota.DirY * -1;
            }
        }
        public void VerificarListaVacia()
        {

            if (nivelActual.Count == 0)
            {
                CargarSiguienteNivel();
            }

        }

        public void generarNivel()
        {
            nivelActual.Clear();
            int inicial = valorInicialFor;
           
            Console.SetCursorPosition(0,29);
            Console.Write("valor de Inicial: " + inicial+" ");

            Console.SetCursorPosition(0, 31);
            Console.Write("resistencia Ladrillo " + resistencia+" ");
            


            for (int i = 6; i < Console.WindowWidth - 8; i += 2)
            {     
                for (int j = 4; j <= inicial; j += 2)
                {
                    Ladrillo ladrillo = new Ladrillo(i, j, resistencia);//1 es resistencia
                    nivelActual.Add(ladrillo);
                }
            }
            valorInicialFor += 2;
        }

        public void dibujarNivel()
        {
            foreach(Ladrillo l in nivelActual)
            {
                Console.SetCursorPosition(l.X, l.Y);
                // Console.Write("█");
                Console.Write(l.Resistencia);
            }
        }

        public void MostrarMenu()
        {
            EstadoJuego.EstadoActual = EstadoJuego.Estado.Menu;
            Console.WriteLine(@"
 █████╗ ██████╗ ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ██╗██████╗ 
██╔══██╗██╔══██╗██║ ██╔╝██╔══██╗████╗  ██║██╔═══██╗██║██╔══██╗
███████║██████╔╝█████╔╝ ███████║██╔██╗ ██║██║   ██║██║██║  ██║
██╔══██║██╔══██╗██╔═██╗ ██╔══██║██║╚██╗██║██║   ██║██║██║  ██║
██║  ██║██║  ██║██║  ██╗██║  ██║██║ ╚████║╚██████╔╝██║██████╔╝
╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝╚═════╝ 
");
            Console.WriteLine("Pulsa la tecla Enter para empezar a jugar");
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

        private void CargarSiguienteNivel()
        {
            int velocidadBase = pelota.Velocidad;
            pelota.Velocidad = velocidadBase - (NivelJuego - 1) * 5;
            resistencia ++;
            generarNivel();
            dibujarNivel();
        }

    }
}
