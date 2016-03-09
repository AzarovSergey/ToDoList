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
    public class ToDoListRepository : ToDoListRepositoryBase
    {
        private readonly DbContext context;

        public ToDoListRepository(DbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }

        public override IEnumerable<DalToDoList> GetByFolderId(int folderid)
        {
            return context.Set<ToDoList>().Where(todolist => todolist.FolderId == folderid).ToArray().Select(todolist => todolist.ToDalToDoList());
        }
    }
}
