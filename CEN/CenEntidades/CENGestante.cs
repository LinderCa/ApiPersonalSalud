using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [RegularExpression(@"^\d{8}$", ErrorMessage ="El DNI solo debe contener 8 digitos numericos")]
        public string? DNI{get;set;}
        public DateTime FechaNacimiento{get;set;}
        public string? Direccion{get;set;}
        public string? Telefono{get;set;}
        public string? Correo{get;set;} 
        public ushort EdadGestacional{get;set;}
        public GrupoSanguineo GrupoSanguineo{get;set;} //A+ O- AB+
    }
}