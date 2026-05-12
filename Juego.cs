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
        int puntuacion;
        int vida;

        List<Ladrillo> nivelActual = new List<Ladrillo>();

        public Juego()
        {
            this.pelota = new Pelota(40, 10, 23, 78);
            this.nave = new Nave(30, 20);
            this.puntuacion = 0;
            this.vida = 3;
        }

        internal Pelota Pelota { get => pelota; set => pelota = value; }
        internal Nave Nave { get => nave; set => nave = value; }
        public int Puntuacion { get => puntuacion; set => puntuacion = value; }
        public int Vida { get => vida; set => vida = value; }

        public void ComprobarColisionesLadrillos()
        {
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
                        }
                    }
                }
            }
            //nivelActual.RemoveAll(la=>la.RecibirGolpe()==true);//sin implementar el metodo eliminar los ladrillos destruidos de golpe.
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
            for(int i = 6; i < Console.WindowWidth-8; i+= 2)
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
    }
}
