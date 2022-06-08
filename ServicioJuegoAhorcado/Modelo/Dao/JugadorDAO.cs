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
                        jugadorBD.FechaNacimiento = ((respuesta.IsDBNull(2)) ? "" : respuesta.GetString(2));
                        jugadorBD.Telefono = ((respuesta.IsDBNull(3)) ? "" : respuesta.GetString(3));
                        jugadorBD.PuntajeGlobal = ((respuesta.IsDBNull(5)) ? 0 : respuesta.GetInt32(5));
                        jugadorBD.Email = ((respuesta.IsDBNull(6)) ? "" : respuesta.GetString(6));

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
    }
}
