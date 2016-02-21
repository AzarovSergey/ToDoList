using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        void Create(UserEntity user);
        UserEntity GetByEmail(string email);
    }
}
