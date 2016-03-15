using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Ninject;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Interface.Services
{
     public abstract class UserServiceBase : Service<UserEntity, UserRepositoryBase, DalUser>
    {
        public UserServiceBase(UserRepositoryBase repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {

        }
        public abstract UserEntity GetByEmail(string email);

        public abstract byte[] GetPhoto(int userId);

        public abstract bool SetPhoto(int userId, byte[] image);
    }
}
