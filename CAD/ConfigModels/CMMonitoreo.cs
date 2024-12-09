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
    }   
}