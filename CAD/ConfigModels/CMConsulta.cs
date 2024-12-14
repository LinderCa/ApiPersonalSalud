using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMConsulta:IEntityTypeConfiguration<CENConsulta>
{
    public void Configure(EntityTypeBuilder<CENConsulta> builder)
    {
        builder.ToTable("Consulta");
        builder.HasKey(o=>o.Id);
        builder.Property(o=>o.Descripcion)
                .IsRequired(false);
        builder.Property(o=>o.Resultados)
                .IsRequired(false);
        // Configuración de la clave foránea para la relación uno-a-uno
        builder.HasOne(o => o.Cita)
               .WithOne(c => c.Consulta)
               .HasForeignKey<CENConsulta>(o => o.IdCita)
               .OnDelete(DeleteBehavior.Cascade);
    }
}