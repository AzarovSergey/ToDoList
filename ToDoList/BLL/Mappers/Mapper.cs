using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class Mapper
    {
        public static RoleEntity ToBllRole(this DalRole role)
        {
            return new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public static DalUser ToDalUser(this UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return new DalUser()
            {
                Email = user.Email,
                IsEmailNotification = user.IsEmailNotification,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo,
                RoleId = user.RoleId,
                ThemeId = user.ThemeId,
            };
        }
        public static UserEntity ToBllUser(this DalUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return new UserEntity()
            {
                Email = user.Email,
                IsEmailNotification = user.IsEmailNotification,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo,
                RoleId = user.RoleId,
                ThemeId = user.ThemeId,
            };
        }

        public static FolderEntity ToBllFolder(this DalFolder folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder));
            return new FolderEntity()
            {
                AuthorId = folder.AuthorId,
                Id = folder.Id,
                Name = folder.Name,
                OrdreIndex = folder.OrderIndex,
            };
        }
        public static ItemEntity ToBllItem(this DalItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return new ItemEntity()
            {
                CompletionDateTime = item.CompletionDateTime,
                CreationDateTime = item.CreationDateTime,
                Description = item.Description,
                ExecutorId = item.ExecutorId,
                Id = item.Id,
                Intrerval = item.Interval,
                IsComleted = item.IsCompleted,
                IsStarred = item.IsStarred,
                Name = item.Name,
                OrderIndex = item.OrderIndex,
                RemindDateTime = item.RemindDateTime,
                RepeatKindId = item.RepeatKindId,
                ToDoListId = item.ToDoListId,
            };
        }
        public static ToDoListEntity ToBllToDoList(this DalToDoList toDoList)
        {
            if (toDoList == null)
                throw new ArgumentNullException(nameof(toDoList));
            return new ToDoListEntity()
            {
                Id=toDoList.Id,
                Name=toDoList.Name,
            };
        }
    }
}
