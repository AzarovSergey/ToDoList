using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Interface.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using System;
using System.Drawing;

namespace Epam.Wunderlist.Services.Services
{
    public class UserService : UserServiceBase
    {
        public UserService(UserRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            :base(repository,unitOfWork,mapper)
        {

        }

        public override UserEntity GetByEmail(string email)
        {
            return mapper.Map<DalUser,UserEntity>(repository.GetByEmail(email));
        }

        public override Image GetPhoto(int key)
        {
            return repository.GetPhoto(key);
        }

        public override bool SetPhoto(int key, Image image)
        {
            repository.SetPhoto(key, image);
            return true;
        }
    }
}
