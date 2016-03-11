using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Interface.Mappers;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

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
    }
}
