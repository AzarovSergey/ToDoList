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

        public override Image GetPhoto(int key)
        {         
            var tempUser = mapper.Map<User, DalUser>(context.Set<User>().FirstOrDefault(user => user.Id == key));
            return ByteArrayToImage(mapper.Map<Photo, DalPhoto>(context.Set<Photo>().FirstOrDefault(photo => photo.Id == tempUser.PhotoId)));
        }

        public override bool SetPhoto(int key, Image image)
        {
            var tempUser = mapper.Map<User, DalUser>(context.Set<User>().FirstOrDefault(user => user.Id == key));
            var tempPhoto = mapper.Map<Photo, DalPhoto>(context.Set<Photo>().FirstOrDefault(photo => photo.Id == tempUser.PhotoId));
            if (tempPhoto == null)
                return false;
            tempPhoto.Image = ImageToByteArray(image);
            context.Entry(tempPhoto).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public override byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public override Image ByteArrayToImage(DalPhoto photo)
        {
            MemoryStream ms = new MemoryStream(photo.Image);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
