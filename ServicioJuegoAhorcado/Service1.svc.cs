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
        public RespuestaLogin logear(String correo, String password)
        {
            return JugadorDAO.logear(correo, password);
        }

        public Mensaje insertarJugador(Jugador jugadorRegistro)
        {
            return JugadorDAO.insertarJugador(jugadorRegistro);
        }

        public Mensaje editarJugador(Jugador jugadorRegistro)
        {
            return JugadorDAO.editarJugador(jugadorRegistro);
        }

        public bool comprobarExistenciaCorreo(String correo)
        {
            return JugadorDAO.comprobarExistenciaCorreo(correo);
        }

        public int obtenerPuntajeGlobal(int idJugador)
        {
            return JugadorDAO.obtenerPuntajeGlobal(idJugador);
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

        //PARTIDA
        public List<Partida> recuperarPartidasDisponibles()
        {
            return PartidaDAO.recuperarPartidasDisponibles();
        }

        public int registrarPartidaNueva(Partida partidaNueva)
        {
            return PartidaDAO.registrarPartidaNueva(partidaNueva);
        }

        public String verificarUnionAPartida(int idPartida)
        {
            return PartidaDAO.verificarUnionAPartida(idPartida);
        }

        public bool unirseAPartida(int idPartida, int idAdivinador)
        {
            return PartidaDAO.unirseAPartida(idPartida, idAdivinador);
        }

        public bool registrarTurno(int idPartida, Turno turno)
        {
            return PartidaDAO.registrarTurno(idPartida, turno);
        }

        public Turno recuperarTurno(int idPartida)
        {
            return PartidaDAO.recuperarTurno(idPartida);
        }

        public bool registrarPartidaGanada(int idPartida, int idAdivinador)
        {
            return PartidaDAO.registrarPartidaGanada(idPartida, idAdivinador);
        }

        public bool eliminarPartidaPerdidaOAbandonada(int idPartida)
        {
            return PartidaDAO.eliminarPartidaPerdidaOAbandonada(idPartida);
        }

        public String verificarEstadoPartida(int idPartida)
        {
            return PartidaDAO.verificarEstadoPartida(idPartida);
        }

        public List<Partida> obtenerPartidasGanadas(int idJugador)
        {
            return PartidaDAO.obtenerPartidasGanadas(idJugador);
        }

    }
}
