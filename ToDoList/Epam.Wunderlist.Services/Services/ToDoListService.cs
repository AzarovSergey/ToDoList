using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Mappers;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IUnitOfWork uow;
        private readonly IToDoListRepository toDoListRepository;

        public ToDoListService(IUnitOfWork uow, IToDoListRepository repository)
        {
            this.uow = uow;
            this.toDoListRepository = repository;
        }

        public IEnumerable<ToDoListEntity> GetByFolderId(int folderId)
        {
            return toDoListRepository.GetByFolderId(folderId).Select(toDoList=>toDoList.ToBllToDoList());
        }
    }
}
