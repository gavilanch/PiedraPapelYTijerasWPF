using PiedraPapelTijeras.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.WPF.Servicios
{
    public class ServicioJugadas
    {
        private Dictionary<int, Eleccion> _dictElecciones;
        private Random _rnd;

        public ServicioJugadas()
        {
            _rnd = new Random(Environment.TickCount);

            _dictElecciones = new Dictionary<int, Eleccion>()
            {
                {1, new Piedra()},
                {2, new Papel()},
                {3, new Tijera()}
            };
        }

        public List<Jugada> ObtenerJugadas(Eleccion eleccionDelJugador1, int numeroDeJugadores)
        {
            var jugadas = new List<Jugada>();
            var jugada1 = new Jugada() { Id = 1, Eleccion = eleccionDelJugador1 };
            jugadas.Add(jugada1);

            var eleccionDelJugador2 = EleccionAleatoria();
            var jugada2 = new Jugada() { Id = 2, Eleccion = eleccionDelJugador2 };
            jugadas.Add(jugada2);

            if (numeroDeJugadores == 3)
            {
                var eleccionDelJugador3 = EleccionAleatoria();
                var jugada3 = new Jugada() { Id = 3, Eleccion = eleccionDelJugador3 };
                jugadas.Add(jugada3);
            }

            return jugadas;
        }

        private Eleccion EleccionAleatoria()
        {
            int numeroAleatorio = _rnd.Next(1, 4);
            return _dictElecciones[numeroAleatorio];
        }
    }
}
