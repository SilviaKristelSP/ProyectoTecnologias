using ServicioJuegoAhorcado.Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioJuegoAhorcado
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        RespuestaLogin logear(String correo, String password);

        [OperationContract]
        Mensaje insertarJugador(Jugador jugadorRegistro);

        [OperationContract]
        Mensaje editarJugador(Jugador jugadorRegistro);

        [OperationContract]
        bool comprobarExistenciaCorreo(String correo);

        [OperationContract]
        int obtenerPuntajeGlobal(int idJugador);

        [OperationContract]
        Jugador obtenerDatosJugador(int idJugador);

        [OperationContract]
        List<Categoria> obtenerCategorias();

        [OperationContract]
        List<Palabra> obtenerPalabras();

        [OperationContract]
        List<Partida> recuperarPartidasDisponibles();

        [OperationContract]
        int registrarPartidaNueva(Partida partidaNueva);

        [OperationContract]
        String verificarUnionAPartida(int idPartida);

        [OperationContract]
        bool unirseAPartida(int idPartida, int idAdivinador);

        [OperationContract]
        bool registrarTurno(int idPartida, Turno turno);

        [OperationContract]
        Turno recuperarTurno(int idPartida);

        [OperationContract]
        bool registrarPartidaGanada(int idPartida, int idAdivinador);

        [OperationContract]
        bool eliminarPartidaPerdidaOAbandonada(int idPartida);

        [OperationContract]
        String verificarEstadoPartida(int idPartida);

        [OperationContract]
        List<Partida> obtenerPartidasGanadas(int idJugador);

        [OperationContract]
        String recuperarNombreAdivinador(int idPartida);

        [OperationContract]
        int recuperarEstadoGanador(int idPartida);
    }
}
