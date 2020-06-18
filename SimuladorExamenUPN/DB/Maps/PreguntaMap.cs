using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class PreguntaMap: EntityTypeConfiguration<Pregunta>
    {
        public PreguntaMap()
        {
            ToTable("Pregunta");
            HasKey(o => o.Id);

            HasRequired(o => o.Tema)
                .WithMany(o => o.Preguntas)
                .HasForeignKey(o => o.TemaId);
                

        }
    }
}