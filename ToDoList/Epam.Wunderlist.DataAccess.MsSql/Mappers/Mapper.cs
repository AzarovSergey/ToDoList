using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using System.Drawing;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;
using Nelibur.ObjectMapper;

namespace Epam.Wunderlist.DataAccess.MsSql.Mappers
{
    public class Mapper : IMapper
    {
        static Mapper()
        {
            TinyMapper.Bind<Role, DalRole>();
            TinyMapper.Bind<User, DalUser>();
            TinyMapper.Bind<Folder, DalFolder>();
            TinyMapper.Bind<ToDoList, DalToDoList>();
            TinyMapper.Bind<Item, DalItem>();
        }

        public TTarget Map<TSource, TTarget>(TSource entity)
        {
            if (entity == null)
                return default(TTarget);
            return TinyMapper.Map<TTarget>(entity);
        }
    }
}
