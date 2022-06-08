using ServicioJuegoAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioJuegoAhorcado.Modelo.Poco
{
    public class RespuestaLogin
    {
        public String Mensaje { get; set; }
        public bool Error { get; set; }
        public Jugador DatosJugador { get; set; }

    }
}