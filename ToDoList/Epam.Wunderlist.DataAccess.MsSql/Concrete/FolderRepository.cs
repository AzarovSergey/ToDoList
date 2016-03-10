using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.MsSql.Mappers;

namespace Epam.Wunderlist.DataAccess.MsSql.Concrete
{
    public class FolderRepository : FolderRepositoryBase
    {
        private readonly DbContext context;

        public FolderRepository(DbContext dbContext) :base(dbContext)
        {
            this.context = dbContext;
        }

        public override IEnumerable<DalFolder> GetByAuthorId(int authorid)
        {
            return context.Set<Folder>().Where(folder => folder.UserId == authorid).ToArray().Select(folder => mapper.Map<Folder,DalFolder>(folder));
        }
    }
}
