using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public abstract class FolderServiceBase:Service<FolderEntity,IFolderRepository>
    {
        public abstract IEnumerable<FolderEntity> GetByAuthorId(int authorId);
    }
}
