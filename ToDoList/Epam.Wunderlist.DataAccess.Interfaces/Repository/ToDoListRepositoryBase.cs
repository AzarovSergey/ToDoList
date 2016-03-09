using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;
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
