using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Epam.Wunderlist.Services.Interface.Services;


namespace Epam.Wunderlist.Web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public UserServiceBase UserService = (UserServiceBase)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserServiceBase));

        public RoleServiceBase RoleService = (RoleServiceBase)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleServiceBase));

        public override bool IsUserInRole(string email, string roleName)
        {
            //var user = UserService.GetAll().FirstOrDefault(u => u.Login == email);
            var user = UserService.GetByEmail(email);

            if (user == null) return false;

            var userRole = RoleService.GetById(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;

            //throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string email)
        {
            //var roles = new string[] { };
            //var user = UserService.GetByLogin(email);

            //if (user == null) return roles;

            //var userRole = user.RoleId;

            //if (userRole != 0)
            //{
            //    roles = new string[] { RoleService.GetById(userRole).Name };
            //}
            //return roles;

            throw new NotImplementedException();
        }

        #region stabs
        public override void CreateRole(string roleName)
        {
            throw new Exception();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
        #endregion
        
    }
}