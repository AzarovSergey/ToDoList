using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class ItemRepository : ItemRepositoryBase
    {
        public ItemRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<DalItem> GetByToDoListId(int todolistid)
        {
            return context.Set<Item>().Where(item => item.ToDoListId == todolistid).ToArray().Select(item=>mapper.Map<Item,DalItem>(item));
        }
    }
}
