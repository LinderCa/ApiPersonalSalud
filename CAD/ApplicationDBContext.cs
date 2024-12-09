using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CAD.ConfigModels;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonalSalud.CAD;
//objeto de contexto de EFC
public class ApplicationDBContext : DbContext
{
    //Propiedad de DbSet
    public DbSet<CENGestante> Gestantes;
    public DbSet<CENPersonalSalud> PersonalSalud;
    //definimos las propiedades para el mapeo con la base de datos
    #region ConfiguracionRequerida
    //CONFIGURACION PERSONALIZADA PARA EL OBJETO DE CONTEXTO
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //Instanciamos la configuracion para la Gestante
        new CMGestante().Configure(modelBuilder.Entity<CENGestante>());
        //Instanciamos la configuracion el personal de salud
        new CMPersonalSalud().Configure(modelBuilder.Entity<CENPersonalSalud>());
    }
    #endregion
}