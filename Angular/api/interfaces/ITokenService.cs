using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models;

namespace Angular.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}