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
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly DbContext context;

        public ToDoListRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<DalToDoList> GetByFolderId(int folderid)
        {
            var ListsId = context.Set<ToDoListFolder>().Where(x => x.FolderId == folderid).ToArray().Select(x => x.ToDoListId);
            return context.Set<ToDoList>().Where(todolist => ListsId.Contains(todolist.Id)).ToArray().Select(todolist => todolist.ToDalToDoList());
        }
    }
}
