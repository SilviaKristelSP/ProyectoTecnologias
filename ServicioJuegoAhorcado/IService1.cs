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
    }
}
