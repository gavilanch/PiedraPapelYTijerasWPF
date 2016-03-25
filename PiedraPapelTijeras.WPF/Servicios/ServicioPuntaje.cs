using PiedraPapelTijeras.Core.Models;
using PiedraPapelTijeras.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.WPF.Servicios
{
    public class ServicioPuntaje
    {
        public void ActualizarPuntaje(List<Marcador> marcador, ResultadoJugada decideGanador)
        {
            if (decideGanador.Resultado == Resultado.Ganado)
            {
                marcador[0].Puntuacion++;
            }
            else if (decideGanador.Resultado == Resultado.Perdido)
            {
                marcador[1].Puntuacion++;
            }
        }
    }
}
