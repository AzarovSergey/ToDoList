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
