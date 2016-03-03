using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public interface IFolderService
    {
        void Create(FolderEntity folder);
        IEnumerable<FolderEntity> GetByAuthorId(int authorId);
        FolderEntity GetById(int id);
    }
}
