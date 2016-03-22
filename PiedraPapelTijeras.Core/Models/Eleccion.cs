using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.Core.Models
{
    public abstract class Eleccion
    {
        public abstract Resultado JugarContra(Eleccion eleccion);
    }
}
