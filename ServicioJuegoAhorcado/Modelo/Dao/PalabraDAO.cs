using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioJuegoAhorcado.Modelo.Poco;

namespace ServicioJuegoAhorcado.Modelo.Dao
{
    public class PalabraDAO
    {
        public static List<Palabra> obtenerPalabras()
        {
            List<Palabra> palabrasBD = new List<Palabra>();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT * FROM palabra";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Palabra palabra = new Palabra();
                        palabra.IdPalabra = ((respuesta.IsDBNull(0)) ? 0 : respuesta.GetInt32(0));
                        palabra.PalabraSecreta = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));
                        palabra.Pista = ((respuesta.IsDBNull(2)) ? "" : respuesta.GetString(2));
                        palabra.IdCategoria = ((respuesta.IsDBNull(3)) ? 0 : respuesta.GetInt32(3));
                        palabrasBD.Add(palabra);
                    }
                }
                catch(Exception ex)
                {
                    palabrasBD = null;
                }
            }
            else
            {
                palabrasBD = null;
            }

            return palabrasBD;
        } 
    }
}