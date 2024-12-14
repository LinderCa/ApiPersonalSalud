using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonalSalud.CEN.CenResponse;

public class Response
{
    public Object? Data{get;set;}
    public int Codigo{get;set;}
    public string? Mensaje{get;set;}
}
