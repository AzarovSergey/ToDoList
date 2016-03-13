using Ninject.Modules;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.MsSql.Concrete;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Services.Services;
using Ninject.Web.Common;

namespace Epam.Wunderlist.DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();

            //Bind<DbContext>().To<EntityModel>().InSingletonScope();
            //Bind<DbContext>().To<EntityModel>().I();
            Bind<DbContext>().To<EntityModel>().InRequestScope();

            Bind<RoleServiceBase>().To<RoleService>();
            Bind<UserServiceBase>().To<UserService>();
            Bind<FolderServiceBase>().To<FolderService>();
            Bind<ToDoListServiceBase>().To<ToDoListService>();
            Bind<ItemServiceBase>().To<ItemService>();

            Bind<RoleRepositoryBase>().To<RoleRepository>();
            Bind<UserRepositoryBase>().To<UserRepository>();
            Bind<FolderRepositoryBase>().To<FolderRepository>();
            Bind<ToDoListRepositoryBase>().To<ToDoListRepository>();
            Bind<ItemRepositoryBase>().To<ItemRepository>();

            Bind<Epam.Wunderlist.DataAccess.Interfaces.Mapper.IMapper>().To<Epam.Wunderlist.DataAccess.MsSql.Mappers.Mapper>();
            Bind<Epam.Wunderlist.Services.Interface.Mappers.IMapper>().To<Epam.Wunderlist.Services.Mappers.Mapper>();
        }
    }
}
