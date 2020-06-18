using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class ExamenPreguntaMap: EntityTypeConfiguration<ExamenPregunta>
    {
        public ExamenPreguntaMap()
        {
            ToTable("ExamenPregunta");
            HasKey(o => o.Id);

            HasRequired(o => o.Pregunta).WithMany().HasForeignKey(o => o.PreguntaId);
        }
    }
}