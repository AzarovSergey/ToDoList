using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Services.Interface.Entities;
using Nelibur.ObjectMapper;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Mappers
{
    public class Mapper:IMapper
    {
        static Mapper()
        {
            TinyMapper.Bind<RoleEntity, DalRole>();
            TinyMapper.Bind<UserEntity, DalUser>();
            TinyMapper.Bind<FolderEntity, DalFolder>();
            TinyMapper.Bind<ToDoListEntity, DalToDoList>();
            TinyMapper.Bind<ItemEntity, DalItem>();
        }

        public TTarget Map<TSource, TTarget>(TSource entity)
        {
            return TinyMapper.Map<TTarget>(entity);
        }
    }
}
