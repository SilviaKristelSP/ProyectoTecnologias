using MySql.Data.MySqlClient;
using ServicioJuegoAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioJuegoAhorcado.Modelo.Dao
{
    public class PartidaDAO
    { 
        public static List<Partida> obtenerPartidasGanadas(int idJugador)
        {
            List<Partida> partidasGanadas = new List<Partida>();
            const string CONSULTA = "SELECT * FROM partida WHERE adivinador=@idAdivinador AND ganador=1";
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if(conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(CONSULTA, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idAdivinador", idJugador);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Partida aux = new Partida();
                        aux.IdPartida = ((respuesta.IsDBNull(0)) ? -1 : respuesta.GetInt32(0));
                        aux.IdRetador = ((respuesta.IsDBNull(1)) ? -1 : respuesta.GetInt32(1));
                        aux.IdArdivinador = ((respuesta.IsDBNull(2)) ? -1 : respuesta.GetInt32(2));
                        aux.Fecha = ((respuesta.IsDBNull(3)) ? new DateTime(0,0,0) : respuesta.GetDateTime(3));
                        aux.IdPalabra = ((respuesta.IsDBNull(4) ? -1 : respuesta.GetInt32(4)));
                        aux.GanoLaPartida = ((respuesta.IsDBNull(5) ? 0 : respuesta.GetInt32(5)));

                        partidasGanadas.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine($"Error al recuperar las partidas ganadas por el ID: {idJugador}");
                    return null;
                }
            }

            return partidasGanadas;
        }
    }
}