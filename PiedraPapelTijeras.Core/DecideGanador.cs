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
            var resultadoJugada = new ResultadoJugada();
            Resultado resultado = jugadas[0].Eleccion.JugarContra(jugadas[1].Eleccion);
            resultadoJugada.Resultado = resultado;
            return resultadoJugada;
        }

        private static bool SonTodasLasEleccionesIguales(List<Jugada> jugadas)
        {
            Type tmpEleccion = null;
            var sonTodasIguales = true;
            foreach (var jugada in jugadas)
            {
                if (tmpEleccion == null)
                {
                    tmpEleccion = jugada.Eleccion.GetType();
                }
                else if (tmpEleccion != jugada.Eleccion.GetType())
                {
                    sonTodasIguales = false;
                    break;
                }
            }

            return sonTodasIguales;
        }
    }
}
