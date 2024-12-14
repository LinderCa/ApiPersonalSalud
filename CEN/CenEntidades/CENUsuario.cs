using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;

public enum RolUsuario{
    PersonalSalud=0,
    Gestante=1,
    Administrador=2,
    Visitante=3
}

public class CENUsuario
{
    public ushort Id{get;set;}
    //FOREANAS
    public ushort? IdGestante{get;set;}
    public CENGestante? Gestante{get;set;}
    public ushort? IdPersonalSalud{get;set;}
    public CENPersonalSalud? PersonalSalud{get;set;}
    public string? User{get;set;}
    public string? Password{get;set;}
    public RolUsuario Rol{get;set;} //Enumeracion
    public bool Estado{get;set;}    //Activo-1-true | Inactivo-0-false
    public DateTime FechaIngreso{get;set;}
}