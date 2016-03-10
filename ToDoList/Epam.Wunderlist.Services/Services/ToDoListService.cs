using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Mappers;
using Epam.Wunderlist.Services.Interface.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoListService : ToDoListServiceBase
    {
        public ToDoListService(ToDoListRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            :base(repository,unitOfWork,mapper)
        {

        }

        public override IEnumerable<ToDoListEntity> GetByFolderId(int folderId)
        {
            return repository.GetByFolderId(folderId).Select(toDoList => mapper.Map<DalToDoList,ToDoListEntity>(toDoList));
        }

    }
}
