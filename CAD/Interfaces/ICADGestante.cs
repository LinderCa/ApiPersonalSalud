using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN;
using ApiPersonalSalud.CEN.CenEntidades;

namespace ApiPersonalSalud.CAD.Interfaces
{
    public interface ICADGestante
    {
        public  Task<List<CENGestante>> GetGestantes();
    }
}