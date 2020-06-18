using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class UsuarioExamen
    {
        public int Id { get; set; }

        public int ExamenId { get; set; }
      
        public int UsuarioId { get; set; }
     
        public DateTime Fecha { get; set; }

        public double Puntaje { get; set; }
    }
}