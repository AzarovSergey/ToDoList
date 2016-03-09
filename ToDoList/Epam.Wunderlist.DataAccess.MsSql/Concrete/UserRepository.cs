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
    public class UserRepository : UserRepositoryBase
    {

        private readonly DbContext context;
        public UserRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public override DalUser GetByEmail(string email)
        {
            return context.Set<User>().FirstOrDefault(user=>user.Email==email)?.ToDalUser();
        }
    }
}
