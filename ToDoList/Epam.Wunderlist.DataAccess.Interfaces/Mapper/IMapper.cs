using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.DataAccess.Interfaces.Mapper
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource entity);
    }

}