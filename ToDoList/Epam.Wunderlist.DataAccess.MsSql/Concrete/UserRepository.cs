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
        public UserRepository(DbContext dbContext):base(dbContext)
        {
            this.context = dbContext;
        }

        public override DalUser GetByEmail(string email)
        {
            return mapper.Map<User,DalUser>(context.Set<User>().FirstOrDefault(user=>user.Email==email));
        }
    }
}
