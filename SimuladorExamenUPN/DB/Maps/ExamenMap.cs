using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class ExamenMap: EntityTypeConfiguration<Examen>
    {
        public ExamenMap()
        {
            ToTable("Examen");
            HasKey(o => o.Id);

            HasRequired(o => o.Tema)
                .WithMany()
                .HasForeignKey(o => o.TemaId);

            HasMany(o => o.Preguntas)
                .WithRequired()
                .HasForeignKey(o => o.ExamenId);

            HasRequired(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.UsuarioId);
        }
    }
}