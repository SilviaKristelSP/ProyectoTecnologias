using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoAhorcado.Modelo.Poco
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdRetador { get; set; }
        public int IdArdivinador { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPalabra { get; set; }
        public int GanoLaPartida { get; set; }
    }
}
