using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAll();
        RoleEntity GetByRoleName(string roleName);
        RoleEntity GetById(int id);
    }
}
