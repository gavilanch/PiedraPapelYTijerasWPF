using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedraPapelTijeras.Core.Models;
using System.Collections.Generic;
using PiedraPapelTijeras.Core;

namespace PiedraPapelTijeras.WPF.Tests
{
    [TestClass]
    public class DecideGanadorTest
    {
        [TestMethod]
        public void Dos_Jugadores_Con_Misma_Eleccion_Empates()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Piedra() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Piedra() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Empate);

        }

        [TestMethod]
        public void Dos_Jugadores_Piedra_Contra_Tijera_Ganador()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Piedra() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Tijera() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Ganado);

        }

        [TestMethod]
        public void Dos_Jugadores_Tijera_Contra_Papel_Ganador()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Tijera() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Papel() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Ganado);

        }

        [TestMethod]
        public void Dos_Jugadores_Papel_Contra_Piedra_Ganador()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Papel() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Piedra() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Ganado);

        }

        [TestMethod]
        public void Dos_Jugadores_Papel_Contra_Tijera_Pierde()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Papel() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Tijera() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Perdido);

        }

        [TestMethod]
        public void Dos_Jugadores_Tijera_Contra_Piedra_Pierde()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Tijera() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Piedra() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Perdido);

        }

        [TestMethod]
        public void Dos_Jugadores_Piedra_Contra_Papel_Pierde()
        {
            var jugada1 = new Jugada() { Id = 1, Eleccion = new Piedra() };
            var jugada2 = new Jugada() { Id = 2, Eleccion = new Papel() };

            var jugadas = new List<Jugada>()
            {
                jugada1, jugada2
            };

            var decideGanador = DecideGanador.Decidir(jugadas);

            Assert.AreEqual(decideGanador.Resultado, Resultado.Perdido);

        }
    }
}
