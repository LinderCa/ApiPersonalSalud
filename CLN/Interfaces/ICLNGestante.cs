using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenResponse;
using ApiPersonalSalud.CLN.Responses;

namespace ApiPersonalSalud.CLN.Interfaces;
public interface ICLNGestante
{
    public Task<Response> GetGestantes();
}