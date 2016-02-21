using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using BLL.Mappers;

namespace BLL.Services
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
