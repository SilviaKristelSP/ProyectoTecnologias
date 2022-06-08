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
    }
}
