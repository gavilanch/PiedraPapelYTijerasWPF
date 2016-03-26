using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public class ResultadoJugada
    {
        public Resultado Resultado { get; set; }
        public List<int> Ganadores { get; set; }
    }
}
