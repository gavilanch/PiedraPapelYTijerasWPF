using PiedraPapelTijeras.Core;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using PiedraPapelTijeras.WPF.Servicios;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PiedraPapelTijeras.WPF
{
    public partial class MainWindow : Window
    {
        private List<Marcador> _marcador;
        private int _numeroDeJugadores = 2;
        private ServicioJugadas _servicioJugadas;
        private ServicioPuntaje _servicioPuntaje;
        private ServicioImagenes _servicioImagenes;

        public MainWindow()
        {
            InitializeComponent();

            _servicioJugadas = new ServicioJugadas();
            _servicioPuntaje = new ServicioPuntaje();
            _servicioImagenes = new ServicioImagenes();
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
            ActualizarImagenesOponentes(jugadas);
            var decideGanador = DecideGanador.Decidir(jugadas);
            ActualizarPuntaje(decideGanador);
        }

        private void ActualizarImagenesOponentes(List<Jugada> jugadas)
        {
            string rutaImagen = _servicioImagenes.ObtenerImagen(jugadas[1]);
            imgJugador2.Source = new BitmapImage(new Uri(rutaImagen, UriKind.Relative));
        }

        private void ActualizarPuntaje(ResultadoJugada decideGanador)
        {
            _servicioPuntaje.ActualizarPuntaje(_marcador, decideGanador);
            gridMarcador.ItemsSource = null;
            gridMarcador.ItemsSource = _marcador;
        }
    }
}
