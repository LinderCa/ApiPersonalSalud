using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenRequest;
using ApiPersonalSalud.CEN.CenResponse;

namespace ApiPersonalSalud.CLN.Interfaces;
public interface ICLNUsuario
{
    public Task<Response> ValidarUser(RequestUser cred);
}