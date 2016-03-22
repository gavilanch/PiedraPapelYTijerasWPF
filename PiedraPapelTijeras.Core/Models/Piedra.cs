using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public class Piedra : Eleccion
    {
        private Dictionary<Type, Resultado> _diccionarioResultados = new Dictionary<Type, Resultado>()
       {
           {typeof(Piedra), Resultado.Empate },
           {typeof(Tijera), Resultado.Ganado },
           {typeof(Papel), Resultado.Perdido }
       };

        public override Resultado JugarContra(Eleccion eleccion)
        {
            return _diccionarioResultados[eleccion.GetType()];
        }
    }
}
