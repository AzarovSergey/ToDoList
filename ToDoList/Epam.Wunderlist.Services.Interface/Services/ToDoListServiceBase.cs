using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public abstract class ToDoListServiceBase: Service<ToDoListEntity, ToDoListRepositoryBase, DalToDoList>
    {
        public ToDoListServiceBase(ToDoListRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            :base(repository,unitOfWork,mapper)
        {

        }

        public abstract IEnumerable<ToDoListEntity> GetByFolderId(int folderId);
    }
}
