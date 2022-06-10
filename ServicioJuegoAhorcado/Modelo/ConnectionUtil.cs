﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioJuegoAhorcado.Modelo
{
    public class ConnectionUtil
    {
        private static string SERVIDOR = "localhost";
        private static string PUERTO = "3306";
        private static string BASE_DATOS = "ahorcado";
        private static string USUARIO_BD = "root";
        private static string PASSWORD = "Cateto3101";

        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexionBD = null;
            try
            {
                string urlConexion = string.Format("server={0};" + "database={1};" +
                                                   "username={2};" + "password={3};" + "port={4};", 
                                                   SERVIDOR, BASE_DATOS,
                                                   USUARIO_BD, PASSWORD, PUERTO);
                conexionBD = new MySqlConnection(urlConexion);
                conexionBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return conexionBD;
        }

    }
}