using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiedraPapelTijeras.Core.Models;

namespace PiedraPapelTijeras.WPF.Servicios
{
    public class ServicioImagenes
    {
        private Dictionary<Type, string> _dictEleccionImagen;
        private string _imagenPorDefecto;
        public ServicioImagenes()
        {
            _dictEleccionImagen = new Dictionary<Type, string>()
            {
                {typeof(Piedra), "imagenes/piedra.png" },
                {typeof (Tijera), "imagenes/tijera.png" },
                {typeof(Papel), "imagenes/papel.png" }
            };

            _imagenPorDefecto = "imagenes/Interrogacion.png";

        }

        internal string ObtenerImagen(Jugada jugada)
        {
            return _dictEleccionImagen[jugada.Eleccion.GetType()];
        }

        internal string ObtenerImagenPorDefecto()
        {
            return _imagenPorDefecto;   
        }
    }
}
