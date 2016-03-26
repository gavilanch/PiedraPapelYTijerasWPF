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
        public void ActualizarPuntaje(List<Marcador> marcadores, ResultadoJugada resultadoJugada)
        {
            foreach (var marcador in marcadores)
            {
                if (resultadoJugada.Ganadores.Contains(marcador.Id))
                {
                    marcador.Puntuacion++;
                }
            }
        }
    }
}
