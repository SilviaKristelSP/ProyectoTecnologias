using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServicioPartida.Modelo.Poco;

namespace ServicioPartida
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void actualizarPartidas(Dictionary<IService1, Partida>.ValueCollection partidas);
    }

    [ServiceContract(CallbackContract = typeof(IService1))]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void crearPartida(Partida partidaNueva);

        [OperationContract(IsOneWay = true)]
        void unirseAPartida();
    }
}
