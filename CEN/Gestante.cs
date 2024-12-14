using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN;
public class Gestante
{
    public ushort Id{get;set;}
    public string? Nombres{get;set;}
    public string? Apellidos{get;set;}
    public string? DNI{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string? Direccion{get;set;}
    public string? Telefono{get;set;}
    public string? Correo{get;set;} 
    public ushort EdadGestacional{get;set;}
}