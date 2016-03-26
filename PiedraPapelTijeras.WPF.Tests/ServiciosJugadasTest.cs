using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.WPF.Tests
{
    [TestClass]
    public class ServiciosJugadasTest
    {
        [TestMethod]
        public void Servicio_Jugadas_Devuelve_Dos_Jugadas()
        {
            var servicioJugadas = new ServicioJugadas();
            var eleccion = new Piedra();
            var jugadas = servicioJugadas.ObtenerJugadas(eleccion, 2);
            Assert.AreEqual(2, jugadas.Count);
        }

        [TestMethod]
        public void Servicio_Jugadas_Devuelve_Tres_Jugadas()
        {
            var servicioJugadas = new ServicioJugadas();
            var eleccion = new Piedra();
            var jugadas = servicioJugadas.ObtenerJugadas(eleccion, 3);
            Assert.AreEqual(3, jugadas.Count);
        }

        [TestMethod]
        public void Servicio_Jugadas_Devuelve_La_Eleccion_Del_Jugador()
        {
            var servicioJugadas = new ServicioJugadas();
            var eleccion = new Piedra();
            var jugadas = servicioJugadas.ObtenerJugadas(eleccion, 3);
            Assert.AreEqual(eleccion.GetType(), jugadas[0].Eleccion.GetType());
        }
    }
}
