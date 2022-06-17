using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioJuegoAhorcado.Modelo.Poco;

namespace ServicioJuegoAhorcado.Modelo.Dao
{
    public class CategoriaDAO
    {
        public static List<Categoria> obtenerCategorias()
        {
            List<Categoria> categoriasBD = new List<Categoria>();
            MySqlConnection conexionBD = ConnectionUtil.obtenerConexion();

            if(conexionBD != null)
            {
                try
                {
                    String consulta = "SELECT * FROM categoria";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta, conexionBD);
                    MySqlDataReader respuesta = mySqlCommand.ExecuteReader();

                    while (respuesta.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.IdCategoria = ((respuesta.IsDBNull(0)) ? 0 : respuesta.GetInt32(0));
                        categoria.NombreCategoria = ((respuesta.IsDBNull(1)) ? "" : respuesta.GetString(1));
                        categoriasBD.Add(categoria);
                    }
                }
                catch (Exception ex)
                {
                    categoriasBD = null;
                }
            }
            else
            {
                categoriasBD = null;
            }

            return categoriasBD;
        }
    }
}