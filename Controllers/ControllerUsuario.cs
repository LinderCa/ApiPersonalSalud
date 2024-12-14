using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenRequest;
using ApiPersonalSalud.CEN.CenResponse;
using ApiPersonalSalud.CLN.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiPersonalSalud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerUsuario : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly ICLNUsuario _clnUsuario;

        public ControllerUsuario(ICLNUsuario implementacion){
            this._clnUsuario=implementacion;
        }
        //Atributo de metodo de accion 
        [HttpPost("login")]
        public async Task<IActionResult> PostUsuario([FromBody] RequestUser credenciales){
            //La validacion del modelo se hara automaticamente
            try{
                //Nos conectamos con el modelo logico
                var respuesta=await this._clnUsuario.ValidarUser(credenciales);
                if(respuesta.Codigo==1)
                    return Ok(respuesta);
                else
                    return BadRequest(respuesta);
            }catch(Exception ex){
                return StatusCode(500,new Response(){
                    Codigo=0,
                    Data=null,
                    Mensaje="Error en " + ex,
                });
            }
        }
    }
}