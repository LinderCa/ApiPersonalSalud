using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
//Extraemos toda la configuracion de la Clase Gestante para reducir Tamaño en ModelCreating
public class CMGestante : IEntityTypeConfiguration<CENGestante>
{
    public void Configure(EntityTypeBuilder<CENGestante> builder)
    {
        //cONFIGURACION
        builder.HasKey(g => g.Id);
            //**Configuracion para el campo Nombre
        builder.Property(g => g.Nombres)
                .IsRequired() //NOT NULL
                .HasMaxLength(150); //LONGITUD MAXIMA DE CARACTERES
        builder.Property(g => g.Apellidos)
                .IsRequired()
                .HasMaxLength(150);
                
            //**Configuracion de DNI: Solo nuemricos
        builder.Property(g=>g.DNI)
                .IsRequired()
                .HasMaxLength(8);

        builder.Property(g=>g.FechaNacimiento)
                .IsRequired() //NOT NULL

    }
}
