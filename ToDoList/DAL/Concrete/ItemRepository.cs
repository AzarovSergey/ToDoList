using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using System.Data.Entity;
using DAL.Interface.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class ItemRepository:IItemRepository
    {
        private readonly DbContext context;

        public ItemRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<DalItem> GetByToDoListId(int todolistid)
        {
            return context.Set<Item>().Where(item => item.ToDoListId == todolistid).ToArray().Select(item=>item.ToDalItem());
        }
    }
}
