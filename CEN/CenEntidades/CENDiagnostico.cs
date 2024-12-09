using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;
public class CENDiagnostico
{
    public ushort Id{get;set;}
    public ushort IdMonitoreo{get;set;}
    public CENMonitoreo? Monitoreo{get;set;}
    public string? Sintomas{get;set;}
    public ushort EstadoFetal{get;set;} //normal-0 | alto_riesgo:1
    public string? Recomendacion{get;set;}
    public ushort Estado{get;set;}  //seguimiento-0 | resuelto-1
}