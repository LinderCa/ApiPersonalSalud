using System.ComponentModel.DataAnnotations;

namespace ApiPersonalSalud.CEN.CenEntidades;

//ENUMERACIONES 
public enum MotivoCita{
    Control=0,
    Consulta=1,
    SeguimientoComplicaciones=2
}

public enum EstadoCita{
    Programada=0,
    Completada=1,
    SeguimientoComplicaciones=2,
}

public class CENCita
{
    public ushort Id{get;set;}
    //CREACION DE INDICES EXTERNOS (FK)
    public ushort IdGestante{get;set;}
    public CENGestante? Gestante{get;set;}
    public ushort IdPersonalSalud{get;set;}
    public CENPersonalSalud? PersonalSalud{get;set;}
    public DateTime FechaCita{get;set;}
    public TimeSpan HoraCita{get;set;}       
    [EnumDataType(typeof(MotivoCita),ErrorMessage="El motivo de cita no es valido(0-Control | 1-Consulta | 2-Seguimiento)")]
    public MotivoCita Motivo{get;set;} //0-Control | 1-Consulta | 2-Seguimiento de Complicaciones

    [EnumDataType(typeof(EstadoCita),ErrorMessage ="El estado de cita no es valido(0-Programada 1-Completada 2-Seguimiento de complicaciones)")]
    public EstadoCita Estado{get;set;} //0-Programada | 1-Completada | 2-Cancelada

    //Entidad de RElacion de que una Cita puede tener un monitoreo
    public CENMonitoreo? Monitoreo{get;set;}
}