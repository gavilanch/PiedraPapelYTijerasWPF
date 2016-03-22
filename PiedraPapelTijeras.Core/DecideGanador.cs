using PiedraPapelTijeras.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core
{
    public static class DecideGanador
    {
        public static ResultadoJugada Decidir(List<Jugada> jugadas)
        {
            var resultadoJugada = new ResultadoJugada();
            var sonTodasIguales = SonTodasLasEleccionesIguales(jugadas);

            if (sonTodasIguales)
            {
                resultadoJugada.Resultado = Resultado.Empate;
                return resultadoJugada;
            }

            if (jugadas.Count() == 2)
            {
               return DecidirResultadoDosJugadores(jugadas);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static ResultadoJugada DecidirResultadoDosJugadores(List<Jugada> jugadas)
        {
            throw new NotImplementedException();   
        }

        private static bool SonTodasLasEleccionesIguales(List<Jugada> jugadas)
        {
            Eleccion tmpEleccion = Eleccion.Desconocido;
            var sonTodasIguales = true;
            foreach (var jugada in jugadas)
            {
                if (tmpEleccion == Eleccion.Desconocido)
                {
                    tmpEleccion = jugada.Eleccion;
                }
                else if (tmpEleccion != jugada.Eleccion)
                {
                    sonTodasIguales = false;
                }
            }

            return sonTodasIguales;
        }
    }
}
