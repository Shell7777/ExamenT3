using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class Pregunta
    {
        public Pregunta()
        {
            Alternativas = new List<Alternativa>();
        }

        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int TemaId { get; set; }

        public Tema Tema { get; set; }
        public List<Alternativa> Alternativas { get; set; }
    }
}