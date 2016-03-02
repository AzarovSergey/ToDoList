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
    public class FolderRepository : IFolderRepository
    {
        private readonly DbContext context;

        public FolderRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<DalFolder> GetByAuthorId(int authorid)
        {
            return context.Set<Folder>().Where(folder => folder.AuthorId == authorid).ToArray().Select(folder => folder.ToDalFolder());
        }
    }
}
