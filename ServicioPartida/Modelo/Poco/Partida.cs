using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioPartida.Modelo.Poco
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdRetador { get; set; }
        public int IdAdivinador { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPalabra { get; set; }
        public int GanoLaPartida { get; set; }
        public String CorreoRetador { get; set; }
        public String CorreoAdivinador { get; set; }
        public String NombreRetador { get; set; }
        public String NombreAdivinador { get; set; }
        public String Palabra { get; set; }
    }
}