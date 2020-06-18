using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class TemaCategoriaMap:EntityTypeConfiguration<TemaCategoria>
    {
        public TemaCategoriaMap()
        {
            ToTable("TemaCategoria");
            HasKey(a=>a.Id);

            HasRequired(a => a.Categoria).
                WithMany()
                .HasForeignKey(a => a.CategoriaId);
        }
    }
}