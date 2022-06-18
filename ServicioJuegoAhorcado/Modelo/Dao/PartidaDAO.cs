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
        public static List<Partida> recuperarPartidasDisponibles()
        {
            List<Partida> partidasGanadas = new List<Partida>();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if (conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT partida.idPartida, palabra.palabra, palabra.pista, palabra.categoria, " +
                                      "jugador.nombreCompleto, jugador.email, partida.fecha " +
                                      "FROM partida INNER JOIN jugador ON " +
                                      "partida.retador = jugador.idJugador INNER JOIN palabra ON " +
                                      "partida.palabraAdivinada = palabra.idPalabra WHERE " +
                                      "partida.estadoPartida = @estadoPartida ";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@estadoPartida", "En Espera");
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Partida aux = new Partida();
                        aux.IdPartida = ((respuesta.IsDBNull(0)) ? 0 : respuesta.GetInt32(0));
                        aux.Palabra = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));
                        aux.Pista = ((respuesta.IsDBNull(2)) ? "" : respuesta.GetString(2));
                        aux.Categoria = ((respuesta.IsDBNull(3)) ? "" : respuesta.GetString(3));
                        aux.NombreRetador = ((respuesta.IsDBNull(4)) ? "" : respuesta.GetString(4));
                        aux.CorreoRetador = ((respuesta.IsDBNull(5)) ? "" : respuesta.GetString(5));
                        aux.Fecha = ((respuesta.IsDBNull(6)) ? new DateTime(0, 0, 0) : respuesta.GetDateTime(6));

                        partidasGanadas.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    partidasGanadas = null;
                }
            }
            else
            {
                partidasGanadas = null;
            }

            return partidasGanadas;
        }

        public static int registrarPartidaNueva(Partida partidaNueva)
        {
            int resultadoInsercion = -1;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "INSERT INTO partida (ganador, retador, fecha, palabraAdivinada, estadoPartida)" +
                                       "VALUES (@ganador, @idRetador, @fecha, @idPalabra, @estadoPartida)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@ganador", 0);
                    mySqlCommand.Parameters.AddWithValue("@idRetador", partidaNueva.IdRetador);
                    mySqlCommand.Parameters.AddWithValue("@fecha", partidaNueva.Fecha);
                    mySqlCommand.Parameters.AddWithValue("@idPalabra", partidaNueva.IdPalabra);
                    mySqlCommand.Parameters.AddWithValue("@estadoPartida", "En Espera");
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        String sentencia2 = "SELECT idPartida FROM partida WHERE retador = @idRetador AND estadoPartida = @estadoPartida";
                        MySqlCommand mySqlCommand2 = new MySqlCommand(sentencia2, conexionBD);
                        mySqlCommand2.Parameters.AddWithValue("@idRetador", partidaNueva.IdRetador);
                        mySqlCommand2.Parameters.AddWithValue("@estadoPartida", "En Espera");
                        MySqlDataReader respuesta = mySqlCommand2.ExecuteReader();
                        if (respuesta.Read())
                        {
                            resultadoInsercion = ((respuesta.IsDBNull(0)) ? -1 : respuesta.GetInt32(0));
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }

            return resultadoInsercion;
        }

        public static String verificarUnionAPartida(int idPartida)
        {
            String nombreAdivinador = "Sin Adivinador";
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT jugador.nombreCompleto FROM partida INNER JOIN jugador ON " +
                                      "partida.adivinador = jugador.idJugador WHERE partida.idPartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                    if (respuesta.Read())
                    {
                        nombreAdivinador = ((respuesta.IsDBNull(0)) ? "Sin Adivinador" : respuesta.GetString(0)); ;
                    }
                }
                catch (Exception e)
                {
                }
            }
            return nombreAdivinador;
        }

        public static bool unirseAPartida(int idPartida, int idAdivinador)
        {
            bool resultadoInsercion = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "UPDATE partida SET estadoPartida = @estadoPartida, adivinador = @idAdivinador " +
                                       "WHERE idpartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@estadoPartida", "Iniciada");
                    mySqlCommand.Parameters.AddWithValue("@idAdivinador", idAdivinador);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int respuesta = mySqlCommand.ExecuteNonQuery();
                    if (respuesta > 0)
                    {
                        resultadoInsercion = true;
                    }
                }
                catch (Exception e)
                {

                }
            }
            return resultadoInsercion;
        }

        public static bool registrarTurno(int idPartida, Turno turno)
        {
            bool resultadoInsercion = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "UPDATE partida SET letraAdvinador = @letraAdivinador, " +
                                       "intentosRestantes = @intentosRestantes WHERE idPartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@letraAdivinador", turno.Letra);
                    mySqlCommand.Parameters.AddWithValue("@intentosRestantes", turno.IntentosRestantes);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int respuesta = mySqlCommand.ExecuteNonQuery();
                    if (respuesta > 0)
                    {
                        resultadoInsercion = true;
                    }
                }
                catch (Exception e)
                {

                }
            }
            return resultadoInsercion;
        }

        public static Turno recuperarTurno(int idPartida)
        {
            Turno turno = new Turno();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "SELECT letraAdvinador, intentosRestantes FROM partida WHERE idpartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                    if (respuesta.Read())
                    {
                        turno.Letra = ((respuesta.IsDBNull(0)) ? "" : respuesta.GetString(0));
                        turno.IntentosRestantes = ((respuesta.IsDBNull(1)) ? 0 : respuesta.GetInt32(1));
                    }
                    else
                    {
                        turno = null;
                    }
                }
                catch (Exception e)
                {
                    turno = null;
                }
            }
            else
            {
                turno = null;
            }
            return turno;
        }

        public static bool registrarPartidaGanada(int idPartida, int idAdivinador)
        {
            bool resultadoInsercion = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "UPDATE partida SET ganador = @ganador, estadoPartida = @estadoPartida " +
                                       "WHERE idPartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@ganador", 1);
                    mySqlCommand.Parameters.AddWithValue("@estadoPartida", "Finalizada");
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        int puntajeGlobal = JugadorDAO.obtenerPuntajeGlobal(idAdivinador);
                        if (puntajeGlobal > -1)
                        {
                            puntajeGlobal += 10;
                            String sentencia2 = "UPDATE jugador SET puntajeGlobal = @puntajeGlobal WHERE idJugador = @idAdivinador";
                            MySqlCommand mySqlCommand2 = new MySqlCommand(sentencia2, conexionBD);
                            mySqlCommand2.Parameters.AddWithValue("@puntajeGlobal", puntajeGlobal);
                            mySqlCommand2.Parameters.AddWithValue("@idAdivinador", idAdivinador);
                            mySqlCommand2.Prepare();
                            int filasAfectadas2 = mySqlCommand2.ExecuteNonQuery();
                            if (filasAfectadas2 > 0)
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

        public static bool eliminarPartidaPerdidaOAbandonada(int idPartida)
        {
            bool resultadoInsercion = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String sentencia = "DELETE FROM partida WHERE idPartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        resultadoInsercion = true;
                    }
                }
                catch (Exception e)
                {
                }
            }

            return resultadoInsercion;
        }

        public static String verificarEstadoPartida(int idPartida)
        {
            String estadoPartida = "Eliminada o Abandonada";
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT partida.estadoPartida FROM partida WHERE partida.idPartida = @idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                    if (respuesta.Read())
                    {
                        estadoPartida = ((respuesta.IsDBNull(0)) ? "Eliminada o Abandonada" : respuesta.GetString(0));
                    }

                }
                catch (Exception ex)
                {

                }
            }

            return estadoPartida;
        }

        public static List<Partida> obtenerPartidasGanadas(int idJugador)
        {
            List<Partida> partidasGanadas = new List<Partida>();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();            

            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT partida.fecha, jugador.nombreCompleto FROM partida INNER JOIN jugador ON " +
                                      "partida.retador = jugador.idJugador INNER JOIN palabra ON " +
                                      "partida.palabraAdivinada = palabra.idPalabra WHERE partida.adivinador = @idAdivinador " +
                                      "AND partida.ganador = 1";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idAdivinador", idJugador);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Partida aux = new Partida();
                        aux.Fecha = ((respuesta.IsDBNull(0)) ? new DateTime(0,0,0) : respuesta.GetDateTime(0));
                        aux.NombreRetador = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));

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