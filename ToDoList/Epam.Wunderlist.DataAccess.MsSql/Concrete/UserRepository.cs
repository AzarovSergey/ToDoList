using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class UserRepository : UserRepositoryBase
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override DalUser GetByEmail(string email)
        {
            return mapper.Map<User, DalUser>(context.Set<User>().FirstOrDefault(user => user.Email == email));
        }
    }
}
