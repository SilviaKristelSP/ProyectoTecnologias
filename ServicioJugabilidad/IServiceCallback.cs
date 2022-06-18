using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServicioJugabilidad.Modelo.Poco;


namespace ServicioJugabilidad
{
    [ServiceContract(CallbackContract = typeof(IServicePartida))]
    public interface IServiceCallback
    {
         [OperationContract(IsOneWay = true)]
         void crearPartida(Partida partidaNueva);

         [OperationContract(IsOneWay = true)]
         Partida unirseAPartida();
    }
}
