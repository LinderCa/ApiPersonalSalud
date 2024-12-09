using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;
public class CENDatosBiometricos
{
    public ushort Id{get;set;}
    public ushort IdMonitoreo{get;set;}
    public CENMonitoreo? Monitoreo{get;set;}
    public float Peso{get;set;}
    public ushort PresionArterial{get;set;}
    public ushort FrecuenciaCardiaca{get;set;}
    public short Temperatura{get;set;}
}