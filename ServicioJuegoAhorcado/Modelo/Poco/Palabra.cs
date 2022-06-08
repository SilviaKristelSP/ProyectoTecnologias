using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoAhorcado.Modelo.Poco
{
    public class Palabra
    {
        public int IdPalabra { get; set; }
        public string PalabraSecreta { get; set; }
        public string Pista { get; set; }
        public int IdCategoria { get; set; }
    }
}
