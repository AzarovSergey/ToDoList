using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class UserRepositoryBase : BaseRepository<DalUser, User>
    {
        public abstract DalUser GetByEmail(string email);

        protected UserRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
