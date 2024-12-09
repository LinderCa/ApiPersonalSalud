
using System.ComponentModel.DataAnnotations;
using static ApiPersonalSalud.CAD.ConfigModels.CMGestante;

namespace ApiPersonalSalud.CEN.CenEntidades
{
    //Enumerable
    public enum GrupoSanguineo{
        A_Pos,
        A_Neg,
        B_Pos,
        B_Neg,
        AB_Pos,
        AB_Neg,
        O_Pos,
        O_Neg
    }
    public class CENGestante
    {
        //CONFIGURACION MEDIANTE ATRIBUTOS DE ASIGANCION
        public ushort Id{get;set;}
        public string? Nombres{get;set;}
        public string? Apellidos{get;set;}
        //DECORADOR
        [RegularExpression(@"^\d{8}$", ErrorMessage ="El DNI solo debe contener 8 digitos numericos")]
        public string? DNI{get;set;}
        //Restriccion de Validacion con propiedad de Atributo
        [ValidarFechaNacimiento]
        public DateTime FechaNacimiento{get;set;}
        public string? Direccion{get;set;}
        [RegularExpression(@"^\d{9}$",ErrorMessage ="El telefono debe contener 9 caracteres")]
        public string? Telefono{get;set;}
        [EmailAddress(ErrorMessage ="Ingrese un correo valido")]
        public string? Correo{get;set;} 
        public ushort EdadGestacional{get;set;}
        [EnumDataType(typeof(GrupoSanguineo),ErrorMessage="El grupo Sanguineono es valido")]
        public GrupoSanguineo GrupoSanguineo{get;set;} //A+ O- AB+

        //RELACION DE UNO A MUCHOS: Una Gestante puede adquirir muchas citas
        public ICollection<CENCita>? Citas;

        //Una Gestante tiene un usuario
        public CENUsuario? Usuario{get;set;}
    }
}