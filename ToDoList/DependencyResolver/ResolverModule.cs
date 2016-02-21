using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject.Modules;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<DbContext>().To<EntityModel>().InSingletonScope();
            
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IFolderService>().To<FolderService>();
            Bind<IToDoListService>().To<ToDoListService>();
            Bind<IItemService>().To<ItemService>();

            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IToDoListRepository>().To<ToDoListRepository>();
            Bind<IFolderRepository>().To<FolderRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
        }
    }
}
