using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public class Papel : Eleccion
    {
        private Dictionary<Type, Resultado> _diccionarioResultados = new Dictionary<Type, Resultado>()
       {
           {typeof(Piedra), Resultado.Ganado },
           {typeof(Tijera), Resultado.Perdido },
           {typeof(Papel), Resultado.Empate }
       };

        public override Resultado JugarContra(Eleccion eleccion)
        {
            return _diccionarioResultados[eleccion.GetType()];
        }
    }
}
