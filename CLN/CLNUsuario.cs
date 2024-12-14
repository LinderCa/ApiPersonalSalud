using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CAD.Interfaces;
using ApiPersonalSalud.CEN.CenRequest;
using ApiPersonalSalud.CEN.CenResponse;
using ApiPersonalSalud.CLN.Interfaces;
using ApiPersonalSalud.CLN.Responses;

namespace ApiPersonalSalud.CLN;
public class CLNUsuario:ICLNUsuario
{
    //Inyeccion de dependencia
    private readonly ICADUsuario _cadUsuario;
    public CLNUsuario(ICADUsuario implementacion){
        this._cadUsuario=implementacion;
    }

    public async Task<Response> ValidarUser(RequestUser cred){
        try{
            var respuesta= await this._cadUsuario.GetUserCredenciales(cred.User,cred.Password);
            if(respuesta==null)
                return new CLNResponse().ResponseError("No existe data en la BD");
            return new CLNResponse().ResponseSuccesfull(respuesta,201);
        }catch(Exception ex){
            throw;
        }
    }
}