using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using SimuladorExamenUPN.Models;

namespace SimuladorExamenUPN.DB.Maps
{
    public class UsuarioExamenMap : EntityTypeConfiguration<UsuarioExamen>
    {
        public UsuarioExamenMap()
        {
            ToTable("UsuarioExamen");
            HasKey(o => o.Id);
           
        }
    }
}