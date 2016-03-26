using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedraPapelTijeras.WPF.Models;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Servicios;
using System.Collections.Generic;

namespace PiedraPapelTijeras.WPF.Tests
{
    [TestClass]
    public class ServicioPuntajeTest
    {
        [TestMethod]
        public void Servicio_Puntaje_Ganado_Aumenta_Punto_Al_Jugador()
        {
            var marcador = Marcador.ObtenerMarcador(2);
            var resultadoJugada = new ResultadoJugada() { Resultado = Resultado.Ganado };
            var servicioPuntaje = new ServicioPuntaje();
            resultadoJugada.Ganadores = new List<int>() { 1 };
            servicioPuntaje.ActualizarPuntaje(marcador, resultadoJugada);
            Assert.AreEqual(1, marcador[0].Puntuacion);
            Assert.AreEqual(0, marcador[1].Puntuacion);
        }

        [TestMethod]
        public void Servicio_Puntaje_Perdida_Aumenta_Punto_Al_Jugador_Dos()
        {
            var marcador = Marcador.ObtenerMarcador(2);
            var resultadoJugada = new ResultadoJugada() { Resultado = Resultado.Perdido };
            var servicioPuntaje = new ServicioPuntaje();
            resultadoJugada.Ganadores = new List<int>() { 2 };
            servicioPuntaje.ActualizarPuntaje(marcador, resultadoJugada);
            Assert.AreEqual(0, marcador[0].Puntuacion);
            Assert.AreEqual(1, marcador[1].Puntuacion);
        }

        [TestMethod]
        public void Servicio_Puntaje_Empate_No_Altera_Puntuacion()
        {
            var marcador = Marcador.ObtenerMarcador(2);
            var resultadoJugada = new ResultadoJugada() { Resultado = Resultado.Empate };
            var servicioPuntaje = new ServicioPuntaje();

            resultadoJugada.Ganadores = new List<int>();
            servicioPuntaje.ActualizarPuntaje(marcador, resultadoJugada);
            Assert.AreEqual(0, marcador[0].Puntuacion);
            Assert.AreEqual(0, marcador[0].Puntuacion);
        }

        [TestMethod]
        public void Servicio_Puntaje_Ganadores_Jugador1_y_Jugador3()
        {
            var marcador = Marcador.ObtenerMarcador(3);
            var resultadoJugada = new ResultadoJugada() { Resultado = Resultado.Ganado };
            var ganadores = new List<int>() { 1, 3 };
            resultadoJugada.Ganadores = ganadores;
            var servicioPuntaje = new ServicioPuntaje();
            servicioPuntaje.ActualizarPuntaje(marcador, resultadoJugada);

            Assert.AreEqual(1, marcador[0].Puntuacion);
            Assert.AreEqual(0, marcador[1].Puntuacion);
            Assert.AreEqual(1, marcador[2].Puntuacion);
        }
    }
}
