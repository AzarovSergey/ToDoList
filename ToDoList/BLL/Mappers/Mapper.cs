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
                EmailNotification = user.EmailNotification,
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
                EmailNotification = user.EmailNotification,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo,
                RoleId = user.RoleId,
                ThemeId = user.ThemeId,
            };
        }
    }
}
