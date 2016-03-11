using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class RoleRepository : RoleRepositoryBase
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().ToArray().Select(role=>mapper.Map<Role,DalRole>(role));
        }
    }
}
