using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using System.Drawing;

namespace Epam.Wunderlist.DataAccess.MsSql.Mappers
{
    public static class Mapper
    {
        public static Image ConvertFromBytes(byte[] bytes)
        {
            return null;
        }
        public static byte[] ToByteArray(Image image)
        {
            return null;
        }

        public static User ToOrmUser(this DalUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return new User()
            {
                Email = user.Email,
                IsEmailNotification = user.IsEmailNotification,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                ThemeId = user.ThemeId,
                Photo=ToByteArray(user.Photo),
            };
        }
        public static DalUser ToDalUser(this User user)
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
                RoleId = user.RoleId,
                ThemeId = user.ThemeId,
                Photo = ConvertFromBytes(user.Photo),
            };
        }



        public static DalRole ToDalRole(this Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public static DalFolder ToDalFolder(this Folder folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder));
            return new DalFolder()
            {
                Id = folder.Id,
                Name = folder.Name,
                AuthorId = folder.AuthorId,
                OrderIndex = folder.OrderIndex
                
            };
        }

        public static DalToDoList ToDalToDoList(this ToDoList todolist)
        {
            if (todolist == null)
                throw new ArgumentNullException(nameof(todolist));
            return new DalToDoList()
            {
                Id = todolist.Id,
                Name = todolist.Name      
            };
        }

        public static DalItem ToDalItem(this Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return new DalItem()
            {
                Id = item.Id,
                Name = item.Name,
                ToDoListId = item.ToDoListId,
                CreationDateTime = item.CreationDateTime,
                RemindDateTime = item.RemindDateTime,
                CompletionDateTime = item.СompletionDateTime,
                RepeatKindId = item.RepeatKindId,
                Interval = item.Interval,
                IsStarred = item.IsStarred,
                OrderIndex = item.OrderIndex,
                ExecutorId = item.ExecutorId,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
