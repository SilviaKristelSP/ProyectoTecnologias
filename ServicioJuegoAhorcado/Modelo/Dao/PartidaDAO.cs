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
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();            

            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT partida.fecha, jugador.email FROM partida INNER JOIN jugador ON " +
                                      "partida.retador = jugador.idJugador INNER JOIN palabra ON " +
                                      "partida.palabraAdivinada = palabra.idPalabra WHERE partida.adivinador = @idAdivinador";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idAdivinador", idJugador);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Partida aux = new Partida();
                        aux.Fecha = ((respuesta.IsDBNull(0)) ? new DateTime(0,0,0) : respuesta.GetDateTime(0));
                        aux.CorreoRetador = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));

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

        public static bool registrarPartida(Partida partidaGanada)
        {
            bool resultadoInsercion = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    String sentencia = "INSERT INTO partida (retador, adivinador, fecha, palabraAdivinada, ganador)" +
                                       "VALUES (@idRetador, @idAdivinador, @fecha, @idPalabra, @ganador)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idRetador", partidaGanada.IdRetador);
                    mySqlCommand.Parameters.AddWithValue("@idAdivinador", partidaGanada.IdAdivinador);
                    mySqlCommand.Parameters.AddWithValue("@fecha", partidaGanada.Fecha);
                    mySqlCommand.Parameters.AddWithValue("@idPalabra", partidaGanada.IdPalabra);
                    mySqlCommand.Parameters.AddWithValue("@ganador", 1);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if(filasAfectadas > 0)
                    {
                        int puntajeGlobal = JugadorDAO.recuperarPuntajeGlobal(partidaGanada.IdAdivinador);
                        if(puntajeGlobal > -1)
                        {
                            puntajeGlobal += 10;
                            String sentencia2 = "UPDATE jugador SET puntajeGlobal = @puntajeGlobal WHERE idJugador = @idAdivinador";
                            MySqlCommand mySqlCommand2 = new MySqlCommand(sentencia2, conexionBD);
                            mySqlCommand2.Parameters.AddWithValue("@puntajeGlobal", puntajeGlobal);
                            mySqlCommand2.Parameters.AddWithValue("@idAdivinador", partidaGanada.IdAdivinador);
                            mySqlCommand.Prepare();
                            filasAfectadas = mySqlCommand.ExecuteNonQuery();
                            if(filasAfectadas > 0)
                            {
                                resultadoInsercion = true;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }

            return resultadoInsercion;
        }
    }
}