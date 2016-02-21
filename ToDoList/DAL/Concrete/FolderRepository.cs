using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Data.Entity;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
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
