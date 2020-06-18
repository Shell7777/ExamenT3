using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public int TemaId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }
        public Tema Tema { get; set; }

        public List<ExamenPregunta> Preguntas { get; set; }
    }
}