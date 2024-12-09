using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMCita : IEntityTypeConfiguration<CENCita>
{
    public void Configure(EntityTypeBuilder<CENCita> builder)
    {
        builder.ToTable("Cita");

        builder.HasKey(c=>c.Id);

        //CONFIGURACION DE RELACION
        builder.HasOne(c=>c.Gestante) //Una cita tiene una sola gestante
                .WithMany()             //Una gestante puede tener muchas citas
                .HasForeignKey(c=>c.IdGestante) //Llave Foranea en CenCita
                .OnDelete(DeleteBehavior.Cascade); //Elimita las citas asociadas cuando se elimine un gestante
    
        //CONFIGURACION DE LA RELACION CON PERSONAL DE SALUD
        builder.HasOne(c=>c.PersonalSalud)      //Una Cita es atendido por un PS
                .WithMany()                 //Un PS puede tener muchas citas
                .HasForeignKey(c=>c.IdPersonalSalud)
                .OnDelete(DeleteBehavior.Cascade);

        //CONFIGURACION ATRAVES DE RESTRICCIONES Y CONSTRAINT
        builder.ToTable(t=>{
            //Configuracion para la Fecha de la cita
            t.HasCheckConstraint("CHK_CENCita_FechaCita","FechaCita >= GETDATE()");
            //Configuracion para la hora de la cita
            t.HasCheckConstraint("CHK_CENCita_HoraCita","HoraCita >= '08:00:00' AND HoraCita <= '15:00:00'");
            //Configuracion de Motivo de la cita
            t.HasCheckConstraint("CHK_CENCita_Motivo","Motivo BETWEEN 0 AND 2");
            //Configuracion del estado de Cita
            t.HasCheckConstraint("CHK_CENCita_Estado","Estado BETWEEN 0 AND 2");
        });

        builder.Property(c=>c.Motivo)
                .IsRequired();

        builder.Property(c=>c.Estado)
                .IsRequired();

        //RELACION PARA LA CITA
        builder.HasOne(c=>c.Monitoreo)  //Una cita tiene un solo monitoreo
                .WithOne(m=>m.Cita)     //Un monitoreo pertenece a una cita
                .HasForeignKey<CENMonitoreo>(m=>m.IdCita)       //La clave foranea esta en CENMonitoreo
                .OnDelete(DeleteBehavior.Cascade);
    }
}