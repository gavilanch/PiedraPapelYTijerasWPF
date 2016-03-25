using PiedraPapelTijeras.Core;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using PiedraPapelTijeras.WPF.Servicios;
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
        private int _numeroDeJugadores = 2;
        private ServicioJugadas _servicioJugadas;

        public MainWindow()
        {
            InitializeComponent();
            _servicioJugadas = new ServicioJugadas();
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
