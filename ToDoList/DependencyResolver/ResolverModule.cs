using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<UnitOfWork>();

            //Bind<DbContext>().To<EntityModel>().InSingletonScope();
            //Bind<IUserRepository>().To<UserRepository>();
            //Bind<IUserService>().To<UserService>();
            //Bind<IRoleService>().To<RoleService>();
            //Bind<ITagService>().To<TagService>();
            //Bind<ICommentService>().To<CommentService>();

            //Bind<IArticleRepository>().To<ArticleRepository>();
            //Bind<IArticleService>().To<ArticleService>();
            //Bind<IRoleRepository>().To<RoleRepository>();
            //Bind<ITagRepository>().To<TagRepository>();
            //Bind<ICommentRepository>().To<CommentRepository>();

        }
    }
}
