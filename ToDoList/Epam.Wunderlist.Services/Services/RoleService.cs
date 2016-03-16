using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Interface.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.Services.Services
{
    public class RoleService : RoleServiceBase
    {
        public RoleService(RoleRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {

        }

        public override IEnumerable<RoleEntity> GetAll()
        {
            return repository.GetAll().Select(role => mapper.Map<DalRole, RoleEntity>(role));
        }

        public override RoleEntity GetByRoleName(string roleName)
        {
            return mapper.Map<DalRole,RoleEntity>(repository.GetAll().FirstOrDefault(role => role.Name == roleName));
        }
    }
}
