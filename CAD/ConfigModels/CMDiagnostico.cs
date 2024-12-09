using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMDiagnostico : IEntityTypeConfiguration<CENDiagnostico>
{
    public void Configure(EntityTypeBuilder<CENDiagnostico> builder)
    {
        builder.ToTable("Diagnostico");
        builder.HasKey(d=>d.Id);
        //CONFIGURACION DE RELACION
        

        //COFNFIGURACION DE RESTRICCIONES
        builder.ToTable(t=>{
            t.HasCheckConstraint("CHK_CENDiagnostico_EstadoFetal","EstadoFetal IN (0, 1)");
            t.HasCheckConstraint("CHK_CENDiagnostico_Estado","Estado IN (0,1)");
        });

        builder.Property(d=>d.Sintomas)
                .IsRequired();

        builder.Property(d=>d.EstadoFetal)
                .IsRequired()
                .HasDefaultValue(0);
        builder.Property(d=>d.Recomendacion)
                .IsRequired();

        builder.Property(d=>d.Estado)
                .IsRequired()
                .HasDefaultValue(0);
    }
}