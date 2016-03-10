using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Web.Mapper
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource entity);
    }
}
