using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class AlternativaMap : EntityTypeConfiguration<Alternativa>
    {
        public AlternativaMap()
        {
            ToTable("Alternativa");
            HasKey(o => o.Id);

            HasRequired(o => o.Pregunta)
                .WithMany(o => o.Alternativas)
                .HasForeignKey(o => o.PreguntaId);
                

        }
    }
}