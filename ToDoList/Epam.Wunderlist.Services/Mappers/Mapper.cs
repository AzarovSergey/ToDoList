using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Services.Mappers
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
                UserId = folder.UserId,
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
                CompletionDateTime = item.DueDateTime,
                Note = item.Note,
                ExecutorId = item.ExecutorId,
                Id = item.Id,
                IsComleted = item.IsCompleted,
                IsStarred = item.IsStarred,
                Name = item.Name,
                OrderIndex = item.OrderIndex,
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
