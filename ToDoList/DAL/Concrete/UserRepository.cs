using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Data.Entity;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class UserRepository:IUserRepository
    {

        private readonly DbContext context;
        public UserRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(DalUser user)
        {
            context.Set<User>().Add(user.ToOrmUser());
        }

        public DalUser GetByEmail(string email)
        {
            return context.Set<User>().FirstOrDefault(user=>user.Email==email)?.ToDalUser();
        }
    }
}
