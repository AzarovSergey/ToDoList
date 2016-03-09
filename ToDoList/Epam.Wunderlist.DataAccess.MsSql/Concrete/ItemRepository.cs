using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.MsSql.Mappers;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class ItemRepository : ItemRepositoryBase
    {
        private readonly DbContext context;

        public ItemRepository(DbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }

        public override IEnumerable<DalItem> GetByToDoListId(int todolistid)
        {
            return context.Set<Item>().Where(item => item.ToDoListId == todolistid).ToArray().Select(item=>item.ToDalItem());
        }
    }
}
