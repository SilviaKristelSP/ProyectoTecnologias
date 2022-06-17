using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServicioJuegoAhorcado.Modelo.Poco;
using ServicioJuegoAhorcado.Modelo.Dao;

namespace ServicioJuegoAhorcado
{
    public class Service1 : IService1
    {
        public RespuestaLogin logear (String correo, String password)
        {
            return JugadorDAO.logear (correo, password);
        }

        public Mensaje insertarJugador(Jugador jugadorRegistro)
        {
            return JugadorDAO.insertarJugador (jugadorRegistro);
        }

        public Mensaje editarJugador(Jugador jugadorRegistro)
        {
            return JugadorDAO.editarJugador(jugadorRegistro);
        }

        public bool comprobarExistenciaCorreo(String correo)
        {
            return JugadorDAO.comprobarExistenciaCorreo(correo);
        }

        public int recuperarPuntajeGlobal(int idJugador)
        {
            return JugadorDAO.recuperarPuntajeGlobal(idJugador);
        }

        public Jugador obtenerDatosJugador(int idJugador)
        {
            return JugadorDAO.obtenerDatosJugador(idJugador);
        }

        public List<Categoria> obtenerCategorias()
        {
            return CategoriaDAO.obtenerCategorias();
        }

        public List<Palabra> obtenerPalabras()
        {
            return PalabraDAO.obtenerPalabras();
        }

        public List<Partida> obtenerPartidasGanadas(int idJugador)
        {
            return PartidaDAO.obtenerPartidasGanadas(idJugador);
        }
        
        public bool registrarPartida(Partida partidaGanada)
        {
            return PartidaDAO.registrarPartida(partidaGanada);
        }

    }
}
