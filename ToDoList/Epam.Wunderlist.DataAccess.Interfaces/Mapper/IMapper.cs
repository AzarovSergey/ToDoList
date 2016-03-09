using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.DataAccess.Interfaces.Mapper
{
    public interface IMapper<TOrmEntity, TDalEntity>
        where TOrmEntity : Orm.IEntity
        where TDalEntity : DTO.IEntity
    {
        TOrmEntity ToOrm(TDalEntity dal);
        TDalEntity ToDal(TOrmEntity orm);
    }

}