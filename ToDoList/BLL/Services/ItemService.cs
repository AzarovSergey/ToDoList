using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork uow;
        private readonly IItemRepository itemRepository;

        public ItemService(IUnitOfWork uow, IItemRepository repository)
        {
            this.uow = uow;
            this.itemRepository = repository;
        }


        public IEnumerable<ItemEntity> GetByToDoListId(int toDoListId)
        {
            return itemRepository.GetByToDoListId(toDoListId).Select(item => item.ToBllItem());
        }
    }
}
