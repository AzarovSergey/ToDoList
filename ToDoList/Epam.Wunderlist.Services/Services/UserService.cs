using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Mappers;

namespace Epam.Wunderlist.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }


        public void Create(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public UserEntity GetByEmail(string email)
        {
            return userRepository.GetByEmail(email)?.ToBllUser();
        }
    }
}
