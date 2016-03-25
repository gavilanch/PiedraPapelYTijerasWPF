using PiedraPapelTijeras.Core;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiedraPapelTijeras.WPF
{
    public partial class MainWindow : Window
    {
        private List<Marcador> _marcador;
        private Random _rnd;
        public MainWindow()
        {
            InitializeComponent();
            _marcador = Marcador.ObtenerMarcador(2);
            gridMarcador.ItemsSource = _marcador;
            _rnd = new Random(Environment.TickCount);
        }

        private void imgPiedra_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Jugar(new Piedra());
        }

        private void imgPapel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Jugar(new Papel());
        }

        private void imgTijera_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Jugar(new Tijera());
        }

        private void Jugar(Eleccion eleccionDelJugador1)
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = eleccionDelJugador1 };

            var eleccionDelJugador2 = EleccionAleatoria();

            var jugada2 = new Jugada() { Id = 2, Eleccion = eleccionDelJugador2 };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            ActualizarPuntaje(decideGanador);
        }

        private Eleccion EleccionAleatoria()
        {
            var dictElecciones = new Dictionary<int, Eleccion>()
            {
                {1, new Piedra()},
                {2, new Papel()},
                {3, new Tijera()}
            };

            int numeroAleatorio = _rnd.Next(1, 4);

            return dictElecciones[numeroAleatorio];
        }

        private void ActualizarPuntaje(ResultadoJugada decideGanador)
        {
            if (decideGanador.Resultado == Resultado.Ganado)
            {
                _marcador[0].Puntuacion++;
            }
            else if (decideGanador.Resultado == Resultado.Perdido)
            {
                _marcador[1].Puntuacion++;
            }

            gridMarcador.ItemsSource = null;
            gridMarcador.ItemsSource = _marcador;
        }
    }
}
