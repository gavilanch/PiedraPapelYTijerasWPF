using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public class Piedra : Eleccion
    {
        public override Resultado JugarContra(Eleccion eleccion)
        {
            var type = eleccion.GetType();

            if (type == typeof(Piedra))
            {
                return Resultado.Empate;
            }
            else if (type == typeof(Tijera))
            {
                return Resultado.Ganado;
            }
            else if (type == typeof(Papel))
            {
                return Resultado.Perdido;
            }

            return Resultado.Empate;
        }
    }
}
