using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenEntidades
{
    public class CENConsulta
    {
        public ushort Id{get;set;}
        public ushort IdCita{get;set;}
        public CENCita? Cita{get;set;}
        public string? Descripcion{get;set;}
        public string? Resultados{get;set;}
    }
}