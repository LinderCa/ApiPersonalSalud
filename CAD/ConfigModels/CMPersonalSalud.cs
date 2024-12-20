using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
//CONFIGURACION DE AGRUPAMIENTO 
public class CMPersonalSalud : IEntityTypeConfiguration<CENPersonalSalud>
{
    public void Configure(EntityTypeBuilder<CENPersonalSalud> builder)
    {
        //CONFIGURAR EL NOMBRE DE MI TABLA
        builder.ToTable("PersonalSalud");

        //Configuracion de Id
        builder.HasKey(p=> p.Id);

        //Configuracion de Nombre
        builder.Property(p=>p.Nombres)
                .IsRequired()
                .HasMaxLength(100);

        //Configuracion de apellidos
        builder.Property(p=>p.Apellidos)
                .IsRequired()
                .HasMaxLength(100);
        
        //REalizamos una contracion o restriccion con constraint
        builder.ToTable(t=>{
            t.HasCheckConstraint(
                "CHK_CENPersonalSalud_Especialidad",
                "Especialidad IN ('M','E','O')");
        });

        builder.Property(p=>p.Estado)
                .IsRequired()
                .HasDefaultValue(false);

                //configuracion de relacion con citas
        builder.HasMany(p=>p.Citas)     //Una gestante puede tener muchas citas
                .WithOne(c=>c.PersonalSalud)   //Una cita puede tener un PS
                .HasForeignKey(c=>c.IdPersonalSalud)
                .OnDelete(DeleteBehavior.Cascade);

                //Configuracion de Un PS tiene un Usuario
        builder.HasOne(p=>p.Usuario)
                .WithOne(u=>u.PersonalSalud)
                .HasForeignKey<CENUsuario>(u=>u.IdPersonalSalud)
                .OnDelete(DeleteBehavior.Cascade);
    }
}