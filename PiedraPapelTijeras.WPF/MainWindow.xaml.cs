using PiedraPapelTijeras.Core;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using PiedraPapelTijeras.WPF.Servicios;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PiedraPapelTijeras.WPF
{
    public partial class MainWindow : Window
    {
        private List<Marcador> _marcador;
        private int _numeroDeJugadores = 2;
        private ServicioJugadas _servicioJugadas;
        private ServicioPuntaje _servicioPuntaje;

        public MainWindow()
        {
            InitializeComponent();
            _servicioJugadas = new ServicioJugadas();
            _servicioPuntaje = new ServicioPuntaje();
            _marcador = Marcador.ObtenerMarcador(_numeroDeJugadores);
            gridMarcador.ItemsSource = _marcador;
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
            List<Jugada> jugadas = _servicioJugadas.
                ObtenerJugadas(eleccionDelJugador1, _numeroDeJugadores);
            var decideGanador = DecideGanador.Decidir(jugadas);
            ActualizarPuntaje(decideGanador);
        }

        private void ActualizarPuntaje(ResultadoJugada decideGanador)
        {
            _servicioPuntaje.ActualizarPuntaje(_marcador, decideGanador);
            gridMarcador.ItemsSource = null;
            gridMarcador.ItemsSource = _marcador;
        }
    }
}
