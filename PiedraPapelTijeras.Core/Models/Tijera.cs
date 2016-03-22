using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public class Tijera : Eleccion
    {
        private Dictionary<Type, Resultado> _diccionarioResultados = new Dictionary<Type, Resultado>()
       {
           {typeof(Piedra), Resultado.Perdido },
           {typeof(Tijera), Resultado.Empate },
           {typeof(Papel), Resultado.Ganado }
       };

        public override Resultado JugarContra(Eleccion eleccion)
        {
            return _diccionarioResultados[eleccion.GetType()];
        }
    }
}
