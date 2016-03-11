using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class ToDoListRepository : ToDoListRepositoryBase
    {

        public ToDoListRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<DalToDoList> GetByFolderId(int folderid)
        {
            return context.Set<ToDoList>().Where(todolist => todolist.FolderId == folderid).ToArray().Select(todolist => mapper.Map<ToDoList,DalToDoList>(todolist));
        }
    }
}
