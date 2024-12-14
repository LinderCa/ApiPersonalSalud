using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;

namespace ApiPersonalSalud.CAD.Interfaces;
public interface ICADUsuario
{
    public Task<CENUsuario> GetUserCredenciales(string? user, string? password);        
};