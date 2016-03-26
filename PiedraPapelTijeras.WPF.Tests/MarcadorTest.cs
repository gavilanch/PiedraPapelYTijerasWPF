using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedraPapelTijeras.WPF.Models;

namespace PiedraPapelTijeras.WPF.Tests
{
    [TestClass]
    public class MarcadorTest
    {
        [TestMethod]
        public void Trae_3_Marcadores_Con_Ids_1_2_3()
        {
            var marcadores = Marcador.ObtenerMarcador(3);
            Assert.AreEqual(1, marcadores[0].Id);
            Assert.AreEqual(2, marcadores[1].Id);
            Assert.AreEqual(3, marcadores[2].Id);
        }
    }
}
