using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMMonitoreo : IEntityTypeConfiguration<CENMonitoreo>
{
    public void Configure(EntityTypeBuilder<CENMonitoreo> builder)
    {
        builder.ToTable("Monitoreo");
        builder.HasKey(m=>m.Id);
        builder.Property(m=>m.Proceso)
                .IsRequired();
        builder.Property(m=>m.Tipo)
                .IsRequired();        
                
        //CONSTRAINT
        builder.ToTable(t=>{
            t.HasCheckConstraint("CHK_CENMonitoreo_Proceso","Proceso IN (0,1)");
            t.HasCheckConstraint("CHK_CENMonitoreo_Tipo"," Tipo IN (0,1)");
        });

        //RELACION: Un monitoreo tiene un diagnostico
        builder.HasOne(m=>m.Diagnostico) //uno a uno
                .WithOne(d=>d.Monitoreo)
                .HasForeignKey<CENDiagnostico>(d=>d.IdMonitoreo)
                .OnDelete(DeleteBehavior.Cascade);

        //RELAION:Un monitore genera datosBiometricos
        builder.HasOne(m=>m.DatosBiometricos)
                .WithOne(b=>b.Monitoreo)
                .HasForeignKey<CENDatosBiometricos>(b=>b.IdMonitoreo)
                .OnDelete(DeleteBehavior.Cascade);
    }   
}