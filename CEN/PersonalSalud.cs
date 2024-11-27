namespace ApiPersonalSalud.CEN;
//ASBTRACCION, FIJANDONOS EN DETALLES ESENCIALES , PROPIEDADES Y COMPORTAMIENTOS IMPORTANTES
public abstract class PersonalSalud
{
    public string? Nombres{get;set;}
    public string? Apellidos{get;set;}
    public char Tipo{get;set;} //O-Obstetra E-Enfermera
    public bool Estado{get;set;}

    //CONSTRUCTOR
}