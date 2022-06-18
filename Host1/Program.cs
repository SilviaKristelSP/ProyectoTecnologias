using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Host1.Modelo.Poco;

namespace Host1
{
    
    [ServiceContract]
    public interface IServicePartida //Las especifico en el cliente
    {
        [OperationContract(IsOneWay = true)]
        void actualizarPartidas(Dictionary<IServicePartida, Partida>.ValueCollection partidas);
    }

    [ServiceContract(CallbackContract = typeof(IServicePartida))]
    public interface IServiceCallback    //Las especifico en el servidor y las llama el cliente
    {
        [OperationContract(IsOneWay = true)]
        void crearPartida(Partida partidaNueva);

        [OperationContract(IsOneWay = true)]
        void unirseAPartida(Partida partidaNueva);
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ServicePartida : IServiceCallback
    {
        Dictionary<IServicePartida, Partida> _partidas = new Dictionary<IServicePartida, Partida>();
        public void crearPartida(Partida partidaNueva)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IServicePartida>();
            _partidas[conexion] = partidaNueva;

            foreach (var partida in _partidas.Keys)
            {
                partida.actualizarPartidas(_partidas.Values);
            }

        }
        public void unirseAPartida(Partida partidaNueva)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IServicePartida>();
            Partida partidaALaQueSeUne;
            _partidas.TryGetValue(conexion, out partidaALaQueSeUne);
            _partidas.Remove(conexion);

            foreach (var partida in _partidas.Keys)
            {
                partida.actualizarPartidas(_partidas.Values);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                ServiceHost host = new ServiceHost(typeof(ServicePartida));
                host.Open();
                Console.WriteLine("Server iniciado, enter para el servicio");
                Console.ReadLine();
                host.Close();

            }
        }
    }
}

