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
        private readonly static int _IdJugador1 = 1;

        public static ResultadoJugada Decidir(List<Jugada> jugadas)
        {
            if (jugadas.Count() == 2)
            {
                return DecidirResultadoDosJugadores(jugadas[0], jugadas[1]);
            }
            else
            {
                return DecidirResultadoMasDeDosJugadores(jugadas);
            }
        }

        private static ResultadoJugada DecidirResultadoMasDeDosJugadores(List<Jugada> jugadas)
        {
            var dictResultadosPorId = ObtenerResultadosJugadasDosADos(jugadas);
            List<int> ganadores = ExtraerGanadores(dictResultadosPorId);

            var resultadoJugada = new ResultadoJugada();
            resultadoJugada.Ganadores = ganadores;

            if (!ganadores.Any())
            {
                resultadoJugada.Resultado = Resultado.Empate;
            }
            else if (ganadores.Contains(_IdJugador1))
            {
                resultadoJugada.Resultado = Resultado.Ganado;
            }
            else
            {
                resultadoJugada.Resultado = Resultado.Perdido;
            }

            return resultadoJugada;

        }

        private static List<int> ExtraerGanadores(Dictionary<int, List<Resultado>> dictResultadosPorId)
        {
            return dictResultadosPorId.Where(x =>
            x.Value.Any(v => v == Resultado.Ganado)
            && !x.Value.Any(v => v == Resultado.Perdido)
            ).Select(x => x.Key).ToList();
        }

        private static Dictionary<int, List<Resultado>> ObtenerResultadosJugadasDosADos(List<Jugada> jugadas)
        {
            var dictResultadosPorId = new Dictionary<int, List<Resultado>>();

            for (int i = 0; i < jugadas.Count(); i++)
            {
                var IdJugadorActual = jugadas[i].Id;
                for (int j = 0; j < jugadas.Count(); j++)
                {
                    if (i == j) { continue; }

                    var resultado = DecidirResultadoDosJugadores(jugadas[i], jugadas[j]);

                    EmpujarResultadoAlDiccionario(dictResultadosPorId, IdJugadorActual, resultado);
                }
            }
            return dictResultadosPorId;
        }

        private static void EmpujarResultadoAlDiccionario(Dictionary<int, List<Resultado>> dictResultadosPorId, int IdJugadorActual, ResultadoJugada resultado)
        {
            if (dictResultadosPorId.ContainsKey(IdJugadorActual))
            {
                dictResultadosPorId[IdJugadorActual].Add(resultado.Resultado);
            }
            else
            {
                dictResultadosPorId[IdJugadorActual] = new List<Resultado>() { resultado.Resultado };
            }
        }

        private static ResultadoJugada DecidirResultadoDosJugadores(Jugada jugada1, Jugada jugada2)
        {
            var resultadoJugada = new ResultadoJugada();
            Resultado resultado = jugada1.Eleccion.JugarContra(jugada2.Eleccion);
            resultadoJugada.Resultado = resultado;

            var ganadores = new List<int>();
            if (resultado == Resultado.Ganado)
            {
                ganadores.Add(jugada1.Id);
            }
            else if (resultado == Resultado.Perdido)
            {
                ganadores.Add(jugada2.Id);
            }

            resultadoJugada.Ganadores = ganadores;

            return resultadoJugada;
        }
    }
}
