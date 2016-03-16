using Epam.Wunderlist.DependencyResolver;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.Wunderlist.Web.Mapper;
using Ninject.Web.Common;

namespace Epam.Wunderlist.Web.Infrastructure
{
    public class WebResolver: NinjectModule
    {
        public override void Load()
        {
            Bind<Epam.Wunderlist.Web.Mapper.IMapper>().To<Epam.Wunderlist.Web.Mapper.Mapper>().InRequestScope();
        }
    }
}