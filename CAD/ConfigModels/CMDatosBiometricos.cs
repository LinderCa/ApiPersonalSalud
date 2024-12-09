using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels
{
    public class CMDatosBiometricos : IEntityTypeConfiguration<CENDatosBiometricos>
    {
        public void Configure(EntityTypeBuilder<CENDatosBiometricos> builder){
            builder.ToTable("DatosBiometricos");
            builder.HasKey(b=>b.Id);
        }
    }
}