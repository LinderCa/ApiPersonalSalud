using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenResponse;

namespace ApiPersonalSalud.CLN.Responses;
public class CLNResponse
{   
    public Response ResponseSuccesfull(Object obj,int estado){
        return new Response(){
            Codigo=1, //EXITOSO=1
            Data=obj,
            Mensaje=$"Proceso Exitoso {estado}"
        };
    }

    public Response ResponseError(string msj){
        return new Response(){
            Codigo=0,
            Mensaje=msj,
            Data=null,
        };
    }
}