using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CAD.Interfaces;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonalSalud.CAD;
public class CADGestante : ICADGestante
{
    private readonly ApplicationDBContext _dbContext;

    public CADGestante(ApplicationDBContext implementacion){
        this._dbContext=implementacion;
    }
    public async Task<List<CENGestante>> GetGestantes(){
        try{
            var respuesta=await this._dbContext.Gestantes.ToListAsync();
            return respuesta;
        }catch(Exception ex){
            throw new InvalidOperationException("Ocurrio un error al obtener los datos de la Gestante" + ex);
        }
    }
}