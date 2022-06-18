using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServicioJugabilidad.Modelo.Poco;

namespace ServicioJugabilidad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ServicePartida : IServiceCallback
    {
        Dictionary<IServicePartida, Partida> _partidas = new Dictionary<IServicePartida, Partida>();
        public void crearPartida(Partida partidaNueva)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IServicePartida>();
            _partidas[conexion] = partidaNueva;

            foreach(var partida in _partidas.Keys)
            {
                partida.actualizarPartidas(_partidas.Values);
            }

        }
        public Partida unirseAPartida()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IServicePartida>();
            Partida partidaALaQueSeUne;
            _partidas.TryGetValue(conexion, out partidaALaQueSeUne);
            _partidas.Remove(conexion);

            foreach (var partida in _partidas.Keys)
            {
                partida.actualizarPartidas(_partidas.Values);
            }

            return partidaALaQueSeUne;
        }
    }
}
