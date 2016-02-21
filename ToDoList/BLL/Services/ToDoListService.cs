using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IUnitOfWork uow;
        //private readonly IToDoListRepository toDoListRepository;

        public ToDoListService(IUnitOfWork uow/*, IToDoListRepository repository*/)
        {
            this.uow = uow;
            //this.toDoListRepository = repository;
        }

        public IEnumerable<ToDoListEntity> GetByFolderId(int folderId)
        {
            throw new NotImplementedException();
        }
    }
}
