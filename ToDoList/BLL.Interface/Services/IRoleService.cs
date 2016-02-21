using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAll();
        RoleEntity GetByRoleName(string roleName);
        RoleEntity GetById(int id);
    }
}
