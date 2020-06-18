using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB.Maps
{
    public class TemaMap: EntityTypeConfiguration<Tema>
    {
        public TemaMap()
        {
            ToTable("Tema");
            HasKey(o => o.Id);

            HasMany(o => o.Categorias)
             .WithOptional()
             .HasForeignKey( o => o.TemaId);


            //Property(o => o.Nombre).HasColumnName("Nombre");
        }
    }
}