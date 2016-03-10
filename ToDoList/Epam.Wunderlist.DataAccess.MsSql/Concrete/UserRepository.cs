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
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class UserRepository : UserRepositoryBase
    {

        //private readonly DbContext context;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override DalUser GetByEmail(string email)
        {
            var x = context.Set<User>().FirstOrDefault(user => user.Email == email);
            var y= mapper.Map<User,DalUser>(x);
            return y;
        }
    }
}
