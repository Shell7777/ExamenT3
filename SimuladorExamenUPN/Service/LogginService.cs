using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SimuladorExamenUPN.Service
{
    public interface ILogginService {
         int getLoggerUserId();

    }
    public class LogginService:ILogginService 
    {
        public int getLoggerUserId() {
            var logeado = HttpContext.Current.Session["LoggedUserId"];

            if (logeado!= null) {
                return (int)logeado;
            }

            throw new Exception();
            
        
        }
    }
}