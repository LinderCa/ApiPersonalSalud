using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
public class CMAntecedentesMedicos: IEntityTypeConfiguration<CENAntecedentesMedicos>
{
    public void Configure(EntityTypeBuilder<CENAntecedentesMedicos> builder)
    {
        builder.ToTable("AntecedentesMedicos");
        builder.HasKey(a=>a.Id);

        //RELACION DE QUE UN ANTECEDENTE MEDICO LE CORRESPONDE A UNA GESTANTE
        builder.HasOne(a=>a.Gestante)
                .WithMany(g=>g.AntecedentesMedicos)
                .HasForeignKey(a=>a.IdGestante)
                .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(t=>{
            t.HasCheckConstraint("CHK_CENAntecedentesMedicos_Tipo","Tipo BETWEEN 0 AND 2");
            t.HasCheckConstraint("CHK_CenAntecedentesMedicos_Motivo","Motivo BETWEEN 0 AND 3");
        });

        builder.Property(a=>a.Tipo)
                .IsRequired();
        builder.Property(a=>a.Motivo)
                .IsRequired();
        builder.Property(a=>a.Descripcion)
                .IsRequired();

    }
}