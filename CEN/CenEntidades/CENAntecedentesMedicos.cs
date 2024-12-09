using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;

public enum EnumTipo{
    Personal=0,
    Familiar=1,
    Obstetrico=2,
}

public enum EnumMotivo{
    AntecedentesObstetricos=0,
    CondicionesCronicas=1,
    EnfermedadesInfecciosas=2,
    HistorialMedicacion=3,
}
public class CENAntecedentesMedicos
{
    public ushort Id{get;set;}
    public ushort IdGestante{get;set;}
    public CENGestante? Gestante{get;set;}
    public DateTime FechaRegistro{get;set;}
    public EnumTipo Tipo{get;set;}
    public EnumMotivo Motivo{get;set;}
    public string? Descripcion{get;set;}
}