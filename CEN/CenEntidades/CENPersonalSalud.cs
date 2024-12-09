using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;
public class CENPersonalSalud
{
    //Propiedades
    public ushort Id{get;set;}
    public string? Nombres{get;set;}
    public string? Apellidos{get;set;}
    public char Especialidad{get;set;} //Medico General -M | Enfermera-E | Obstetra-O
    public bool Estado{get;set;} //ACTIVO - 0 | INACTIVO - 1


    //UNO A MUCHOS: Un personal de Salud tiene muchas citas
    public ICollection<CENCita>? Citas{get;set;}
}