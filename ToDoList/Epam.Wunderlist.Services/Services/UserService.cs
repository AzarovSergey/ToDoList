using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Interface.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using System;
using System.Drawing;
using System.IO;

namespace Epam.Wunderlist.Services.Services
{
    public class UserService : UserServiceBase
    {
        public UserService(UserRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {

        }

        public override UserEntity GetByEmail(string email)
        {
            return mapper.Map<DalUser, UserEntity>(repository.GetByEmail(email));
        }

        public override byte[] GetPhoto(int userId)
        {
            return repository.GetPhoto(userId);
        }

        public override bool SetPhoto(int userId, byte[] image)
        {
            if (IsImage(image))
            {
                repository.SetPhoto(userId, image);
                return true;
            }
            return false;
        }
        
        private bool IsImage(byte[] image)
        {
            try
            {
                ByteArrayToImage(image);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        private Image ByteArrayToImage(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
