using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CLN.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiPersonalSalud.Controllers;
//DECORADORES
[ApiController]
[Route("[controller]")] 
//Un controlador es una clase que toma dependencias siguiendo un patron de POO
public class ControllerGestantes : ControllerBase
{
    private ICLNGestante _clnGestante;
    //Inyeccion de dependencia por medio del constructor
    public ControllerGestantes(ICLNGestante implementacion){
        this._clnGestante=implementacion;
    }

    //metodo get-Obtener todas las gestantes
    [HttpGet]
    public async Task<IActionResult> GetGestantes(){
        try{
            var respuesta= await this._clnGestante.GetGestantes();
            if(respuesta.Codigo==1) 
                return Ok(respuesta);
            return BadRequest(respuesta);
        }catch(Exception ex){
            return StatusCode(500, new {message= "Ocurrio un error interno en el servidor"+ex.Message});
        }
    }
}