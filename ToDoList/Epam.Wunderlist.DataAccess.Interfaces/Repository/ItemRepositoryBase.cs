using System.Collections.Generic;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class ItemRepositoryBase : BaseRepository<DalItem, Item>
    {
        public abstract IEnumerable<DalItem> GetByToDoListId(int todolistid);

        protected ItemRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
