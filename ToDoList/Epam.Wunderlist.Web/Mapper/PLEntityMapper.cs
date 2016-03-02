using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using BLL.Interface.Entities;
//using Epam.Wunderlist.Web.ViewModels;
//using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Web.Mapper
{
    public static class PLEntityMapper
    {
       public static FolderModel ToFolderModel(this FolderEntity folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder));
            return new FolderModel()
            {
                Name = folder.Name,
                OrderIndex=folder.OrdreIndex,
                ToDoLists=null,
            };
        }

        public static ItemModel ToItemModel(this ItemEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return new ItemModel()
            {
                CompletionDateTime = item.CompletionDateTime,
                CreationDateTime = item.CreationDateTime,
                Description = item.Description,
                Intrerval = item.Intrerval,
                IsComleted = item.IsComleted,
                IsStarred = item.IsStarred,
                Name = item.Name,
                OrderIndex = item.OrderIndex,
                RemindDateTime = item.RemindDateTime,
                RepeatKindId = item.RepeatKindId,
            };
        }

        public static ToDoListModel ToToDoListModel(this ToDoListEntity list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            return new ToDoListModel()
            {
                Items = null,
                Name = list.Name,
            };
        }
    }
}