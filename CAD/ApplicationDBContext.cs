using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonalSalud.CAD;
//objeto de contexto de EFC
public class ApplicationDBContext : DbContext
{
    //definimos las propiedades para el mapeo con la base de datos
    #region ConfiguracionRequerida
    //CONFIGURACION PERSONALIZADA PARA EL OBJETO DE CONTEXTO
    protected override void OnModelCreating(ModelBuilder modelBuilder){
    }
    #endregion
}