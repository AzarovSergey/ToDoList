using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.MsSql.Mappers;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;
        public RoleRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().ToArray().Select(role=>role.ToDalRole());
        }
    }
}
