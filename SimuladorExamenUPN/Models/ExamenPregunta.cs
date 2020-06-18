using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class ExamenPregunta
    {
        public int Id { get; set; }
        public int ExamenId { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}