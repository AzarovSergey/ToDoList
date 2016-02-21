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
    public class RoleService:IRoleService
    {
        //private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            return roleRepository.GetAll().Select(role=>role.ToBllRole());
        }

        public RoleEntity GetById(int id)
        {
            return roleRepository.GetAll().FirstOrDefault(role => role.Id == id).ToBllRole();
        }

        public RoleEntity GetByRoleName(string roleName)
        {
            return roleRepository.GetAll().FirstOrDefault(role => role.Name == roleName)?.ToBllRole();
        }
    }
}
