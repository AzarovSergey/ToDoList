using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class RoleRepositoryBase : BaseRepository<DalRole, Role>
    {
        public abstract IEnumerable<DalRole> GetAll();

        protected RoleRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
