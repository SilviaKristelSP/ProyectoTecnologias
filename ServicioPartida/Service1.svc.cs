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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IServiceCallback
    {
            Dictionary<IService1, Partida> _partidas = new Dictionary<IService1, Partida>();
            public void crearPartida(Partida partidaNueva)
            {
                var conexion = OperationContext.Current.GetCallbackChannel<IService1>();
                _partidas[conexion] = partidaNueva;

                foreach (var partida in _partidas.Keys)
                {
                    partida.actualizarPartidas(_partidas.Values);
                }

            }
            public void unirseAPartida()
            {
                var conexion = OperationContext.Current.GetCallbackChannel<IService1>();
                _partidas.Remove(conexion);

                foreach (var partida in _partidas.Keys)
                {
                    partida.actualizarPartidas(_partidas.Values);
                }
            }
    }
}
