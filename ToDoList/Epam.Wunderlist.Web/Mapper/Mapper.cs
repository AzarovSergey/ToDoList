using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nelibur.ObjectMapper;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Web.Models;

namespace Epam.Wunderlist.Web.Mapper
{
    public class Mapper:IMapper
    {
        static Mapper()
        {
            TinyMapper.Bind<FolderEntity, FolderModel>();
            TinyMapper.Bind<ToDoListEntity, ToDoListModel>();
            TinyMapper.Bind<ItemEntity, ItemModel>();
        }

        public TTarget Map<TSource, TTarget>(TSource entity)
        {
            return TinyMapper.Map<TTarget>(entity);
        }
    }
}