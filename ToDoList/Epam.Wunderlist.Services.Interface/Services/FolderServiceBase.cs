using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public abstract class FolderServiceBase:Service<FolderEntity, FolderRepositoryBase ,DalFolder>
    {
        public abstract IEnumerable<FolderEntity> GetByAuthorId(int authorId);
    }
}
