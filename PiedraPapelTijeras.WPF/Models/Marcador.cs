using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijeras.WPF.Models
{
    public class Marcador
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Puntuacion { get; set; }

        public static List<Marcador> ObtenerMarcador(int jugadores)
        {
            var listadoMarcador = new List<Marcador>()
            {
                new Marcador()
                {
                    Id = 1,
                    Description = "Tú",
                    Puntuacion = 0
                },
                new Marcador()
                {
                    Id = 2,
                    Description = "Jugador 2",
                    Puntuacion = 0
                }
            };

            if (jugadores == 3)
            {
                listadoMarcador.Add(new Marcador()
                {
                    Id = 2,
                    Description = "Jugador 3",
                    Puntuacion = 0
                });
            }

            return listadoMarcador;

        }

    }

}
