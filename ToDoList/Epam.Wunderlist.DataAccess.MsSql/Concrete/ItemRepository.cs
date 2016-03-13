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

        //public override bool Update(DalItem entity)
        //{
        //    //return base.Update(entity);
        //    Item modelEntity = mapper.Map<DalItem, Item>(entity);
        //    var x = context.Set<Item>().Find(modelEntity.Id);
        //    if (x == null)
        //        return false;
        //    //context.Entry(x).CurrentValues.SetValues(modelEntity);
        //    x.IsCompleted = entity.IsCompleted;
        //    return true;
        //}
    }
}
