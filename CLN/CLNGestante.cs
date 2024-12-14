using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CAD.Interfaces;
using ApiPersonalSalud.CEN.CenResponse;
using ApiPersonalSalud.CLN.Interfaces;
using ApiPersonalSalud.CLN.Responses;

namespace ApiPersonalSalud.CLN
{
    public class CLNGestante : ICLNGestante
    {
        //Inyeccion de dependencia
        private readonly ICADGestante _cadGestante;
        public CLNGestante(ICADGestante implementacion){
            this._cadGestante=implementacion;
        }
        public async Task<Response> GetGestantes(){
            try{
                var respuesta=await this._cadGestante.GetGestantes();
                //Si la respuesta es nula entonces la lista esta vacia
                if(respuesta == null )
                {
                    return new CLNResponse().ResponseError("No se encontraron datos de gestantes");
                }
                return new CLNResponse().ResponseSuccesfull(respuesta,201);
            }catch(Exception ex){
                throw ;
            }
        }
    }
}