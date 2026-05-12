using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Arkanoid
{
    internal class EstadoJuego
    {
        public enum Estado { Menu, Jugando, Pausa, GameOver }

        public static Estado EstadoActual = Estado.Menu;
    }
}
