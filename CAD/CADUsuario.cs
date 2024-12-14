using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CAD.Interfaces;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonalSalud.CAD;
public class CADUsuario : ICADUsuario
{
    private ApplicationDBContext _dbContext;
    public CADUsuario(ApplicationDBContext implementacion){
        this._dbContext=implementacion;
    }
    public async Task<CENUsuario> GetUserCredenciales(string? user, string? password){
        try{
            return await this._dbContext.Usuarios.FirstOrDefaultAsync(u=>u.User==user && u.Password==password);
        }catch(Exception ex){
            throw new InvalidOperationException("Ocurrio un error en acceso a la BD " + ex);
        }
    }
}