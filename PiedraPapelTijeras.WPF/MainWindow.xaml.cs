using PiedraPapelTijeras.Core;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using PiedraPapelTijeras.WPF.Servicios;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            IniciarNuevoMarcador();
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
            imgJugador2.Source = ConvertirRutaAImagen(rutaImagen);

            if (_numeroDeJugadores == 3)
            {
                rutaImagen = _servicioImagenes.ObtenerImagen(jugadas[2]);
                imgJugador3.Source = ConvertirRutaAImagen(rutaImagen);
            }
        }

        private BitmapImage ConvertirRutaAImagen(string rutaImagen)
        {
            return new BitmapImage(new Uri(rutaImagen, UriKind.Relative));
        }

        private void ActualizarPuntaje(ResultadoJugada decideGanador)
        {
            _servicioPuntaje.ActualizarPuntaje(_marcador, decideGanador);
            gridMarcador.ItemsSource = null;
            gridMarcador.ItemsSource = _marcador;
        }

        private void itemMenuNuevo_Click(object sender, RoutedEventArgs e)
        {
            IniciarNuevoMarcador();
            ReiniciarImagenes();
        }

        private void IniciarNuevoMarcador()
        {
            gridMarcador.ItemsSource = null;
            _marcador = Marcador.ObtenerMarcador(_numeroDeJugadores);
            gridMarcador.ItemsSource = _marcador;
        }

        private void ReiniciarImagenes()
        {
            imgJugador2.Source = ConvertirRutaAImagen(_servicioImagenes.ObtenerImagenPorDefecto());
            imgJugador3.Source = ConvertirRutaAImagen(_servicioImagenes.ObtenerImagenPorDefecto());
        }

        private void itemMenuJugarDe3_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            _numeroDeJugadores = (item.IsChecked) ? 3 : 2;
            stackJugador3.Visibility = (item.IsChecked) ? Visibility.Visible : Visibility.Collapsed;
            IniciarNuevoMarcador();
            ReiniciarImagenes();
        }

        private void itemMenuSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
