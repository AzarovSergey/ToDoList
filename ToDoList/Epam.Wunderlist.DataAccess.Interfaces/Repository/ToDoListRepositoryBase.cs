using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class ToDoListRepositoryBase : BaseRepository<DalToDoList, ToDoList, IMapper<ToDoList, DalToDoList>>
    {
        public abstract IEnumerable<DalToDoList> GetByFolderId(int folderid);
    }
}
