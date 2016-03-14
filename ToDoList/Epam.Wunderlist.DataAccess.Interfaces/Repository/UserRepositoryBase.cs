using System.Data.Entity;
using System.Drawing;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class UserRepositoryBase : BaseRepository<DalUser, User>
    {
        public abstract DalUser GetByEmail(string email);

        public abstract Image GetPhoto(int key);

        public abstract bool SetPhoto(int key, Image image);

        protected UserRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
