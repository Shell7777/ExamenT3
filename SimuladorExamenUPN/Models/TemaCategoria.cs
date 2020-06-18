using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Models
{
    public class TemaCategoria
    {
        public int  Id{ get; set; }
        public int TemaId{ get; set; }
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

    }
}