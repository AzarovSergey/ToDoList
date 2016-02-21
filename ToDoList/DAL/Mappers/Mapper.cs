using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DAL.Interface.DTO;
using System.Drawing;

namespace DAL.Mappers
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
                EmailNotification = user.EmailNotification,
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
                EmailNotification = user.EmailNotification,
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
    }
}
