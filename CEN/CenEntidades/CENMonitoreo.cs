using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades;
public class CENMonitoreo
{
    //PROPIEDADES
    public ushort Id{get;set;}
    public ushort IdCita{get;set;}
    public CENCita? Cita{get;set;}
    public DateTime FechaMonitoreo{get;set;}
    public ushort Proceso{get;set;} //virtual-0 | presencial-1
    public ushort Tipo{get;set;} //control-0 | consulta-1

    //RELACION: Un Monitoreo puede tener un diagnostico
    public CENDiagnostico? Diagnostico{get;set;}
    //RELACION: Un monitoreo genera un datoBiometrico de cada cita
    public CENDatosBiometricos? DatosBiometricos{get;set;}
}