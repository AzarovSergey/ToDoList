using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Data.Entity;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
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
            return context.Set<Role>().Select(role=>role.ToDalRole());
        }
    }
}
