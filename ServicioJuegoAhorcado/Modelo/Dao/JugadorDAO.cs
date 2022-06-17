using MySql.Data.MySqlClient;
using ServicioJuegoAhorcado.Modelo;
using ServicioJuegoAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoAhorcado.Modelo.Dao
{
    public class JugadorDAO
    {
        public static RespuestaLogin logear (String correo, String password)
        {
            RespuestaLogin respuestaBD = new RespuestaLogin();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if( conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT * FROM jugador WHERE email = @email AND password = @password";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@email", correo);
                    mySqlCommand.Parameters.AddWithValue("@password", password);
                    MySqlDataReader respuesta= mySqlCommand.ExecuteReader();
                    if( respuesta.Read())
                    {
                        respuestaBD.Error = false;
                        respuestaBD.Mensaje = "Bienvenido al juego!!";

                        Jugador jugadorBD = new Jugador();
                        jugadorBD.Id = ((respuesta.IsDBNull(0)) ? 0 : respuesta.GetInt32(0));
                        jugadorBD.Nombre = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));

                        respuestaBD.DatosJugador = jugadorBD;
                    }
                    else
                    {
                        respuestaBD.Error = true;
                        respuestaBD.Mensaje = "Contraseña o usuario inválidos";
                        respuestaBD.DatosJugador = null;
                    }

                }
                catch(Exception ex)
                {
                    respuestaBD.Error = true;
                    respuestaBD.Mensaje = "Hubo un problema de conexión, inténtelo más tarde";
                    respuestaBD.DatosJugador = null;
                }
            }
            else
            {
                respuestaBD.Error = true;
                respuestaBD.Mensaje = "Hubo un problema de conexión, inténtelo más tarde";
                respuestaBD.DatosJugador = null;
            }

            return respuestaBD;
        }

        public static Mensaje insertarJugador(Jugador jugadorRegistro)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sentencia = "INSERT INTO jugador (nombreCompleto, fechaNacimiento, telefono, password, email) " +
                                       "VALUES(@nombreCompleto,@fechaNacimiento,@telefono,@password,@email)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombreCompleto", jugadorRegistro.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", jugadorRegistro.FechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@telefono", jugadorRegistro.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@password", jugadorRegistro.Password);
                    mySqlCommand.Parameters.AddWithValue("@email", jugadorRegistro.Email);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        mensaje.Error = false;
                        mensaje.MensajeRespuesta = "Jugador registrado con éxito";
                    }
                    else
                    {
                        mensaje.Error = true;
                        mensaje.MensajeRespuesta = "Error al registrar el jugador";
                    }

                }
                catch (Exception ex)
                {
                    mensaje.Error = true;
                    mensaje.MensajeRespuesta = ex.Message;
                }
            }
            else
            {
                mensaje.Error = true;
                mensaje.MensajeRespuesta = "Por el momento no hay conexión con los servicios...";
            }
            return mensaje;
        }

        public static Mensaje editarJugador(Jugador jugadorRegistro)
        {
            Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sentencia = "UPDATE jugador SET nombreCompleto = @nombreCompleto,fechaNacimiento = @fechaNacimiento,telefono=@telefono WHERE idJugador = @idJugador";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombreCompleto", jugadorRegistro.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", jugadorRegistro.FechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@telefono", jugadorRegistro.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", jugadorRegistro.Id);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        mensaje.Error = false;
                        mensaje.MensajeRespuesta = "Jugador actualizado con éxito";
                    }
                    else
                    {
                        mensaje.Error = true;
                        mensaje.MensajeRespuesta = "Error al actualizar el Jugador";
                    }

                }
                catch (Exception ex)
                {
                    mensaje.Error = true;
                    mensaje.MensajeRespuesta = ex.Message;
                }
            }
            else
            {
                mensaje.Error = true;
                mensaje.MensajeRespuesta = "Por el momento no hay conexión con los servicios...";
            }
            return mensaje;
        }

        public static bool comprobarExistenciaCorreo(String correo)
        {
            bool resultado = false;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if(conexionBD != null)
            {
                try
                {
                    string consulta = "SELECT idJugador FROM jugador WHERE email = @email";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@email", correo);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                    if (respuesta.Read())
                    {
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    resultado = true;
                } 
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }

        public static int recuperarPuntajeGlobal(int idJugador)
        {
            int puntajeGlobal = -1;
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT puntajeGlobal FROM jugador WHERE idJugador = @idJugador";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                    if (respuesta.Read())
                    {
                        puntajeGlobal = ((respuesta.IsDBNull(0)) ? -1 : respuesta.GetInt32(0));
                    }
                }
                catch (Exception ex)
                {

                }
                
            }

            return puntajeGlobal;
        }

        public static Jugador obtenerDatosJugador(int idJugador)
        {
            Jugador jugadorBD = new Jugador();
            if (idJugador > 0)
            {
                MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();
                if(conexionBD != null)
                {
                    try
                    {
                        String consulta = "SELECT * FROM jugador WHERE idJugador = @idJugador";
                        MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                        mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                        MySqlDataReader respuesta = mySqlCommand.ExecuteReader();
                        if (respuesta.Read())
                        {
                            jugadorBD.Id = ((respuesta.IsDBNull(0)) ? 0 : respuesta.GetInt32(0));
                            jugadorBD.Nombre = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));
                            jugadorBD.FechaNacimiento = ((respuesta.IsDBNull(2)) ? "" : respuesta.GetString(2));
                            jugadorBD.Telefono = ((respuesta.IsDBNull(3)) ? "" : respuesta.GetString(3));
                            jugadorBD.PuntajeGlobal = ((respuesta.IsDBNull(5)) ? 0 : respuesta.GetInt32(5));
                            jugadorBD.Email = ((respuesta.IsDBNull(6)) ? "" : respuesta.GetString(6));
                        }
                    }
                    catch (Exception ex)
                    {
                        jugadorBD = null;
                    }
                    
                }
                else
                {
                    jugadorBD = null;
                }
            }
            return jugadorBD;
        }
    }
}
