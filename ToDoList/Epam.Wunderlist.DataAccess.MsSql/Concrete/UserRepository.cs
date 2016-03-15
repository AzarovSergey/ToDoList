using System;
using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class UserRepository : UserRepositoryBase
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override DalUser GetByEmail(string email)
        {
            return mapper.Map<User, DalUser>(context.Set<User>().FirstOrDefault(user => user.Email == email));
        }

        public override byte[] GetPhoto(int userId)
        {
            User user = context.Set<User>().Find(userId);
            if (user == null)
                return null;
            Photo photo = context.Set<Photo>().Find(user.PhotoId);
            if (photo == null)
                return null;
            return (byte[])photo.Image.Clone();
        }

        public override bool SetPhoto(int userId, byte[] image)
        {
            User user = context.Set<User>().Find(userId);
            if (user == null)
                return false;
            Photo photo =  context.Set<Photo>().Find(user.PhotoId);
            if (photo == null)
            {
                photo = context.Set<Photo>().Add(new Photo() { Image = image });
            }
            else
            {
                photo.Image = image;
            }
            context.SaveChanges();
            user.PhotoId = photo.Id;
            context.SaveChanges();
            return true;
        }
    }
}
