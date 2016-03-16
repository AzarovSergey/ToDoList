using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Ninject;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public abstract class RoleServiceBase : Service<RoleEntity, RoleRepositoryBase, DalRole>
    {
        public RoleServiceBase(RoleRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            :base(repository,unitOfWork,mapper)
        {

        }

        public abstract IEnumerable<RoleEntity> GetAll();
        public abstract RoleEntity GetByRoleName(string roleName);
    }
}
