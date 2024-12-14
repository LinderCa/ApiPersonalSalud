using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMUsuario:IEntityTypeConfiguration<CENUsuario>
{   
    public void Configure(EntityTypeBuilder<CENUsuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(u=>u.Id);
        builder.Property(u=>u.User)
                .IsRequired();
        builder.Property(u=>u.Password)
                .IsRequired();
        builder.Property(u=>u.Rol)
                .HasMaxLength(50);
        builder.ToTable(t=>{
            t.HasCheckConstraint("CHK_CENUsuario_Rol","Rol BETWEEN 0 AND 3");
        });

        builder.Property(u=>u.Estado)
                .HasDefaultValue(false);
        builder.Property(u=>u.IdGestante)
                .IsRequired(false);
        builder.Property(u=>u.IdPersonalSalud)
                .IsRequired(false);
    }   
}