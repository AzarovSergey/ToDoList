using System.Collections.Generic;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class FolderRepositoryBase : BaseRepository<DalFolder, Folder>
    {
        public abstract IEnumerable<DalFolder> GetByAuthorId(int authorid);

        protected FolderRepositoryBase(DbContext context) : base(context)
        {
        }
    }
}
