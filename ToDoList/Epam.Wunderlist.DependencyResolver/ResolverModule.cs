using Ninject.Modules;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.MsSql.Concrete;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Services.Services;

namespace Epam.Wunderlist.DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<DbContext>().To<EntityModel>().InSingletonScope();
            
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<FolderServiceBase>().To<FolderService>();
            Bind<IToDoListService>().To<ToDoListService>();
            Bind<IItemService>().To<ItemService>();

        }
    }
}
