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
    //Constructor
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options){
    }

    //Propiedad de DbSet
    public DbSet<CENGestante> Gestantes{get;set;}
    public DbSet<CENPersonalSalud> PersonalSalud{get;set;}
    public DbSet<CENUsuario> Usuarios{get;set;}

    //definimos las propiedades para el mapeo con la base de datos
    #region ConfiguracionRequerida
    //CONFIGURACION PERSONALIZADA PARA EL OBJETO DE CONTEXTO
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //Instanciamos la configuracion para la Gestante
        new CMGestante().Configure(modelBuilder.Entity<CENGestante>());
        //Instanciamos la configuracion el personal de salud
        new CMPersonalSalud().Configure(modelBuilder.Entity<CENPersonalSalud>());
        new CMUsuario().Configure(modelBuilder.Entity<CENUsuario>());
        new CMCita().Configure(modelBuilder.Entity<CENCita>());
        new CMMonitoreo().Configure(modelBuilder.Entity<CENMonitoreo>());
        new CMConsulta().Configure(modelBuilder.Entity<CENConsulta>());
        new CMDiagnostico().Configure(modelBuilder.Entity<CENDiagnostico>());
        new CMDatosBiometricos().Configure(modelBuilder.Entity<CENDatosBiometricos>());
        new CMAntecedentesMedicos().Configure(modelBuilder.Entity<CENAntecedentesMedicos>());
    }
    #endregion
}