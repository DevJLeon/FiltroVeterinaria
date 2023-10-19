using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Helpers;
public class Authorization
{
    public enum Roles
    {
        Administrator,
        Personal,
        Medico,
    }
    public const Roles rol_default = Roles.Personal;
}