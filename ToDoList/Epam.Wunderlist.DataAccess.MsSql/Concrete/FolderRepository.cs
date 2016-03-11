using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class FolderRepository : FolderRepositoryBase
    {
        public FolderRepository(DbContext dbContext) :base(dbContext)
        {
        }

        public override IEnumerable<DalFolder> GetByAuthorId(int authorid)
        {
            return context.Set<Folder>().Where(folder => folder.UserId == authorid).ToArray().Select(folder => mapper.Map<Folder,DalFolder>(folder));
        }
    }
}
