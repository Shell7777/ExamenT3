using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EsCorrecto { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}