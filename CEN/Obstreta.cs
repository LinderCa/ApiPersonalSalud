
namespace ApiPersonalSalud.CEN;
//ABSTRACCION EN LA FORMA DE IMPLEMENTACION
public class Obstreta : PersonalSalud
{
    private int _cantidadPacientes;
    public int CantidadPacientes{
        get{
            return this._cantidadPacientes;            
        }
        set{
            this._cantidadPacientes=value;
        }
    }
}
