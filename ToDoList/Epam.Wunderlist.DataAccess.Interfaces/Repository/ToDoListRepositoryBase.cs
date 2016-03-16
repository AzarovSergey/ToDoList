using System.Collections.Generic;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class ToDoListRepositoryBase : BaseRepository<DalToDoList, ToDoList>
    {
        public abstract IEnumerable<DalToDoList> GetByFolderId(int folderid);

        protected ToDoListRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
